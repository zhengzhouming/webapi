

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
    /// See <see cref="MesDeptPermissions" /> for all permission names. MesDept
    ///</summary>
    public class MesDeptAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public MesDeptAuthorizationProvider()
		{

		}

       
        public MesDeptAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public MesDeptAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了MesDept 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var MesDept = administration.CreateChildPermission(MesDeptPermissions.MesDept_Node , L("MesDept"));
				MesDept.CreateChildPermission(MesDeptPermissions.MesDept_Query, L("QueryMesDept"));
				MesDept.CreateChildPermission(MesDeptPermissions.MesDept_Create, L("CreateMesDept"));
				MesDept.CreateChildPermission(MesDeptPermissions.MesDept_Edit, L("EditMesDept"));
				MesDept.CreateChildPermission(MesDeptPermissions.MesDept_Delete, L("DeleteMesDept"));
				MesDept.CreateChildPermission(MesDeptPermissions.MesDept_BatchDelete, L("BatchDeleteMesDept"));
				MesDept.CreateChildPermission(MesDeptPermissions.MesDept_ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, WebAPIConsts.LocalizationSourceName);
		}
    }
}
