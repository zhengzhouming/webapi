

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.Locations;

namespace WebAPI.Sabrina.Locations.Dtos
{
    public class CreateOrUpdateLocationsInput
    {
        [Required]
        public LocationsEditDto Locations { get; set; }

    }
}