

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using WebAPI.Authorization;

namespace WebAPI.Sabrina.barcodeScan.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="invPermissions" /> for all permission names. inv
    ///</summary>
    public class invAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public invAuthorizationProvider()
		{

		}

        public invAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public invAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了inv 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(invPermissions.Node , L("inv"));
				entityPermission.CreateChildPermission(invPermissions.Query, L("Queryinv"));
				entityPermission.CreateChildPermission(invPermissions.Create, L("Createinv"));
				entityPermission.CreateChildPermission(invPermissions.Edit, L("Editinv"));
				entityPermission.CreateChildPermission(invPermissions.Delete, L("Deleteinv"));
				entityPermission.CreateChildPermission(invPermissions.BatchDelete, L("BatchDeleteinv"));
				entityPermission.CreateChildPermission(invPermissions.ExportExcel, L("ExportExcelinv"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, WebAPIConsts.LocalizationSourceName);
		}
    }
}