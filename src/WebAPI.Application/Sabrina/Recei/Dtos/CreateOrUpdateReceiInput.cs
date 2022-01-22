

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.Recei;

namespace WebAPI.Sabrina.Recei.Dtos
{
    public class CreateOrUpdateReceiInput
    {
        [Required]
        public ReceiEditDto Recei { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}