

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
    /// See <see cref="CountReceiPermissions" /> for all permission names. CountRecei
    ///</summary>
    public class CountReceiAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public CountReceiAuthorizationProvider()
		{

		}

       
        public CountReceiAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public CountReceiAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了CountRecei 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var countRecei = administration.CreateChildPermission(CountReceiPermissions.Node , L("CountRecei"));
				countRecei.CreateChildPermission(CountReceiPermissions.Query, L("QueryCountRecei"));
				countRecei.CreateChildPermission(CountReceiPermissions.Create, L("CreateCountRecei"));
				countRecei.CreateChildPermission(CountReceiPermissions.Edit, L("EditCountRecei"));
				countRecei.CreateChildPermission(CountReceiPermissions.Delete, L("DeleteCountRecei"));
				countRecei.CreateChildPermission(CountReceiPermissions.BatchDelete, L("BatchDeleteCountRecei"));
				countRecei.CreateChildPermission(CountReceiPermissions.ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, WebAPIConsts.LocalizationSourceName);
		}
    }
}
