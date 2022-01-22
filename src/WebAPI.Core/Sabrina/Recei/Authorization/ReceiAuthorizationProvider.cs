

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
    /// See <see cref="ReceiPermissions" /> for all permission names. Recei
    ///</summary>
    public class ReceiAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public ReceiAuthorizationProvider()
		{

		}

       
        public ReceiAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public ReceiAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Recei 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var recei = administration.CreateChildPermission(ReceiPermissions.Node , L("Recei"));
				recei.CreateChildPermission(ReceiPermissions.Query, L("QueryRecei"));
				recei.CreateChildPermission(ReceiPermissions.Create, L("CreateRecei"));
				recei.CreateChildPermission(ReceiPermissions.Edit, L("EditRecei"));
				recei.CreateChildPermission(ReceiPermissions.Delete, L("DeleteRecei"));
				recei.CreateChildPermission(ReceiPermissions.BatchDelete, L("BatchDeleteRecei"));
				recei.CreateChildPermission(ReceiPermissions.ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, WebAPIConsts.LocalizationSourceName);
		}
    }
}
