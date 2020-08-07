using Abp.Authorization;
using PruebaApiSpa.Authorization.Roles;
using PruebaApiSpa.Authorization.Users;

namespace PruebaApiSpa.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
