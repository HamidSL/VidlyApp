using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyPrototype.Models;

namespace VidlyPrototype.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipTypes> MembershipTypes { get; set; }
        public Customer Customers { get; set; }
    }
}