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
            var DateData = _context.UserRentals.Include(u => u.Movie).Include(u => u.Users).ToList();

            //date returned, user data, movie data
            foreach(var data in DateData)
            {
                if (data.DateReturned.HasValue)
                {
                    var dateDifference = data.DateReturned.Value.Subtract(DateTime.Now);

                    if(int.Parse(dateDifference.TotalDays.ToString()) <= 5)
                    {
                        //send message
                        var notification = new Notifications
                        {
                            DateReceived = DateTime.Now,
                            DateRead = DateTime.Now,
                            HasBeenRead = false,
                            User = data.Users,
                            UserId = data.Users.Id,
                            Message = "You have " + int.Parse(dateDifference.TotalDays.ToString()) + " left to return " + data.Movie.Name.ToUpper(),
                        };

                        //add to db
                        _context.Notifications.Add(notification);
                    }
                }
            }
            _context.SaveChanges();

            return Ok();
        }

        //GET api/notifications
        public IEnumerable<NotificationsDto> GetNotifications()
        {
            var notifications = _context.Notifications.Include(n => n.User)
                    .Where(n => n.User.UserName == User.Identity.Name).ToList().Select(Mapper.Map<Notifications, NotificationsDto>);

            return notifications;

            //return _context.Notifications.Include(m => m.User).ToList()
            //        .Select(Mapper.Map<Rentals, RentalsDto>);
        }
    }
}
