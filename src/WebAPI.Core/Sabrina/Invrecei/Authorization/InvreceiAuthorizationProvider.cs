

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
    /// See <see cref="InvreceiPermissions" /> for all permission names. Invrecei
    ///</summary>
    public class InvreceiAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public InvreceiAuthorizationProvider()
		{

		}

       
        public InvreceiAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public InvreceiAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Invrecei 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var invrecei = administration.CreateChildPermission(InvreceiPermissions.Node , L("Invrecei"));
				invrecei.CreateChildPermission(InvreceiPermissions.Query, L("QueryInvrecei"));
				invrecei.CreateChildPermission(InvreceiPermissions.Create, L("CreateInvrecei"));
				invrecei.CreateChildPermission(InvreceiPermissions.Edit, L("EditInvrecei"));
				invrecei.CreateChildPermission(InvreceiPermissions.Delete, L("DeleteInvrecei"));
				invrecei.CreateChildPermission(InvreceiPermissions.BatchDelete, L("BatchDeleteInvrecei"));
				invrecei.CreateChildPermission(InvreceiPermissions.ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, WebAPIConsts.LocalizationSourceName);
		}
    }
}
