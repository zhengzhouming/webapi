

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.Conppr;

namespace WebAPI.Sabrina.Conppr.Dtos
{
    public class ConPprListDto : EntityDto<long> 
    {

        
		/// <summary>
		/// Cust_id
		/// </summary>
		public string Cust_id { get; set; }



		/// <summary>
		/// Serial_From
		/// </summary>
		public string Serial_From { get; set; }



		/// <summary>
		/// Qty
		/// </summary>
		public int Qty { get; set; }



		/// <summary>
		/// Org
		/// </summary>
		public string Org { get; set; }



		/// <summary>
		/// PPrfNo
		/// </summary>
		public string PPrfNo { get; set; }



		/// <summary>
		/// Count1
		/// </summary>
		public int Count1 { get; set; }



		/// <summary>
		/// Create_Pc
		/// </summary>
		public string Create_Pc { get; set; }



		/// <summary>
		/// Update_Date
		/// </summary>
		public DateTime Update_Date { get; set; }



		/// <summary>
		/// Con_no
		/// </summary>
		public int Con_no { get; set; }



		/// <summary>
		/// Country_Code
		/// </summary>
		public string Country_Code { get; set; }



		/// <summary>
		/// Con_To
		/// </summary>
		public int Con_To { get; set; }



		/// <summary>
		/// Pkg_Code
		/// </summary>
		public string Pkg_Code { get; set; }



		/// <summary>
		/// Scan_ID
		/// </summary>
		public string Scan_ID { get; set; }



		/// <summary>
		/// Net_Net
		/// </summary>
		public float Net_Net { get; set; }



		/// <summary>
		/// Con_Net
		/// </summary>
		public float Con_Net { get; set; }



		/// <summary>
		/// Con_Gross
		/// </summary>
		public float Con_Gross { get; set; }



		/// <summary>
		/// Con_L
		/// </summary>
		public float Con_L { get; set; }



		/// <summary>
		/// Con_W
		/// </summary>
		public float Con_W { get; set; }



		/// <summary>
		/// Con_H
		/// </summary>
		public float Con_H { get; set; }



		/// <summary>
		/// B_Volume
		/// </summary>
		public float B_Volume { get; set; }



		/// <summary>
		/// PO
		/// </summary>
		public float PO { get; set; }



		/// <summary>
		/// MAIN_LINE
		/// </summary>
		public float MAIN_LINE { get; set; }



		/// <summary>
		/// PPR_id
		/// </summary>
		public string PPR_id { get; set; }




    }
}