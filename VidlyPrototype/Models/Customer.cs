using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyPrototype.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name ="Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        //Relationship to MembershipTypes Table
        public MembershipTypes MembershipTypes { get; set; }

        [Display(Name="Membership Type")]
        public int MembershipTypesId { get; set; }
    }
}