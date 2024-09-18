using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GuardianNotifyBackend.Authorization;

namespace GuardianNotifyBackend
{
    [DependsOn(
        typeof(GuardianNotifyBackendCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class GuardianNotifyBackendApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<GuardianNotifyBackendAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(GuardianNotifyBackendApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
