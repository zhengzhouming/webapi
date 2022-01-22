

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
    /// See <see cref="MesWorkTagScanReceiptPermissions" /> for all permission names. MesWorkTagScanReceipt
    ///</summary>
    public class MesWorkTagScanReceiptAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public MesWorkTagScanReceiptAuthorizationProvider()
		{

		}

       
        public MesWorkTagScanReceiptAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public MesWorkTagScanReceiptAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了MesWorkTagScanReceipt 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var mesWorkTagScanReceipt = administration.CreateChildPermission(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Node , L("MesWorkTagScanReceipt"));
				mesWorkTagScanReceipt.CreateChildPermission(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Query, L("QueryMesWorkTagScanReceipt"));
				mesWorkTagScanReceipt.CreateChildPermission(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Create, L("CreateMesWorkTagScanReceipt"));
				mesWorkTagScanReceipt.CreateChildPermission(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Edit, L("EditMesWorkTagScanReceipt"));
				mesWorkTagScanReceipt.CreateChildPermission(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_Delete, L("DeleteMesWorkTagScanReceipt"));
				mesWorkTagScanReceipt.CreateChildPermission(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_BatchDelete, L("BatchDeleteMesWorkTagScanReceipt"));
				mesWorkTagScanReceipt.CreateChildPermission(MesWorkTagScanReceiptPermissions.MesWorkTagScanReceipt_ExportExcel, L("ExportToExcel"));
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, WebAPIConsts.LocalizationSourceName);
		}
    }
}
