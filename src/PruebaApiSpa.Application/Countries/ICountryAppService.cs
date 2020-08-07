using Abp.Application.Services;
using PruebaApiSpa.Base;
using PruebaApiSpa.Countries.Dto;
using System.Threading.Tasks;

namespace PruebaApiSpa.Countries
{
    public interface ICountryAppService: IApplicationService
    {
        Task<ContextDto<CountryDto>> GetAll(SearchDto filters);
        Task<CountryDto> Get(long id);
        Task<CountryDto> AddOrUpdate(CountryInputDto input);
        Task Delete(long id);
    }
}