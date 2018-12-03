using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyPrototype.Models;
using VidlyPrototype.ViewModels;
using System.Data.Entity;

namespace VidlyPrototype.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        //[Route("Customers")]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipTypes).ToList();

            return View(customers);
        }

        //GET: Create Form
        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerViewModel
            {
                Customers = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        //POST: Submit New Customer Creation Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel
                {
                    Customers = customer.Customers,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if(customer.Customers.Id == 0)
                _context.Customers.Add(customer.Customers);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Customers.Id);
            
                customerInDb.Name = customer.Customers.Name;
                customerInDb.DateOfBirth = customer.Customers.DateOfBirth;
                customerInDb.IsSubscribedToNewsletter = customer.Customers.IsSubscribedToNewsletter;
                customerInDb.MembershipTypesId = customer.Customers.MembershipTypesId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        //GET: Edit Form
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);


            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerViewModel
            {
                Customers = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        //GET: Display customer details
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipTypes).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}