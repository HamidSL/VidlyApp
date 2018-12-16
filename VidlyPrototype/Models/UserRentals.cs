using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyPrototype.Models;

namespace VidlyPrototype.Models
{
    public class UserRentals
    {
        public int Id { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public ApplicationUser Users { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}