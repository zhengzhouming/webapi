using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Controllers
{
    public abstract class WebAPIControllerBase: AbpController
    {
        protected WebAPIControllerBase()
        {
            LocalizationSourceName = WebAPIConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
