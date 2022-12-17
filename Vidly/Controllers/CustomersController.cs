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
	public class CustomersController : Controller
	{
		//
		// GET: /Customers/

		//[Route("Customer/show")]
		private ApplicationDbContext _context;
		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		
		public ViewResult Index()
		{

			var customer = _context.Customers.Include("MembershipType").ToList();
			return View(customer);

		}

		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		public ActionResult New()
		{
			// initialize membership type
			var MembershipType = _context.MembershipTypes.ToList();
			var customer = new CustomerFormViewModel
			{
				MembershipTypes = MembershipType
			};
			return View("CustomerForm", customer);
		}

		public ActionResult Edit(int Id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

			if (customer == null) return HttpNotFound();

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};

			return View("CustomerForm", viewModel);
		}

		[HttpPost]
		public ActionResult Save(Customer customer)
		{
            if (customer.Id == 0) { _context.Customers.Add(customer); }
            else
            {
			    var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

			    customerInDB.Name = customer.Name;
			    customerInDB.BirthDate = customer.BirthDate;
			    customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			    customerInDB.MembershipTypeId = customer.MembershipTypeId;

            }
           


			_context.SaveChanges();
			
			return RedirectToAction("Index", "Customers");
		}
		protected override void Dispose(bool disposing)
		{

			_context.Dispose();
		}

		
	}
}