using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ControleVendas.EntityFrameworkCore;
using ControleVendas.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ControleVendas.Web.Tests
{
    [DependsOn(
        typeof(ControleVendasWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ControleVendasWebTestModule : AbpModule
    {
        public ControleVendasWebTestModule(ControleVendasEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ControleVendasWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ControleVendasWebMvcModule).Assembly);
        }
    }
}