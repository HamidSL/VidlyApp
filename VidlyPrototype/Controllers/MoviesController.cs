using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyPrototype.Models;
using VidlyPrototype.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

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

        public ActionResult Show(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieGenres).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            //Rented Relations
            var rentalsData = _context.NewRentals.Include(r => r.Movie).Include(r => r.Customer).Where(r => r.Movie.Id == id).ToList();

            var viewModel = new MovieRentalsShowViewModel
            {
                Movies = movie,
                Rentals = rentalsData
            };

            return View(viewModel);
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

        async static Task GetMovieData(int id)
        {
            var baseAddress = new Uri("api.themoviedb.org/3/movie/");

            using (HttpClient client = new HttpClient { BaseAddress = baseAddress})
            {

                using (HttpResponseMessage response = await client.GetAsync(id + "?api_key=7538a1ba766c36605ab0e8e10bab23da"))
                {

                    using(HttpContent content = response.Content)
                    {
                        string MovieData = await content.ReadAsStringAsync();

                        
                    }
                }
            }
        }

        //POST: Save movie data
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.IsAdministrator)]
        public ActionResult Save(MovieViewModel movie)
        {
            var baseAddress = new Uri("https://api.themoviedb.org/3/movie/");

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
            {
                if(movie.Movies.TMdbId == null)
                {
                    movie.Movies.NumberAvailable = movie.Movies.NoInStock;
                    _context.Movies.Add(movie.Movies);
                }              
                else
                {
                    using (HttpClient client = new HttpClient { BaseAddress = baseAddress })
                    {

                        using (HttpResponseMessage response = client.GetAsync(movie.Movies.TMdbId.Value + "?api_key=7538a1ba766c36605ab0e8e10bab23da").Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                using (HttpContent content = response.Content)
                                {

                                    JavaScriptSerializer javascriptSerializer = new JavaScriptSerializer();
                                    var movieData = content.ReadAsStringAsync().Result;

                                    var moreData = JsonConvert.DeserializeObject<dynamic>(movieData);

                                    //return Content(moreData.backdrop_path.ToString());

                                    movie.Movies.TMdbId = movie.Movies.TMdbId.Value;
                                    movie.Movies.PosterImage = moreData.poster_path.ToString();
                                    movie.Movies.Summary = moreData.overview.ToString();
                                    movie.Movies.Name = moreData.title.ToString();
                                    movie.Movies.ReleaseDate = Convert.ToDateTime(moreData.release_date.ToString());
                                    movie.Movies.NumberAvailable = movie.Movies.NoInStock;
                                    //if (moreData.release_date.ToString() != "")
                                    //{
                                    //    movie.Movies.ReleaseDate = (DateTime)moreData.release_date.ToString();
                                    //}

                                    _context.Movies.Add(movie.Movies);
     
                                }

                            }
                            else
                            {
                                ViewBag.Result = "Error";
                            }
                        }
                    }
                }
            }  
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