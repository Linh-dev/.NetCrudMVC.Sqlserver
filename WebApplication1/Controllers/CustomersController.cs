using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Crud;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        CrudCustomer strCustomer = new CrudCustomer();
        // GET: Customers
        public ActionResult Index()
        {
            
            List<Customer> customers = strCustomer.getCustomers(string.Empty);
            return View(customers);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                strCustomer.Create(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string id="")
        {
            List<Customer> customers = strCustomer.getCustomers(id);
            return View(customers.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            strCustomer.Edit(customer);
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(string id)
        {
            strCustomer.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id = "")
        {
            List<Customer> customers = strCustomer.getCustomers(id);
            return View(customers.FirstOrDefault());
        }
    }

}