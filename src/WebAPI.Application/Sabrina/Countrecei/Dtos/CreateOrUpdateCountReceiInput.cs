

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.Countrecei;

namespace WebAPI.Sabrina.Countrecei.Dtos
{
    public class CreateOrUpdateCountReceiInput
    {
        [Required]
        public CountReceiEditDto CountRecei { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}