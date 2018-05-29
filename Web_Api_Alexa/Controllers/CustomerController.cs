using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Web.Http;
using Web_Api_Alexa.Models;

namespace Web_Api_Alexa.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        public List<Customer> Get()
        {
            MySqlConnection connection = WebApiConfig.ConnectDb();
            connection.Open();

            var cmd = new MySqlCommand("SELECT * FROM info", connection);

            var results = new List<Customer>();

            var dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                results.Add(new Customer(
                    dataReader["Name"].ToString(),
                    dataReader["Address"].ToString(),
                    dataReader["Phone_number"].ToString(),
                    dataReader["Email"].ToString(),
                    dataReader["Password"].ToString(),
                    dataReader["Balance"].ToString(),
                    dataReader["Account_number"].ToString(),
                    dataReader["ImagePath"].ToString(),
                    dataReader["Gender"].ToString(),
                    dataReader["BirthDate"].ToString()));
            }

            return results;
        }

        // GET: api/Customer/5
        public Customer Get(string id)
        {
            var connection = WebApiConfig.ConnectDb();
            connection.Open();

            var cmd = new MySqlCommand($"SELECT * FROM info where Account_number = {id} ", connection);

            var dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {

                var result = new Customer(
                    dataReader["Name"].ToString(),
                    dataReader["Address"].ToString(),
                    dataReader["Phone_number"].ToString(),
                    dataReader["Email"].ToString(),
                    dataReader["Password"].ToString(),
                    dataReader["Balance"].ToString(),
                    dataReader["Account_number"].ToString(),
                    dataReader["ImagePath"].ToString(),
                    dataReader["Gender"].ToString(),
                    dataReader["BirthDate"].ToString());
                return result;
            }
            return null;

        }

        // POST: api/Customer
        public void Post(Customer newCustomer)
        {
            var connection = WebApiConfig.ConnectDb();
            connection.Open();
            var command = new MySqlCommand("INSERT INTO info values(@name,@address,@phone_number,@email,@password,@account_number,@balance,@image_path, @gender, @birth_date)", connection);
            command.Parameters.AddWithValue("@name", newCustomer.Name);
            command.Parameters.AddWithValue("@address", newCustomer.Address);
            command.Parameters.AddWithValue("@phone_number", newCustomer.Phone_number);
            command.Parameters.AddWithValue("@email", newCustomer.Email);
            command.Parameters.AddWithValue("@password", newCustomer.Password);
            command.Parameters.AddWithValue("@balance", newCustomer.Balance);
            command.Parameters.AddWithValue("@account_number", newCustomer.Account_number);
            command.Parameters.AddWithValue("@image_path", newCustomer.ImagePath);
            command.Parameters.AddWithValue("@gender", newCustomer.Gender);
            command.Parameters.AddWithValue("@birth_date", newCustomer.BirthDate);


            command.ExecuteNonQuery();


        }

        // PUT: api/Customer/5
        public void Put(string id, [FromBody]Customer updateDetails)
        {
            CustomerController cc = new CustomerController();
            var customer = cc.Get();
            foreach (var item in customer)
            {
                if (id.ToString() == item.Account_number)
                {
                    item.Name = updateDetails.Name;
                    item.Address = updateDetails.Address;
                    item.Phone_number = updateDetails.Phone_number;
                    item.Email = updateDetails.Email;
                    item.Password = updateDetails.Password;
                    item.Balance = updateDetails.Balance;
                    item.ImagePath = updateDetails.ImagePath;
                    item.Gender = updateDetails.Gender;
                    item.BirthDate = updateDetails.BirthDate;

                    var connection = WebApiConfig.ConnectDb();
                    connection.Open();
                    var command = new MySqlCommand($"UPDATE info SET Name=@name, Address=@address , Phone_number=@phone_number , Email=@email , Password=@password, Balance=@balance , ImagePath=@image_path , Gender=@gender , BirthDate = @birth_date where Account_number = {id.ToString()}", connection);
                    command.Parameters.AddWithValue("@name", updateDetails.Name);
                    command.Parameters.AddWithValue("@address", updateDetails.Address);
                    command.Parameters.AddWithValue("@phone_number", updateDetails.Phone_number);
                    command.Parameters.AddWithValue("@email", updateDetails.Email);
                    command.Parameters.AddWithValue("@password", updateDetails.Password);
                    command.Parameters.AddWithValue("@balance", updateDetails.Balance);
                    command.Parameters.AddWithValue("@account_number", updateDetails.Account_number);
                    command.Parameters.AddWithValue("@image_path", updateDetails.ImagePath);
                    command.Parameters.AddWithValue("@gender", updateDetails.Gender);
                    command.Parameters.AddWithValue("@birth_date", updateDetails.BirthDate);


                    command.ExecuteReader();
                    return;


                }
            }

        }


        // DELETE: api/Customer/5
        public void Delete(string id)
        {
            var connection = WebApiConfig.ConnectDb();
            connection.Open();
            var command = new MySqlCommand($"DELETE from info where Account_number = {id}", connection);
            command.ExecuteNonQuery();

        }
    }
}
