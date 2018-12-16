﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyPrototype.Models;
using System.Data.Entity;
using VidlyPrototype.ViewModels;

namespace VidlyPrototype.Controllers
{
    public class AdministratorController : Controller
    {
        ApplicationDbContext _context;

        public AdministratorController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }

        // GET: Administrator
        public ActionResult Index()
        {
            //customers
            var customers = _context.Customers.Include(c => c.MembershipTypes).OrderByDescending(c => c.Id).ToList();

            //movies
            var movies = _context.Movies.Include(m => m.MovieGenres).OrderByDescending(m => m.DateAdded).ToList();

            //users
            var users = _context.Users.OrderByDescending(u => u.Id).ToList();

            //movies rented
            var moviesRented = _context.Movies.Sum(m => m.NoInStock - m.NumberAvailable);

            //view model
            var viewModel = new DashboardDataViewModel
            {
                Customers = customers,
                Movies = movies,
                Users = users,
            };

            return View("Dashboard", viewModel);
        }

        public ActionResult RentalsManager()
        {
            return View("Rentals");
        }
    }
}