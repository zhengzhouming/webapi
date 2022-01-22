
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using WebAPI.Sabrina.Users;


namespace  WebAPI.Sabrina.Users.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="MesUser"/>
	/// </summary>
    public class MesUserEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// account
		/// </summary>
		public string account { get; set; }



		/// <summary>
		/// password
		/// </summary>
		public string password { get; set; }



		/// <summary>
		/// userName
		/// </summary>
		public string userName { get; set; }



		/// <summary>
		/// deptID
		/// </summary>
		public string deptID { get; set; }



		/// <summary>
		/// marsk
		/// </summary>
		public string marsk { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}