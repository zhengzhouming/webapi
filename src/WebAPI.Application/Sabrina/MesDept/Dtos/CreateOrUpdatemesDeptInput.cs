

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.MesDept;

namespace WebAPI.Sabrina.MesDept.Dtos
{
    public class CreateOrUpdateMesDeptInput
    {
        [Required]
        public MesDeptEditDto MesDept { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}