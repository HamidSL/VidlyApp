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
    public class UserRentalsController : ApiController
    {
        ApplicationDbContext _context;

        public UserRentalsController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(UserRentalsDto userRentalsDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null)
                return BadRequest("Access Denied! Please Log In To Perform This Action");

            var movie = _context.Movies.SingleOrDefault(m => userRentalsDto.MovieId == m.Id);

            if (movie.NumberAvailable == 0)
                return BadRequest("Movie is not available at the moment");

            movie.NumberAvailable--;

            var rental = new UserRentals
            {
                DateRented = DateTime.Now,
                DateReturned = DateTime.Now.AddDays(30),
                Movie = movie,
                Users = user
            };

            _context.UserRentals.Add(rental);

            _context.SaveChanges();


            /*
                steps
                user clicks on rent
                js gets user id and movie id
                checks rentals table if user id and movie id exists
                if exists throw error, only one is acceptable
                else check number is available if > 0 continue else throw error not enough
                add to userrentals table
             */
            return Ok();
        }

    }
}
