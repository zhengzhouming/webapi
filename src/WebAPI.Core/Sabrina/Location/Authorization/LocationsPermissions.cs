

namespace WebAPI.Sabrina.Locations.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="LocationsAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class LocationsPermissions
	{
		/// <summary>
		/// Locations权限节点
		///</summary>
		public const string Node = "Pages.Locations";

		/// <summary>
		/// Locations查询授权
		///</summary>
		public const string Query = "Pages.Locations.Query";

		/// <summary>
		/// Locations创建权限
		///</summary>
		public const string Create = "Pages.Locations.Create";

		/// <summary>
		/// Locations修改权限
		///</summary>
		public const string Edit = "Pages.Locations.Edit";

		/// <summary>
		/// Locations删除权限
		///</summary>
		public const string Delete = "Pages.Locations.Delete";

        /// <summary>
		/// Locations批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Locations.BatchDelete";

		/// <summary>
		/// Locations导出Excel
		///</summary>
		public const string ExportExcel="Pages.Locations.ExportExcel";

		 
		 
         
    }

}

