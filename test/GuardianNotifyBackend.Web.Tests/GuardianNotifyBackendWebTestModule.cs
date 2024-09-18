using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GuardianNotifyBackend.EntityFrameworkCore;
using GuardianNotifyBackend.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace GuardianNotifyBackend.Web.Tests
{
    [DependsOn(
        typeof(GuardianNotifyBackendWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class GuardianNotifyBackendWebTestModule : AbpModule
    {
        public GuardianNotifyBackendWebTestModule(GuardianNotifyBackendEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GuardianNotifyBackendWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(GuardianNotifyBackendWebMvcModule).Assembly);
        }
    }
}