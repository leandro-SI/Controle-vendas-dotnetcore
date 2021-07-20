using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ControleVendas.Authorization;

namespace ControleVendas
{
    [DependsOn(
        typeof(ControleVendasCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ControleVendasApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ControleVendasAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ControleVendasApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
