using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_Api_Alexa.Controllers
{
    public class CustomerController : ApiController
    {
        private const string ErrorMessage = "Something went wrong";


        private readonly CustomerDBContext _db = new CustomerDBContext();

        [Route("api/Customer")]
        [HttpGet]
        public IQueryable<Customer> Get()
        {
            return _db.Customers;
        }

        [Route("api/Customer/{id}")]
        [HttpGet]
        public Customer Get(string id)
        {
            var c = _db.Customers.FirstOrDefault(i => i.Account_number == id);
            if (c != null)
            {
                return c;
            }

            return null;
        }

        [Route("api/Customer/GetAccountNumbers")]
        [HttpGet]
        public List<string> GetAllAccountNumbers()
        {
            var accountNumbers = _db.Customers.Select(x => x.Account_number).ToList();
            return accountNumbers;
        }

        [Route("api/Customer/GetPassword/{accountNumber}")]
        [HttpGet]
        public string GetPasswordByAccountNumber(string accountNumber = "")
        {
            var row = _db.Customers.FirstOrDefault(r => r.Account_number == accountNumber);
            if (row != null)
            {

                return row.Password;
            }

            return ErrorMessage;

        }

        [Route("api/Customer")]
        [HttpPost]
        public HttpResponseMessage Post(Customer newCustomer)
        {
            try
            {
                var newRecord = new Customer
                {
                    Name = newCustomer.Name,
                    Address = newCustomer.Address,
                    Phone_number = newCustomer.Phone_number,
                    Email = newCustomer.Email,
                    Password = newCustomer.Password,
                    Balance = newCustomer.Balance,
                    Account_number = newCustomer.Account_number,
                    ImagePath = newCustomer.ImagePath,
                    Gender = newCustomer.Gender,
                    BirthDate = newCustomer.BirthDate
                };


                _db.Customers.Add(newRecord);
                _db.SaveChanges();
                return Request.CreateErrorResponse(HttpStatusCode.OK,
                    "Customer added sucessfully");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    $"Something went wrong. Problem description : {e.Message}");
            }
        }

        [Route("api/Customer/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] Customer newCustomer)
        {
            try
            {
                var c = _db.Customers.First(i => i.Account_number == id);
                c.Name = newCustomer.Name;
                c.Address = newCustomer.Address;
                c.Phone_number = newCustomer.Phone_number;
                c.Email = newCustomer.Email;
                c.Password = newCustomer.Password;
                c.ImagePath = newCustomer.ImagePath;
                c.Gender = newCustomer.Gender;
                c.BirthDate = newCustomer.BirthDate;

                _db.SaveChanges();

                return Request.CreateErrorResponse(HttpStatusCode.OK,
                    "Customer details updated sucessfully");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    $"Something went wrong. Problem description : {e.Message}");
            }
        }


        [Route("api/Customer/UpdateBalance/{accountNumber}/{balance}")]
        [HttpPut]
        public HttpResponseMessage UpdateBalance(string accountNumber, string balance)
        {
            try
            {
                var customer = (from c in _db.Customers.Where(a => a.Account_number == accountNumber) select c)
                    .FirstOrDefault();


                if (customer != null)
                {
                    customer.Balance = balance;
                    _db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Customer not found");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    $"Something went wrong. Problem description : {e.Message}");
            }
        }


        [Route("api/Customer/{accountNo}")]
        [HttpDelete]
        public HttpResponseMessage Delete(string accountNo)
        {
            try
            {
                var customer = (from d in _db.Customers
                                where d.Account_number == accountNo
                                select d).Single();

                if (customer != null)
                {
                    _db.Customers.Remove(customer);
                    _db.SaveChanges();
                }

                return Request.CreateErrorResponse(HttpStatusCode.OK,
                    "Customer deleted sucessfully");
            }

            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    $"Something went wrong. Problem description : {e.Message}");
            }
        }
    }
}