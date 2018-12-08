using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyPrototype.Dtos;
using VidlyPrototype.Models;

namespace VidlyPrototype.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalsDto newRentals)
        {
            var customer = _context.Customers.Single(m => m.Id == newRentals.CustomerId);

            var movies = _context.Movies.Where(m => newRentals.MovieIds.Contains(m.Id));

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("This movie is not available at the moment");

                movie.NumberAvailable--;

                var rental = new NewRentals
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.NewRentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
