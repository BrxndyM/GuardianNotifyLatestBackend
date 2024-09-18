using Abp.Authorization;
using GuardianNotifyBackend.Authorization.Roles;
using GuardianNotifyBackend.Authorization.Users;

namespace GuardianNotifyBackend.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
