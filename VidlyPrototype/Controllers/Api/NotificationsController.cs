using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyPrototype.Models;
using System.Data.Entity;
using VidlyPrototype.Dtos;
using AutoMapper;

namespace VidlyPrototype.Controllers.Api
{
    public class NotificationsController : ApiController
    {
        ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult SendNotifications(NotificationsDto notificationsDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == notificationsDto.UserId);
            if (user == null)
                return BadRequest();

            var movie = _context.Movies.SingleOrDefault(m => m.Id == notificationsDto.MovieId);
            if (movie == null)
                return BadRequest();

            var rentals = _context.UserRentals.SingleOrDefault(u => u.Movie.Id == notificationsDto.MovieId && u.Users.Id == notificationsDto.UserId);
            int dateDifference = 0;

            if (rentals == null)
                return BadRequest();

            dateDifference = rentals.DateReturned.HasValue ? Convert.ToInt32(rentals.DateReturned.Value.Subtract(DateTime.Now).TotalDays) : 0;

            if (notificationsDto.Message == null)
                notificationsDto.Message = string.Format("Your rental subscription for the movie {0} ends in {1} days", rentals.Movie.Name.ToUpper(), dateDifference);

            var notify = new Notifications
            {
                DateReceived = DateTime.Now,
                Movie = movie,
                User = user,
                Message = notificationsDto.Message,
                HasBeenRead = false

            };


            _context.Notifications.Add(notify);
            _context.SaveChanges();


            return Ok();
        }

        //GET api/notifications/x/1
        public IHttpActionResult GetNotifications(string userId, int movieId)
        {
            var notifiedData = _context.Notifications.SingleOrDefault(n => n.MovieId == movieId && n.UserId == userId);

            if (notifiedData == null)
                return NotFound();

            return Ok(Mapper.Map<Notifications, NotificationsDto>(notifiedData));
                
        }

        //GET api/notifications
        public IEnumerable<NotificationsDto> GetNotifications()
        {
            var notifications = _context.Notifications.Where(n => n.User.UserName == User.Identity.Name && n.HasBeenRead == false).OrderByDescending(n => n.DateReceived)
                                .Select(Mapper.Map<Notifications, NotificationsDto>);
            

            return notifications;
        }

        //what will we pass in
        //user id only which will in turn check for all notifications belonging to that user id and mark them as read and then add date
        [HttpPut]
        public IHttpActionResult SetAllToRead()
        {
            var setToRead = _context.Notifications.SingleOrDefault(n => n.User.UserName == User.Identity.Name);

            if (setToRead == null)
                return NotFound();

            setToRead.HasBeenRead = true;
            setToRead.DateRead = DateTime.Now;

            _context.SaveChanges();

            return Ok();
        }
    }
}
