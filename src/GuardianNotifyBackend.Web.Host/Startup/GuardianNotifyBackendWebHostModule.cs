using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GuardianNotifyBackend.Configuration;

namespace GuardianNotifyBackend.Web.Host.Startup
{
    [DependsOn(
       typeof(GuardianNotifyBackendWebCoreModule))]
    public class GuardianNotifyBackendWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public GuardianNotifyBackendWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GuardianNotifyBackendWebHostModule).GetAssembly());
        }
    }
}
