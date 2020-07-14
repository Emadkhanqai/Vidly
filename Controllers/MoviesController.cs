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
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
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
            var movies = _context.Movies.Include(m => m.Genre);
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}