using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlockbusterInc.Models;

namespace BlockbusterInc.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ViewResult Index()
        {
            var customerList = GetCustomers();

            return View(customerList);
        }

        // GET : Customers/Details/1
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // Hard coding a customer list to use in the view
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Locke", MoviesRented = 2 },
                new Customer { Id = 2, Name = "Rachel Greene", MoviesRented = 7 },
                new Customer { Id = 3, Name = "Monica Geller", MoviesRented = 6 },
                new Customer { Id = 4, Name = "Joey Tribbiani", MoviesRented = 3 },
                new Customer { Id = 5, Name = "Jack Sheppard", MoviesRented = 1 },
                new Customer { Id = 6, Name = "Katie Blanch", MoviesRented = 0 },
                new Customer { Id = 7, Name = "Adam Lambert", MoviesRented = 0 },
                new Customer { Id = 8, Name = "Paul Rudd", MoviesRented = 12 },
                new Customer { Id = 9, Name = "Stevie Rogers", MoviesRented = 3 },
                new Customer { Id = 10, Name = "Robert Pattinson", MoviesRented = 5 }
            };
        }
    }
}