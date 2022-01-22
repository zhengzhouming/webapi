

using System;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.MesWorkTagScan;
using System.Collections.ObjectModel;


namespace WebAPI.Sabrina.MesWorkTagScan.Dtos
{	
	/// <summary>
	/// 的列表DTO
	/// <see cref="MesWorkTagScan"/>
	/// </summary>
    public class MesWorkTagScanListDto : EntityDto<long> 
    {

        
		/// <summary>
		/// tagInvoice
		/// </summary>
		public string tagInvoice { get; set; }



		/// <summary>
		/// tagReceiptNumber
		/// </summary>
		public string tagReceiptNumber { get; set; }



		/// <summary>
		/// tagLocation
		/// </summary>
		public string tagLocation { get; set; }



		/// <summary>
		/// tagNumber
		/// </summary>
		[Required(ErrorMessage="tagNumber不能为空")]
		public string tagNumber { get; set; }



		/// <summary>
		/// tagScanAccount
		/// </summary>
		[Required(ErrorMessage="tagScanAccount不能为空")]
		public string tagScanAccount { get; set; }



		/// <summary>
		/// tagScanDeptID
		/// </summary>
		[Required(ErrorMessage="tagScanDeptID不能为空")]
		public int tagScanDeptID { get; set; }



		/// <summary>
		/// tagScanDateTime
		/// </summary>
		[Required(ErrorMessage="tagScanDateTime不能为空")]
		public string tagScanDateTime { get; set; }



		/// <summary>
		/// tagUploadDateTime
		/// </summary>
		[Required(ErrorMessage="tagUploadDateTime不能为空")]
		public string tagUploadDateTime { get; set; }



		/// <summary>
		/// tagScanPDASerial
		/// </summary>
		public string tagScanPDASerial { get; set; }



		/// <summary>
		/// tagScanPDAUUID
		/// </summary>
		public string tagScanPDAUUID { get; set; }



		/// <summary>
		/// tagStyle
		/// </summary>
		[Required(ErrorMessage="tagStyle不能为空")]
		public string tagStyle { get; set; }



		/// <summary>
		/// tagColor
		/// </summary>
		[Required(ErrorMessage="tagColor不能为空")]
		public string tagColor { get; set; }



		/// <summary>
		/// tagSize
		/// </summary>
		[Required(ErrorMessage="tagSize不能为空")]
		public string tagSize { get; set; }



		/// <summary>
		/// tagQty
		/// </summary>
		[Required(ErrorMessage="tagQty不能为空")]
		public int tagQty { get; set; }



		/// <summary>
		/// isUploaded
		/// </summary>
		[Required(ErrorMessage="isUploaded不能为空")]
		public int isUploaded { get; set; }



		/// <summary>
		/// isSyncMesData
		/// </summary>
		[Required(ErrorMessage="isSyncMesData不能为空")]
		public int isSyncMesData { get; set; }



		/// <summary>
		/// isPrints
		/// </summary>
		[Required(ErrorMessage="isPrints不能为空")]
		public int isPrints { get; set; }



		/// <summary>
		/// tagInvoiceVersion
		/// </summary>
		[Required(ErrorMessage="tagInvoiceVersion不能为空")]
		public int tagInvoiceVersion { get; set; }



		/// <summary>
		/// isInOrOut
		/// </summary>
		public int isInOrOut { get; set; }



		/// <summary>
		/// isDels
		/// </summary>
		public int isDels { get; set; }



		/// <summary>
		/// tagOrg
		/// </summary>
		public string tagOrg { get; set; }



		/// <summary>
		/// tagLine
		/// </summary>
		public string tagLine { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}