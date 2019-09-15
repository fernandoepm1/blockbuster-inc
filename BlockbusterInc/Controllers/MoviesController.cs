using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlockbusterInc.ViewModels;
using BlockbusterInc.Models;

namespace BlockbusterInc.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ViewResult Index()
        {
            var movieList = GetMovies();

            return View(movieList);
        }

        // GET: Movies/Edit/1
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            // Methods of passing data to the view
            // ViewData["Movie"] = movie; not recommended
            // ViewBag.Movie = movie; not recommended

            var movie = new Movie() { Title = "Shrek 2" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" },
                new Customer { Name = "Customer 3" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            // var viewResult = new ViewResult();
            // viewResult.ViewData.Model;
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);

            // Methods of outputs to an action in a controller

            // Returns plain content in the view
            // return Content("Hello world!");

            // Returns the 404 Error - HTTP Not Found default page
            // return HttpNotFound();

            // Returns an empty page
            // return new EmptyResult();

            // Returns a redirect to an action in a controller
            // RedirectToAction("ActionName", "ControllerName");
            // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        // GET: Movies/Teste
        public ActionResult Teste(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Title";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

            // var movie = new Movie() { Id = 1, Name = "Die Hard" };
            // return View(movie);
        }

        // Private method to get all hard coded movies to use in a view
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Title = "Die Hard", Genre = "Action" },
                new Movie { Id = 2, Title = "Twilight", Genre = "Romance" },
                new Movie { Id = 3, Title = "A Beautiful Mind", Genre = "Drama" },
                new Movie { Id = 4, Title = "Tropic Thunder", Genre = "Comedy" },
                new Movie { Id = 5, Title = "Inception", Genre = "Action" }
            };
        }
    }
}
