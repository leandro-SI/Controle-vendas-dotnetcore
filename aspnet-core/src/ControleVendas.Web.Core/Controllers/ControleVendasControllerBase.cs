using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ControleVendas.Controllers
{
    public abstract class ControleVendasControllerBase: AbpController
    {
        protected ControleVendasControllerBase()
        {
            LocalizationSourceName = ControleVendasConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
