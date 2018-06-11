using System.Linq;
using System.Web.Mvc;
using Alexa_Server;

namespace Web_Api_Alexa.Controllers
{
    public class AccountController : Controller
    {
        private CustomerDBContext context = new CustomerDBContext();
        
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
            using (context = new CustomerDBContext())
            {
                customer.Account_number = AlexaService.GenerateNewAccountNumber().ToString();

                customer.Balance = "500";
                context.Customers.Add(customer);
                context.SaveChanges();
            }

            ModelState.Clear();
            ViewBag.Message = "Account Created sucessfully. Account number has been sent to your Registered email address";

            AlexaService.SendAccountConfirmationMail(customer.Email.ToString(), customer.Account_number);
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
            using (context = new CustomerDBContext())
            {
                var user = context.Customers.Where(u => u.Account_number == customer.Account_number && u.Password == customer.Password).FirstOrDefault();

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