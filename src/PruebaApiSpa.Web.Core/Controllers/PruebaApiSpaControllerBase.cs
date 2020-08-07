using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace PruebaApiSpa.Controllers
{
    public abstract class PruebaApiSpaControllerBase: AbpController
    {
        protected PruebaApiSpaControllerBase()
        {
            LocalizationSourceName = PruebaApiSpaConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
