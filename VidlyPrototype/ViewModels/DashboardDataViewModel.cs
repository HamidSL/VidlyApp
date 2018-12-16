using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyPrototype.Models;

namespace VidlyPrototype.ViewModels
{
    public class DashboardDataViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Movie> Movies { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<NewRentals> Rentals { get; set; }
        public List<UserRentals> UserRentals { get; set; }
        public int TotalRentals { get; set; }
    }
}