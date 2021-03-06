
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using WebAPI.Sabrina.Locations;

namespace  WebAPI.Sabrina.Locations.Dtos
{
    public class LocationsEditDto
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
		/// Location
		/// </summary>
		public string Location { get; set; }



		/// <summary>
		/// L_Size
		/// </summary>
		public float L_Size { get; set; }



		/// <summary>
		/// X_location
		/// </summary>
		public string X_location { get; set; }



		/// <summary>
		/// Y_location
		/// </summary>
		public string Y_location { get; set; }



		/// <summary>
		/// Create_pc
		/// </summary>
		public string Create_pc { get; set; }



		/// <summary>
		/// Update_date
		/// </summary>
		public string Update_date { get; set; }




    }
}