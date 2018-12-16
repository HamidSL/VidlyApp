using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyPrototype.Dtos
{
    public class UserRentalsDto
    {
        [Required]
        public string UserId { get; set; }

        public int MovieId { get; set; }
    }
}