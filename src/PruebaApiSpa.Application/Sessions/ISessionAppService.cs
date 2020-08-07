using System.Threading.Tasks;
using Abp.Application.Services;
using PruebaApiSpa.Sessions.Dto;

namespace PruebaApiSpa.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
