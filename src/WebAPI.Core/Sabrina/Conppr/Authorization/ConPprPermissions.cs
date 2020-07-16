

namespace WebAPI.Sabrina.Conppr.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="ConPprAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class ConPprPermissions
	{
		/// <summary>
		/// ConPpr权限节点
		///</summary>
		public const string Node = "Pages.ConPpr";

		/// <summary>
		/// ConPpr查询授权
		///</summary>
		public const string Query = "Pages.ConPpr.Query";

		/// <summary>
		/// ConPpr创建权限
		///</summary>
		public const string Create = "Pages.ConPpr.Create";

		/// <summary>
		/// ConPpr修改权限
		///</summary>
		public const string Edit = "Pages.ConPpr.Edit";

		/// <summary>
		/// ConPpr删除权限
		///</summary>
		public const string Delete = "Pages.ConPpr.Delete";

        /// <summary>
		/// ConPpr批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.ConPpr.BatchDelete";

		/// <summary>
		/// ConPpr导出Excel
		///</summary>
		public const string ExportExcel="Pages.ConPpr.ExportExcel";

		 
		 
         
    }

}

