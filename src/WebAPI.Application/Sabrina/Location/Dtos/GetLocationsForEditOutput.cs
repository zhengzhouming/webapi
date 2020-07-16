

using System.Collections.Generic;
using Abp.Application.Services.Dto;
using WebAPI.Sabrina.Locations;

namespace WebAPI.Sabrina.Locations.Dtos
{
    public class GetLocationsForEditOutput
    {

        public LocationsEditDto Locations { get; set; }

    }
}