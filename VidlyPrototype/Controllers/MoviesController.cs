using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyPrototype.Models;
using VidlyPrototype.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace VidlyPrototype.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.MovieGenres).ToList();

            var custId = User.Identity.GetUserId();

            if(User.IsInRole(RoleName.IsAdministrator))
                return View("Index", movies);

            return View("ReadOnlyIndex", movies);
        }

        //GET: Display create movie form
        [Authorize(Roles = RoleName.IsAdministrator)]
        public ActionResult Create()
        {
            var movieGenres = _context.MovieGenres.ToList();

            var viewModel = new MovieViewModel
            {
                Movies = new Movie(),
                MovieGenres = movieGenres
            };

            return View("MoviesForm", viewModel);
        }

        //POST: Save movie data
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.IsAdministrator)]
        public ActionResult Save(MovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel
                {
                    MovieGenres = _context.MovieGenres.ToList(),
                    Movies = movie.Movies
                };

                return View("MoviesForm", viewModel);
            }

            if(movie.Movies.Id == 0)
                _context.Movies.Add(movie.Movies);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Movies.Id);

                movieInDb.Name = movie.Movies.Name;
                movieInDb.ReleaseDate = movie.Movies.ReleaseDate;
                movieInDb.MovieGenresId = movie.Movies.MovieGenresId;
                movieInDb.NoInStock = movie.Movies.NoInStock;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        //GET: Edit movie details
        [Authorize(Roles = RoleName.IsAdministrator)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieViewModel
            {
                Movies = movie,
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View("MoviesForm", viewModel);
        }

        //GET:Details
        //public ActionResult Details(int id)
        //{
        //    var movie = _context.Movies.Include(m => m.MovieGenres).SingleOrDefault(m => m.Id == id);

        //    if (movie == null)
        //        return HttpNotFound();

        //    return View(movie);
        //}
    }
}