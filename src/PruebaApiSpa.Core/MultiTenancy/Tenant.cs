using Abp.MultiTenancy;
using PruebaApiSpa.Authorization.Users;

namespace PruebaApiSpa.MultiTenancy
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
