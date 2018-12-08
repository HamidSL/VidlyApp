using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyPrototype.Dtos;
using VidlyPrototype.Models;
using System.Data.Entity;
using AutoMapper;

namespace VidlyPrototype.Controllers.Api
{
    public class RentalsController : ApiController
    {
        /*
         What will be included? onclick addition of user id and movie id into the db
         */

        ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/rentals
        public IEnumerable<RentalsDto> GetRentals()
        {

            return _context.Rentals.Include(m => m.Customers).Include(m => m.Movies).ToList()
                    .Select(Mapper.Map<Rentals, RentalsDto>);
        }

        //GET api/rentals/1
        public IHttpActionResult GetRentals(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(m => m.Id == id);

            if (rental == null)
                return NotFound();

            return Ok(Mapper.Map<Rentals, RentalsDto>(rental));
        }

        //POST api/rentals //create
        [HttpPost]
        public IHttpActionResult CreateRentals(RentalsDto rentalsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rental = Mapper.Map<RentalsDto, Rentals>(rentalsDto);

            var movie = _context.Movies.Single(m => m.Id == rentalsDto.MovieId);

            if (movie.NumberAvailable == 0)
                return BadRequest("Movie is not available at the moment");

            movie.NumberAvailable--;

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            rentalsDto.Id = rental.Id;

            return Created(new Uri(Request.RequestUri + "/" + rental.Id), rentalsDto);

        }

        //DELETE api/rentals/1
        [HttpDelete]
        public void DeleteRental(int id)
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(m => m.Id == id);

            if (rentalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Rentals.Remove(rentalInDb);
            _context.SaveChanges();
        }

    }
}
