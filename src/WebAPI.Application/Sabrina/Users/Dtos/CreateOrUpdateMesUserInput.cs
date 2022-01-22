

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.Users;

namespace WebAPI.Sabrina.Users.Dtos
{
    public class CreateOrUpdateMesUserInput
    {
        [Required]
        public MesUserEditDto MesUser { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}