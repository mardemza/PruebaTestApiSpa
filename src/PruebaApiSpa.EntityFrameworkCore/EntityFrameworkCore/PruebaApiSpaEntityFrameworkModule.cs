using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using PruebaApiSpa.EntityFrameworkCore.Seed;

namespace PruebaApiSpa.EntityFrameworkCore
{
    [DependsOn(
        typeof(PruebaApiSpaCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class PruebaApiSpaEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false;

            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<PruebaApiSpaDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        PruebaApiSpaDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        PruebaApiSpaDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PruebaApiSpaEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
