using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
			var movie = _context.Movies.ToList();

			return View(movie);
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		[HttpPost]
		public ActionResult Create(Movie movie)
		{
			_context.Movies.Add(movie);

			_context.SaveChanges();

			return RedirectToAction("Index","Movie");
		}

		public ActionResult New()
		{
			return View();
		}

		// attribute routing
		[Route("movies/released/{year:range(2010, 2020)}/{month:regex(\\d{2}):range(1,12)}")] // set the constraints to the params
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content("hello freinds and fans");
			
		}
		
	}
}