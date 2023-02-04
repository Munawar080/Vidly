using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.DTOs;
using AutoMapper;
using System.Data.Entity;
namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
       {
            var customersQuery =  _context.Customers
                .Include(m => m.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

                var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);

                return Ok(customerDtos);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null) return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        
        // POST /api/customers/1
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerdto)
        {
            // first need to do mapping
            var customer = Mapper.Map<CustomerDTO, Customer>(customerdto);
            if (!ModelState.IsValid) return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            // get newly generated ID into the server
            customerdto.Id = customer.Id;
            //return customerdto;
            return Created(new Uri(Request.RequestUri + "/" + customerdto.Id), customerdto);
        }

        //update customer to database
        // PUT /api/customers/1
        public void UpdateCustomer(int Id, CustomerDTO customerdto)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == Id);

            // check to DB requested customer exist or not
            if (customerInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            //customerInDB.Name = customer.Name;
            //customerInDB.BirthDate = customer.BirthDate;
            //customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //customerInDB.MembershipTypeId = customer.MembershipTypeId;

            Mapper.Map<CustomerDTO, Customer>(customerdto, customerInDB);

            _context.SaveChanges();
        
        }

        // DELETE /api/customers/1
        public void DeleteCustomer(int Id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDB);

            _context.SaveChanges();
           
        }



    }
}
