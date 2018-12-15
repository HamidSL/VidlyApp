using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyPrototype.Models;

namespace VidlyPrototype.ViewModels
{
    public class UserRentalsShowViewModel
    {
        public Customer Customers { get; set; }
        public List<NewRentals> Rentals { get; set; }
    }
}