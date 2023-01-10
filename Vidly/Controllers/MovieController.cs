using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
	public class MovieController : Controller
	{
		//
		// GET: /Movie/

		private ApplicationDbContext _context;
		public MovieController()
		{
			_context = new ApplicationDbContext();


		}
		public ViewResult Index()
		{
            //var movie = _context.Movies.Include("Genre").ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("MoviesList");
			
            return View("ReadOnlyMovies");
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		[HttpPost]
		public ActionResult Save(Movie movie)
		{
            // 2nd step to validate form state 
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0) { _context.Movies.Add(movie); }
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.NumberAvailable = movie.NumberAvailable;

            }
            _context.SaveChanges();

			return RedirectToAction("Index","Movie");
		}

        [Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult New()
		{
			var genres = _context.Genres.ToList();
			var movies = new MovieFormViewModel
			{
                Movie = new Movie{
                    ReleaseDate = DateTime.MinValue,
                },
				Genres = genres
			};
			return View("MovieForm", movies);
		}

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) { return HttpNotFound(); }
            var movieModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", movieModel);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include("Genre").SingleOrDefault(m => m.Id == Id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }

		// attribute routing
		[Route("movies/released/{year:range(2010, 2020)}/{month:regex(\\d{2}):range(1,12)}")] // set the constraints to the params
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content("hello freinds and fans");
			
		}
		
	}
}