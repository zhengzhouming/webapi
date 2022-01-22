

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
    /// See <see cref="MesUserPermissions" /> for all permission names. MesUser
    ///</summary>
    public class MesUserAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public MesUserAuthorizationProvider()
		{

		}

       
        public MesUserAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public MesUserAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了MesUser 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var mesUser = administration.CreateChildPermission(MesUserPermissions.MesUser_Node , L("MesUser"));
									mesUser.CreateChildPermission(MesUserPermissions.MesUser_Query, L("QueryMesUser"));
									mesUser.CreateChildPermission(MesUserPermissions.MesUser_Create, L("CreateMesUser"));
									mesUser.CreateChildPermission(MesUserPermissions.MesUser_Edit, L("EditMesUser"));
									mesUser.CreateChildPermission(MesUserPermissions.MesUser_Delete, L("DeleteMesUser"));
									mesUser.CreateChildPermission(MesUserPermissions.MesUser_BatchDelete, L("BatchDeleteMesUser"));
									mesUser.CreateChildPermission(MesUserPermissions.MesUser_ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, WebAPIConsts.LocalizationSourceName);
		}
    }
}
