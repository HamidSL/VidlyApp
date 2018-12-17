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
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Message { get; set; }

        public int MovieId { get; set; }

        public DateTime DateReceived { get; set; }


    }
}