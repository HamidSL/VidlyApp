using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyPrototype.Models;

namespace VidlyPrototype.ViewModels
{
    public class InitialViewModel
    {
        public Movie Movies { get; set; }
        public List<Customer> Customers { get; set; }

    }
}