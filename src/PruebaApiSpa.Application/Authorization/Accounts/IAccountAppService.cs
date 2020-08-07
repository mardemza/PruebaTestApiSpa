using System.Threading.Tasks;
using Abp.Application.Services;
using PruebaApiSpa.Authorization.Accounts.Dto;

namespace PruebaApiSpa.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
