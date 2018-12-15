using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyPrototype.Models;

namespace VidlyPrototype.ViewModels
{
    public class MovieRentalsShowViewModel
    {
        public Movie Movies { get; set; }
        public List<NewRentals> Rentals { get; set; }
    }
}