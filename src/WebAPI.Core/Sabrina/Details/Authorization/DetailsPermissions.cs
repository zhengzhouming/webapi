

namespace WebAPI.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="DetailsAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class DetailsPermissions
	{
		/// <summary>
		/// Details权限节点
		///</summary>
		public const string Node = "Pages.Details";

		/// <summary>
		/// Details查询授权
		///</summary>
		public const string Query = "Pages.Details.Query";

		/// <summary>
		/// Details创建权限
		///</summary>
		public const string Create = "Pages.Details.Create";

		/// <summary>
		/// Details修改权限
		///</summary>
		public const string Edit = "Pages.Details.Edit";

		/// <summary>
		/// Details删除权限
		///</summary>
		public const string Delete = "Pages.Details.Delete";

        /// <summary>
		/// Details批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Details.BatchDelete";

		/// <summary>
		/// Details导出Excel
		///</summary>
		public const string ExportExcel="Pages.Details.ExportExcel";

		 
		 
							//// custom codes
									
							

							//// custom codes end
         
    }

}

