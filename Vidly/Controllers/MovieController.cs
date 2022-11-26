using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
namespace Vidly.Controllers
{
	public class MovieController : Controller
	{
		//
		// GET: /Movie/
		public ViewResult Index()
		{
            var movie = new Movie() { Id = "MV1", Name = "Matrix" };

            var customer = new List<Customer> {
                new Customer {Name= "customer1"},
                new Customer {Name="customer2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movies = movie,
                Customers = customer
            };

            return View(viewModel);
            //return Content("movie controller");
            //return Content("hello bai sabb");
			//return HttpNotFound();
			//return RedirectToAction("Index", "Home", new { page = 1, sortByOrder = "ascending" });
		}


        // attribute routing
        [Route("movies/released/{year:range(2010, 2020)}/{month:regex(\\d{2}):range(1,12)}")] // set the constraints to the params
        public ActionResult ByReleaseDate(int year, int month)
		{
            return Content("hello freinds and fans");
            
		}
		
	}
}