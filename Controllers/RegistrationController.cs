using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Product.Services.Enum.@enum;

namespace Product.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            WebSiteEntities Context = new WebSiteEntities();
            ViewBag.message = TempData["message"];
            return View(new Customer());
        }
        public ActionResult GetData(Customer customer, string confirmPassword)
        {
            var result = RegisterHandler(customer, confirmPassword);
            if (result == Status.Success)
            {
                TempData["message"] = "Your infromatin is saved sucessfully!";
                return RedirectToAction("Index");
            }
            else
            {
                return View("registerErrorHandler");
            }
            
        }
        private Status RegisterHandler(Customer customerinput, string confirmpass)
        {
            WebSiteEntities Context = new WebSiteEntities();
            var query = from row in Context.Customers
                        where row.Email == customerinput.Email
                        select row;
            if (query.Count() == 0)
            {
                try
                {
                    Customer newcustomer = new Customer();
                    newcustomer.Email = customerinput.Email;
                    newcustomer.Name = customerinput.Name;
                    newcustomer.lastName = customerinput.lastName;
                    newcustomer.Passwords = customerinput.Passwords;
                    newcustomer.ConfirmPassword = confirmpass;
                    newcustomer.PhoneNumber = customerinput.PhoneNumber;
                    newcustomer.is_active = false;
                    Context.Customers.Add(newcustomer);

                    Context.SaveChanges();
                    return Status.Success;
                }
                catch
                {
                    return Status.Falid; 
                }
            }
            else
            {
                return Status.Falid; 
            }

        }
    }
}
