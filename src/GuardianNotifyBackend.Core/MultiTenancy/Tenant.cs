using Abp.MultiTenancy;
using GuardianNotifyBackend.Authorization.Users;

namespace GuardianNotifyBackend.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
