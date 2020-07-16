

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using WebAPI.Authorization;

namespace WebAPI.Sabrina.Locations.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="LocationsPermissions" /> for all permission names. Locations
    ///</summary>
    public class LocationsAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public LocationsAuthorizationProvider()
		{

		}

        public LocationsAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public LocationsAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Locations 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(LocationsPermissions.Node , L("Locations"));
			entityPermission.CreateChildPermission(LocationsPermissions.Query, L("QueryLocations"));
			entityPermission.CreateChildPermission(LocationsPermissions.Create, L("CreateLocations"));
			entityPermission.CreateChildPermission(LocationsPermissions.Edit, L("EditLocations"));
			entityPermission.CreateChildPermission(LocationsPermissions.Delete, L("DeleteLocations"));
			entityPermission.CreateChildPermission(LocationsPermissions.BatchDelete, L("BatchDeleteLocations"));
			entityPermission.CreateChildPermission(LocationsPermissions.ExportExcel, L("ExportExcelLocations"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, WebAPIConsts.LocalizationSourceName);
		}
    }
}