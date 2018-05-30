using System.Collections.Generic;
using System.Web.Http;
using Web_Api_Alexa.Models;

namespace Web_Api_Alexa.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Customer> Get()
        {
            return null;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return null;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}
