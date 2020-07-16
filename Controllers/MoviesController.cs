using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // public ActionResult Edit(int id)
        // {
        //     return Content("Id" + id);
        // }
        //
        // /*
        //  * LIST OF CONSTRAINTS
        //  * min
        //  * max
        //  * minlength
        //  * maxlength
        //  * int
        //  * float
        //  * guid
        //  *
        //  * For more google : ASP.NET MVC Attribute Route Constraints
        //  */
        //
        // // [Route("movies/released/{year}/{month:regex(\\d{4})}")]
        // // [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        // public ActionResult ByReleaseDate(int year, int month)
        // {
        //     return Content(year + "/" + month);
        // }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie { Id = 1, Name = "Hello World" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Movie 1"},
                new Customer {Name = "Movie 2"}
            };
        
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customer = customers
            };
        
            return View(viewModel);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Genres = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.DateUpdated = DateTime.Now;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }
    }
}