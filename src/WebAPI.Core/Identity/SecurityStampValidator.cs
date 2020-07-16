using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using WebAPI.Authorization.Roles;
using WebAPI.Authorization.Users;
using WebAPI.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace WebAPI.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
         IOptions<SecurityStampValidatorOptions> options,
         SignInManager signInManager,
         ISystemClock systemClock,
         ILoggerFactory loggerFactory)
         : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}