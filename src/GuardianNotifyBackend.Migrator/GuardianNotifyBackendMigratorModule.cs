using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GuardianNotifyBackend.Configuration;
using GuardianNotifyBackend.EntityFrameworkCore;
using GuardianNotifyBackend.Migrator.DependencyInjection;

namespace GuardianNotifyBackend.Migrator
{
    [DependsOn(typeof(GuardianNotifyBackendEntityFrameworkModule))]
    public class GuardianNotifyBackendMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public GuardianNotifyBackendMigratorModule(GuardianNotifyBackendEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(GuardianNotifyBackendMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                GuardianNotifyBackendConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GuardianNotifyBackendMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
