
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using WebAPI.Sabrina.barcodeScan;

namespace  WebAPI.Sabrina.barcodeScan.Dtos
{
    public class invEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// TagNumber
		/// </summary>
		public string TagNumber { get; set; }



		/// <summary>
		/// Cust_id
		/// </summary>
		public string Cust_id { get; set; }



		/// <summary>
		/// Location
		/// </summary>
		public string Location { get; set; }



		/// <summary>
		/// Update_date
		/// </summary>
		public DateTime Update_date { get; set; }



		/// <summary>
		/// Org
		/// </summary>
		public string Org { get; set; }



		/// <summary>
		/// Create_pc
		/// </summary>
		public string Create_pc { get; set; }



		/// <summary>
		/// KG
		/// </summary>
		public float? KG { get; set; }



		/// <summary>
		/// Subinv
		/// </summary>
		public string Subinv { get; set; }



		/// <summary>
		/// Scantime
		/// </summary>
		public DateTime Scantime { get; set; }



		/// <summary>
		/// ExeStatus
		/// </summary>
		public string ExeStatus { get; set; }



		/// <summary>
		/// Con_no
		/// </summary>
		public string Con_no { get; set; }




    }
}