

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.Details;

namespace WebAPI.Sabrina.Details.Dtos
{
    public class CreateOrUpdateDetailsInput
    {
        [Required]
        public DetailsEditDto Details { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}