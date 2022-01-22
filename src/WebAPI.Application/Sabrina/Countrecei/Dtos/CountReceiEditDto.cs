
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using WebAPI.Sabrina.Countrecei;


namespace  WebAPI.Sabrina.Countrecei.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="CountRecei"/>
	/// </summary>
    public class CountReceiEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// Org
		/// </summary>
		public string Org { get; set; }



		/// <summary>
		/// Subinv
		/// </summary>
		public string Subinv { get; set; }



		/// <summary>
		/// line
		/// </summary>
		public string line { get; set; }



		/// <summary>
		/// style
		/// </summary>
		public string style { get; set; }



		/// <summary>
		/// StyleCount
		/// </summary>
		public string StyleCount { get; set; }



		/// <summary>
		/// qtyCount
		/// </summary>
		public string qtyCount { get; set; }



		/// <summary>
		/// receiInDate
		/// </summary>
		public string receiInDate { get; set; }



		/// <summary>
		/// status
		/// </summary>
		public string status { get; set; }



		/// <summary>
		/// ScanQtyCount
		/// </summary>
		public string ScanQtyCount { get; set; }



		/// <summary>
		/// DifferenceQtyCount
		/// </summary>
		public string DifferenceQtyCount { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}