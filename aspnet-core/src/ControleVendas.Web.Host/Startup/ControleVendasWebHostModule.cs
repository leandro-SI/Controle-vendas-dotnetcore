using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ControleVendas.Configuration;

namespace ControleVendas.Web.Host.Startup
{
    [DependsOn(
       typeof(ControleVendasWebCoreModule))]
    public class ControleVendasWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ControleVendasWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ControleVendasWebHostModule).GetAssembly());
        }
    }
}
