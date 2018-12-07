using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyPrototype.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 50)]
        public byte NoInStock { get; set; }

        public MovieGenresDto MovieGenres { get; set; }

        public int MovieGenresId { get; set; }

        public MovieDto()
        {
            DateAdded = DateTime.Now;
        }



    }
}