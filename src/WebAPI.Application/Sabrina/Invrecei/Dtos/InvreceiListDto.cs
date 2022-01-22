

using System;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.Invrecei;
using System.Collections.ObjectModel;


namespace WebAPI.Sabrina.Invrecei.Dtos
{	
	/// <summary>
	/// 的列表DTO
	/// <see cref="Invrecei"/>
	/// </summary>
    public class InvreceiListDto : EntityDto<long> 
    {

        
		/// <summary>
		/// org
		/// </summary>
		public string org { get; set; }



		/// <summary>
		/// subinv
		/// </summary>
		public string subinv { get; set; }



		/// <summary>
		/// line
		/// </summary>
		public string line { get; set; }



		/// <summary>
		/// TagNumber
		/// </summary>
		public string TagNumber { get; set; }



		/// <summary>
		/// kg
		/// </summary>
		public string kg { get; set; }



		/// <summary>
		/// scantime
		/// </summary>
		public string scantime { get; set; }



		/// <summary>
		/// update_date
		/// </summary>
		public string update_date { get; set; }



		/// <summary>
		/// create_pc
		/// </summary>
		public string create_pc { get; set; }



		/// <summary>
		/// exeStatus
		/// </summary>
		public string exeStatus { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}