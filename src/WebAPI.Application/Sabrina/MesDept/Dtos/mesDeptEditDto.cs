
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using WebAPI.Sabrina.MesDept;


namespace  WebAPI.Sabrina.MesDept.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="MesDept"/>
	/// </summary>
    public class MesDeptEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// DeptName
		/// </summary>
		public string DeptName { get; set; }



		/// <summary>
		/// DeptNumber
		/// </summary>
		public string DeptNumber { get; set; }



		/// <summary>
		/// Marsk
		/// </summary>
		public string Marsk { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}