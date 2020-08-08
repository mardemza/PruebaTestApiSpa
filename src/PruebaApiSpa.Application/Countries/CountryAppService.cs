using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NinjaNye.SearchExtensions;
using PruebaApiSpa.Base;
using PruebaApiSpa.Countries.Dto;
using PruebaApiSpa.Domain;
using PruebaApiSpa.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace PruebaApiSpa.Countries
{
    [AbpAuthorize]
    public class CountryAppService : PruebaApiSpaAppServiceBase, ICountryAppService
    {
        private readonly IRepository<Country, long> _countryRepository;
        private readonly IRepository<Province, long> _provinceRepository;

        public CountryAppService(IRepository<Country, long> countryRepository,
                                 IRepository<Province, long> provinceRepository)
        {
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
        }

        [HttpPost]
        public async Task<CountryDto> AddOrUpdate(CountryInputDto input)
        {
            var country = _countryRepository.FirstOrDefault(x => x.Id == input.Id);
            var isNew = country == null;


            // -- Check if exist SortName
            var existSortName = await _countryRepository.FirstOrDefaultAsync(x => (isNew || (!isNew && x.Id != input.Id)) && x.ShortName.ToLower() == input.ShortName.ToLower().Trim());
            if (existSortName != null)
            {
                throw new UserFriendlyException("This Short Name already exists");
            }

            // -- Check if exist Alpha2Code
            var existAlpha2Code = await _countryRepository.FirstOrDefaultAsync(x => (isNew || (!isNew && x.Id != input.Id)) && x.Alpha2Code.ToLower() == input.Alpha2Code.ToLower().Trim());
            if (existAlpha2Code != null)
            {
                throw new UserFriendlyException("This Alpha 2 Code already exists");
            }

            // -- Check if exist Alpha3Code
            var existAlpha3Code = await _countryRepository.FirstOrDefaultAsync(x => (isNew || (!isNew && x.Id != input.Id)) && x.Alpha3Code.ToLower() == input.Alpha3Code.ToLower().Trim());
            if (existAlpha3Code != null)
            {
                throw new UserFriendlyException("This Alpha 3 Code already exists");
            }

            // -- Check if exist NumericCode
            var existNumericCode = await _countryRepository.FirstOrDefaultAsync(x => (isNew || (!isNew && x.Id != input.Id)) && x.NumericCode.ToLower() == input.NumericCode.ToLower().Trim());
            if (existNumericCode != null)
            {
                throw new UserFriendlyException("This Numeric Code already exists");
            }

            var countryLocal = ObjectMapper.Map(input, country);

            country = await _countryRepository.InsertOrUpdateAsync(countryLocal);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<CountryDto>(country);
        }

        [HttpPost]
        public async Task Delete(long id)
        {
            var country = await _countryRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (country != null)
            {
                // -- Delete Provinces
                if (country.Provinces.Any())
                {
                    var ids = country.Provinces.Select(x => x.Id);
                    await _provinceRepository.DeleteAsync(x => ids.Contains(x.Id));
                    await CurrentUnitOfWork.SaveChangesAsync();
                }

                // -- Delete Country
                await _countryRepository.DeleteAsync(id);
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }

        [HttpGet]
        public async Task<CountryInputDto> Get(long id)
        {
            var country = await _countryRepository.GetAsync(id);
            return ObjectMapper.Map<CountryInputDto>(country);
        }

        [HttpPost]
        public async Task<ContextDto<CountryDto>> GetAll(SearchDto filters)
        {
            filters.Search = filters.Search.IsNullOrEmpty() ? "" : filters.Search.Trim().ToLower();
            var context = _countryRepository
                .GetAll()
                .Include(x => x.Provinces)
                .Search(x => x.ShortName.ToLower(),
                        x => x.Alpha2Code.ToLower(),
                        x => x.Alpha3Code.ToLower(),
                        x => x.NumericCode.ToLower())
                .Containing(filters.Search)
                .OrderByTo(filters.OrderColumn, filters.Order.ToLower() == "desc")
                .ToPagedList(filters.Page, filters.PageSize);

            return new ContextDto<CountryDto>
            {
                Data = await Task.Run(() => context.ToList().Select(x => ObjectMapper.Map<CountryDto>(x))),
                MetaData = context.GetMetaData()
            };
        }
    }
}
