using System.Threading.Tasks;
using PruebaApiSpa.Configuration.Dto;

namespace PruebaApiSpa.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
