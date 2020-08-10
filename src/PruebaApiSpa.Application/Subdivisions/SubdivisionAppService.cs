using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;
using PruebaApiSpa.Base;
using PruebaApiSpa.Domain;
using PruebaApiSpa.Extensions;
using PruebaApiSpa.Subdivisions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace PruebaApiSpa.Subdivisions
{
    [AbpAuthorize]
    public class SubdivisionAppService: PruebaApiSpaAppServiceBase, ISubdivisionAppService
    {
        private readonly IRepository<Country, long> _countryRepository;
        private readonly IRepository<Province, long> _provinceRepository;

        public SubdivisionAppService(IRepository<Country, long> countryRepository,
                                 IRepository<Province, long> provinceRepository)
        {
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
        }

        [HttpPost]
        public async Task<ProvinceDto> AddOrUpdate(ProvinceInputDto input)
        {
            var province = _provinceRepository.FirstOrDefault(x => x.Id == input.Id);
            var isNew = province == null;


            // -- Check if exist Code
            var existCode = await _provinceRepository.FirstOrDefaultAsync(x => (isNew || (!isNew && x.Id != input.Id)) && x.CountryId == input.CountryId && x.Code.ToLower() == input.Code.ToLower().Trim());
            if (existCode != null)
            {
                throw new UserFriendlyException("This Code already exists");
            }

            // -- Check if exist SubDivisionName
            var existSubDivisionName = await _provinceRepository.FirstOrDefaultAsync(x => (isNew || (!isNew && x.Id != input.Id)) && x.CountryId == input.CountryId  && x.SubDivisionName.ToLower() == input.SubDivisionName.ToLower().Trim());
            if (existSubDivisionName != null)
            {
                throw new UserFriendlyException("This Sub Division Name already exists");
            }

            var provinceLocal = ObjectMapper.Map(input, province);

            province = await _provinceRepository.InsertOrUpdateAsync(provinceLocal);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<ProvinceDto>(province);
        }

        [HttpPost]
        public async Task Delete(long id)
        {
            var province = await _provinceRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (province != null)
            {
                // -- Delete Province
                await _provinceRepository.DeleteAsync(id);
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }

        [HttpGet]
        public async Task<ProvinceInputDto> Get(long id)
        {
            var province = await _provinceRepository.GetAsync(id);
            return ObjectMapper.Map<ProvinceInputDto>(province);
        }

        [HttpPost]
        public async Task<ContextDto<ProvinceDto>> GetAll(SearchDto filters)
        {
            filters.Search = filters.Search.IsNullOrEmpty() ? "" : filters.Search.Trim().ToLower();
            var context = _provinceRepository
                .GetAll()
                .Where(x => x.CountryId == filters.CountryId)
                .Search(x => x.Code.ToLower(),
                        x => x.SubDivisionName.ToLower())
                .Containing(filters.Search)
                .OrderByTo(filters.OrderColumn, filters.Order.ToLower() == "desc")
                .ToPagedList(filters.Page, filters.PageSize);

            return new ContextDto<ProvinceDto>
            {
                Data = await Task.Run(() => context.ToList().Select(x => ObjectMapper.Map<ProvinceDto>(x))),
                MetaData = context.GetMetaData()
            };
        }
    }
}
