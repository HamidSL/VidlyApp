using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyPrototype.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name="Number In Stock")]
        [Range(1, 50, ErrorMessage ="The Number in Stock value must be between 1 and 50")]
        public byte NoInStock { get; set; }

        //Movies Table Relationship with MovieGenres
        [Display(Name="Movie Genres")]
        public int MovieGenresId { get; set; }

        public MovieGenres MovieGenres { get; set; }

        //default values 
        public Movie()
        {
            DateAdded = DateTime.Now;
        }
    }
}