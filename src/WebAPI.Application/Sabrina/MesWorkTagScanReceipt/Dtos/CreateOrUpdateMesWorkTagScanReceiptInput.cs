

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.MesWorkTagScanReceipt;

namespace WebAPI.Sabrina.MesWorkTagScanReceipt.Dtos
{
    public class CreateOrUpdateMesWorkTagScanReceiptInput
    {
        [Required]
        public MesWorkTagScanReceiptEditDto MesWorkTagScanReceipt { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}