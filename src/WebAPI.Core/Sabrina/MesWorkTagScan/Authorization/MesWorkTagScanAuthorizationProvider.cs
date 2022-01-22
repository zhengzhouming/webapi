

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using WebAPI.Authorization;

// ReSharper disable once CheckNamespace
namespace WebAPI.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="MesWorkTagScanPermissions" /> for all permission names. MesWorkTagScan
    ///</summary>
    public class MesWorkTagScanAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public MesWorkTagScanAuthorizationProvider()
		{

		}

       
        public MesWorkTagScanAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public MesWorkTagScanAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了MesWorkTagScan 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var mesWorkTagScan = administration.CreateChildPermission(MesWorkTagScanPermissions.MesWorkTagScan_Node , L("MesWorkTagScan"));
				mesWorkTagScan.CreateChildPermission(MesWorkTagScanPermissions.MesWorkTagScan_Query, L("QueryMesWorkTagScan"));
				mesWorkTagScan.CreateChildPermission(MesWorkTagScanPermissions.MesWorkTagScan_Create, L("CreateMesWorkTagScan"));
				mesWorkTagScan.CreateChildPermission(MesWorkTagScanPermissions.MesWorkTagScan_Edit, L("EditMesWorkTagScan"));
				mesWorkTagScan.CreateChildPermission(MesWorkTagScanPermissions.MesWorkTagScan_Delete, L("DeleteMesWorkTagScan"));
				mesWorkTagScan.CreateChildPermission(MesWorkTagScanPermissions.MesWorkTagScan_BatchDelete, L("BatchDeleteMesWorkTagScan"));
				mesWorkTagScan.CreateChildPermission(MesWorkTagScanPermissions.MesWorkTagScan_ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, WebAPIConsts.LocalizationSourceName);
		}
    }
}
