using Abp.Authorization;
using WebAPI.Authorization.Roles;
using WebAPI.Authorization.Users;

namespace WebAPI.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
