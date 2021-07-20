using Abp.Authorization;
using ControleVendas.Authorization.Roles;
using ControleVendas.Authorization.Users;

namespace ControleVendas.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
