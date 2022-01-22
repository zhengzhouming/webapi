

using System;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.MesDept;
using System.Collections.ObjectModel;


namespace WebAPI.Sabrina.MesDept.Dtos
{	
	/// <summary>
	/// 的列表DTO
	/// <see cref="MesDept"/>
	/// </summary>
    public class MesDeptListDto : EntityDto<long> 
    {
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