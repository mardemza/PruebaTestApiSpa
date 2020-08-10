using PruebaApiSpa.Base;
using PruebaApiSpa.Subdivisions.Dto;
using System.Threading.Tasks;

namespace PruebaApiSpa.Subdivisions
{
    public interface ISubdivisionAppService
    {
        Task<ContextDto<ProvinceDto>> GetAll(SearchDto filters);
        Task<ProvinceInputDto> Get(long id);
        Task<ProvinceDto> AddOrUpdate(ProvinceInputDto input);
        Task Delete(long id);
    }
}