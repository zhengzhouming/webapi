
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using WebAPI.Sabrina.Recei;


namespace  WebAPI.Sabrina.Recei.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="Recei"/>
	/// </summary>
    public class ReceiEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
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
		/// style
		/// </summary>
		public string style { get; set; }



		/// <summary>
		/// color
		/// </summary>
		public string color { get; set; }



		/// <summary>
		/// size
		/// </summary>
		public string size { get; set; }



		/// <summary>
		/// qtyCount
		/// </summary>
		public int? qtyCount { get; set; }



		/// <summary>
		/// po
		/// </summary>
		public string po { get; set; }



		/// <summary>
		/// boxCount
		/// </summary>
		public string boxCount { get; set; }



		/// <summary>
		/// receiNumber
		/// </summary>
		public string receiNumber { get; set; }



		/// <summary>
		/// receiDate
		/// </summary>
		public string receiDate { get; set; }



		/// <summary>
		/// receiEmp
		/// </summary>
		public string receiEmp { get; set; }



		/// <summary>
		/// mark
		/// </summary>
		public string mark { get; set; }



		/// <summary>
		/// receiInDate
		/// </summary>
		public string receiInDate { get; set; }



		/// <summary>
		/// receiInPcName
		/// </summary>
		public string receiInPcName { get; set; }



		/// <summary>
		/// isFull
		/// </summary>
		public int isFull { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}