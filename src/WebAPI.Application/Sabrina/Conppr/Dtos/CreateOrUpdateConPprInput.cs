

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.Conppr;

namespace WebAPI.Sabrina.Conppr.Dtos
{
    public class CreateOrUpdateConPprInput
    {
        [Required]
        public ConPprEditDto ConPpr { get; set; }

    }
}