using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viidly.Models;
using Viidly.ViewModels;
namespace Viidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        //constructor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ViewResult Index()
        {
            return View();
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
            var membershipTypes = _context.membershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.membershipTypes.ToList()
                };
                return View("CustomerForm", viewmodel);
            }
            if(customer.Id == 0)
            _context.Customers.Add(customer);
            else
            {
                var CustomerInDb = _context.Customers.Single( c=> c.Id == customer.Id);
                CustomerInDb.Name = customer.Name;
                CustomerInDb.Birthdate = customer.Birthdate;
                CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
                CustomerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit( int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.membershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }
    }
}