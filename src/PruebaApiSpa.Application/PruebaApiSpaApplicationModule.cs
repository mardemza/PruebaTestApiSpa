using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PruebaApiSpa.Authorization;

namespace PruebaApiSpa
{
    [DependsOn(
        typeof(PruebaApiSpaCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PruebaApiSpaApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PruebaApiSpaAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(PruebaApiSpaApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
