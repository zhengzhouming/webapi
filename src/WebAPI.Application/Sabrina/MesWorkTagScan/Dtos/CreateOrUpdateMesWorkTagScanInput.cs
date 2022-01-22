

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.MesWorkTagScan;

namespace WebAPI.Sabrina.MesWorkTagScan.Dtos
{
    public class CreateOrUpdateMesWorkTagScanInput
    {
        [Required]
        public MesWorkTagScanEditDto MesWorkTagScan { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}