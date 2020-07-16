

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Sabrina.barcodeScan;

namespace WebAPI.Sabrina.barcodeScan.Dtos
{
    public class CreateOrUpdateinvInput
    {
        [Required]
        public invEditDto inv { get; set; }

    }
}