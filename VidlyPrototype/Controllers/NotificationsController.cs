using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyPrototype.Models;
using System.Data.Entity;

namespace VidlyPrototype.Controllers
{
    public class NotificationsController : Controller
    {
        ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        // GET: UserRentals
        public ActionResult Index()
        {
            var notifications = _context.Notifications.Include(n => n.User).ToList().OrderByDescending(n => n.DateReceived);


            return View(notifications);
        }

        
    }
}