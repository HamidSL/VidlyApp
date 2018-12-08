using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyPrototype.Models;

namespace VidlyPrototype.Dtos
{
    public class RentalsDto
    {
        public int Id { get; set; }

        //Relationships
        public CustomerDto Customers { get; set; }
        
        public int CustomerId { get; set; }

        public MovieDto Movies { get; set; }
        
        public int MovieId { get; set; }
        //End of Relationships

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

        public RentalsDto()
        {
            DateRented = DateTime.Now;
        }
    }
}