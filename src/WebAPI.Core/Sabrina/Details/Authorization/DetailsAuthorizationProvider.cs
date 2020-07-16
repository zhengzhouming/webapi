

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using WebAPI.Authorization;

namespace WebAPI.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="DetailsPermissions" /> for all permission names. Details
    ///</summary>
    public class DetailsAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public DetailsAuthorizationProvider()
		{

		}

       
        public DetailsAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public DetailsAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Details 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var details = administration.CreateChildPermission(DetailsPermissions.Node , L("Details"));
details.CreateChildPermission(DetailsPermissions.Query, L("QueryDetails"));
details.CreateChildPermission(DetailsPermissions.Create, L("CreateDetails"));
details.CreateChildPermission(DetailsPermissions.Edit, L("EditDetails"));
details.CreateChildPermission(DetailsPermissions.Delete, L("DeleteDetails"));
details.CreateChildPermission(DetailsPermissions.BatchDelete, L("BatchDeleteDetails"));
details.CreateChildPermission(DetailsPermissions.ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, WebAPIConsts.LocalizationSourceName);
		}
    }
}
