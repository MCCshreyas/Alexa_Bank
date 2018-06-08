using System.Linq;
using System.Web.Mvc;
using Alexa_Server;

namespace Web_Api_Alexa.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get method for registration page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Post method for form handling 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new CustomerDBContext())
                    {
                        customer.Account_number = AlexaService.GenerateNewAccountNumber().ToString();

                        customer.Balance = "500";
                        db.Customers.Add(customer);
                        db.SaveChanges();
                    }

                    ModelState.Clear();
                    ViewBag.Message = "Account Created sucessfully";
                }
            }
            catch (System.Exception e)
            {

                throw;
            }
            return View();
        }


        /// <summary>
        /// Get method for login page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Post method for form handling for login operation
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            using (var db = new CustomerDBContext())
            {
                var user = db.Customers.Where(u => u.Account_number == customer.Account_number && u.Password == customer.Password).FirstOrDefault();

                if (user != null)
                {
                    Session["AccountNumber"] = user.Account_number.ToString();
                    Session["Name"] = user.Name.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Account number or password does not match. Try again");
                }
            }
            return View();
        }


        public ActionResult LoggedIn()
        {
            if (Session["AccountNumber"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }
    }
}