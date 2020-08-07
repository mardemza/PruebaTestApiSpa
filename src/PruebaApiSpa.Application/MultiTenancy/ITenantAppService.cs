using Abp.Application.Services;
using PruebaApiSpa.MultiTenancy.Dto;

namespace PruebaApiSpa.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

