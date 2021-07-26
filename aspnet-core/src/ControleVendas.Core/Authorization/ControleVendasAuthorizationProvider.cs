using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ControleVendas.Authorization
{
    public class ControleVendasAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            #region CIDADE
            context.CreatePermission(PermissionNames.ControleVendas_Cidade, L("Cidade"));
            context.CreatePermission(PermissionNames.ControleVendas_ListarCidade, L("ListarCidade"));
            context.CreatePermission(PermissionNames.ControleVendas_DetalheCidade, L("DetalheCidade"));
            context.CreatePermission(PermissionNames.ControleVendas_CriarCidade, L("CriarCidade"));
            context.CreatePermission(PermissionNames.ControleVendas_AlterarCidade, L("AlterarCidade"));
            context.CreatePermission(PermissionNames.ControleVendas_ExcluirCidade, L("ExcluirCidade"));
            #endregion

            #region ESTADO
            context.CreatePermission(PermissionNames.ControleVendas_Estado, L("Estado"));
            context.CreatePermission(PermissionNames.ControleVendas_ListarEstado, L("ListarEstado"));
            context.CreatePermission(PermissionNames.ControleVendas_DetalheEstado, L("DetalheEstado"));
            context.CreatePermission(PermissionNames.ControleVendas_CriarEstado, L("CriarEstado"));
            context.CreatePermission(PermissionNames.ControleVendas_AlterarEstado, L("AlterarEstado"));
            context.CreatePermission(PermissionNames.ControleVendas_ExcluirEstado, L("ExcluirEstado"));
            #endregion



        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ControleVendasConsts.LocalizationSourceName);
        }
    }
}
