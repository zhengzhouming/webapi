

using System;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.MesWorkTagScanReceipt;
using System.Collections.ObjectModel;


namespace WebAPI.Sabrina.MesWorkTagScanReceipt.Dtos
{	
	/// <summary>
	/// 的列表DTO
	/// <see cref="MesWorkTagScanReceipt"/>
	/// </summary>
    public class MesWorkTagScanReceiptListDto : EntityDto<long> 
    {

        
		/// <summary>
		/// Version
		/// </summary>
		public string Version { get; set; }



		/// <summary>
		/// tagScanAccount
		/// </summary>
		public string tagScanAccount { get; set; }



		/// <summary>
		/// tagScanDeptID
		/// </summary>
		public int tagScanDeptID { get; set; }



		/// <summary>
		/// tagScanDateTime
		/// </summary>
		public string tagScanDateTime { get; set; }



		/// <summary>
		/// tagScanPDASerial
		/// </summary>
		public string tagScanPDASerial { get; set; }



		/// <summary>
		/// tagScanPDAUUID
		/// </summary>
		public string tagScanPDAUUID { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}