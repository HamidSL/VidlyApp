using AutoMapper;
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
            //what we have to do, check if rentals exists in the db, if exists with the same movie and username, deny rentals else accept
            var user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null)
                return Content(HttpStatusCode.BadRequest, "Access Denied! Please Log In To Perform This Action");

            var movie = _context.Movies.SingleOrDefault(m => userRentalsDto.MovieId == m.Id);

            //if (movie.NumberAvailable == 0)
            //    return Content(HttpStatusCode.BadRequest, "Movie is not available at");

            //movie.NumberAvailable--;

            //check if user and movie exists in user rentals already
            var rentalExists = _context.UserRentals.SingleOrDefault(r => r.Users.Id == user.Id && r.Movie.Id == userRentalsDto.MovieId);

            //if rentals exists is not  equal to null
            if (rentalExists != null)
                return Content(HttpStatusCode.BadRequest, "You already have this movie in your rentals list");

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

        
        //GET api/notifications/1
        public IHttpActionResult GetUserRentals(int id)
        {
            var notifiedData = _context.UserRentals.SingleOrDefault(n => n.Movie.Id == id && n.Users.UserName == User.Identity.Name);

            if (notifiedData == null)
                return NotFound();

            return Ok(Mapper.Map<UserRentals, UserRentalsDto>(notifiedData));

        }

    }
}
