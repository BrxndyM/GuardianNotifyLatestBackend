using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using GuardianNotifyBackend.EntityFrameworkCore.Seed;

namespace GuardianNotifyBackend.EntityFrameworkCore
{
    [DependsOn(
        typeof(GuardianNotifyBackendCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class GuardianNotifyBackendEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<GuardianNotifyBackendDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        GuardianNotifyBackendDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        GuardianNotifyBackendDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GuardianNotifyBackendEntityFrameworkModule).GetAssembly());
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
