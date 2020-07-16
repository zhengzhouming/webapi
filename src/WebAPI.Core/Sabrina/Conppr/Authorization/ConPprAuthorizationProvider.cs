

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using WebAPI.Authorization;

namespace WebAPI.Sabrina.Conppr.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="ConPprPermissions" /> for all permission names. ConPpr
    ///</summary>
    public class ConPprAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public ConPprAuthorizationProvider()
		{

		}

        public ConPprAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public ConPprAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了ConPpr 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(ConPprPermissions.Node , L("ConPpr"));
			entityPermission.CreateChildPermission(ConPprPermissions.Query, L("QueryConPpr"));
			entityPermission.CreateChildPermission(ConPprPermissions.Create, L("CreateConPpr"));
			entityPermission.CreateChildPermission(ConPprPermissions.Edit, L("EditConPpr"));
			entityPermission.CreateChildPermission(ConPprPermissions.Delete, L("DeleteConPpr"));
			entityPermission.CreateChildPermission(ConPprPermissions.BatchDelete, L("BatchDeleteConPpr"));
			entityPermission.CreateChildPermission(ConPprPermissions.ExportExcel, L("ExportExcelConPpr"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, WebAPIConsts.LocalizationSourceName);
		}
    }
}