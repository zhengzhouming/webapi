
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using WebAPI.Sabrina.MesWorkTagScanReceipt;


namespace  WebAPI.Sabrina.MesWorkTagScanReceipt.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="MesWorkTagScanReceipt"/>
	/// </summary>
    public class MesWorkTagScanReceiptEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
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