

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.Invrecei;

namespace WebAPI.Sabrina.Invrecei.Dtos
{
    public class CreateOrUpdateInvreceiInput
    {
        [Required]
        public InvreceiEditDto Invrecei { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}