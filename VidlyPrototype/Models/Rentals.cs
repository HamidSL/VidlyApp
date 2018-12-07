using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyPrototype.Models
{
    public class Rentals
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int MovieId { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

        public Rentals()
        {
            DateRented = DateTime.Now;
        }
    }
}