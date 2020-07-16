
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using WebAPI.Sabrina.Details;


namespace  WebAPI.Sabrina.Details.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="Details"/>
	/// </summary>
    public class DetailsEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// Detailid
		/// </summary>
		public string Detailid { get; set; }



		/// <summary>
		/// Custid
		/// </summary>
		public string Custid { get; set; }



		/// <summary>
		/// SerialFrom
		/// </summary>
		public string SerialFrom { get; set; }



		/// <summary>
		/// BuyerItem
		/// </summary>
		public string BuyerItem { get; set; }



		/// <summary>
		/// Itemdesc
		/// </summary>
		public string Itemdesc { get; set; }



		/// <summary>
		/// Colorcode
		/// </summary>
		public string Colorcode { get; set; }



		/// <summary>
		/// Size1
		/// </summary>
		public string Size1 { get; set; }



		/// <summary>
		/// ConQty
		/// </summary>
		public int? ConQty { get; set; }



		/// <summary>
		/// Qty
		/// </summary>
		public int? Qty { get; set; }



		/// <summary>
		/// Pprfno
		/// </summary>
		public string Pprfno { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}