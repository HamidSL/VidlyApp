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

        [Required(ErrorMessageResourceType = typeof(Resources.Controller_Movies_Form), ErrorMessageResourceName = "name_required")]
        public string Name { get; set; }

        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name="Number In Stock")]
        [Range(1, 50, ErrorMessageResourceType = typeof(Resources.Controller_Movies_Form), ErrorMessageResourceName = "num_in_stock")]
        public byte NoInStock { get; set; }

        public byte NumberAvailable { get; set; }

        //Movies Table Relationship with MovieGenres
        [Display(Name="Movie Genres")]
        [Required(ErrorMessageResourceType = typeof(Resources.Controller_Movies_Form), ErrorMessageResourceName = "movie_genre_required")]
        public int MovieGenresId { get; set; }

        public MovieGenres MovieGenres { get; set; }

        //TMdb data from api
        public int? TMdbId { get; set; }

        public string PosterImage { get; set; }

        public string Summary { get; set; }
        //default values 
        public Movie()
        {
            DateAdded = DateTime.Now;
            NumberAvailable = NoInStock;
        }
    }
}