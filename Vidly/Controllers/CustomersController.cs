﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
			var customer = _context.Customers.ToList();

             return View(customer);

		}

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
		protected override void Dispose(bool disposing)
		{

			_context.Dispose();
		}

		
	}
}