using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PruebaApiSpa.Configuration;

namespace PruebaApiSpa.Web.Host.Startup
{
    [DependsOn(
       typeof(PruebaApiSpaWebCoreModule))]
    public class PruebaApiSpaWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PruebaApiSpaWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PruebaApiSpaWebHostModule).GetAssembly());
        }
    }
}
