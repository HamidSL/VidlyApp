using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyPrototype.Models;

namespace VidlyPrototype.Dtos
{
    public class NotificationsDto
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime DateReceived { get; set; }

        public DateTime DateRead { get; set; }

        public bool HasBeenRead { get; set; }
    }
}