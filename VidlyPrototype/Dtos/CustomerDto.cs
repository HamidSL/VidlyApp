using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyPrototype.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public MembershipTypesDto MembershipTypes { get; set; }

        public int MembershipTypesId { get; set; }
    }
}