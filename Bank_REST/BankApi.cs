using System;
using System.Net;
using System.Net.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bank_REST
{
    public class BankApi
    {
	    static void Main(string[] args)
	    {
		    GetCustomerUserName("653546546");

	    }

	    public static string GetCustomerUserName(string accountNumber = "")
	    {
		    if (accountNumber == "") return null;
		    try
		    {
			    using (var client = new WebClient())
			    {
				    var jsonResponse = client.DownloadString($"http://localhost:3000/customer/{accountNumber}");
				    var obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);

				    if (obj.Count == 0)
				    {
					    return null;
				    }

				    var usernameResponse = obj[0]["Name"].ToString();
				    return usernameResponse.ToString();
			    }
		    }
		    catch (WebException)
		    {
			    return null;
		    }
		    return null;
	    }
		

        public static bool AuthenticateCustomer(string accountNumber = "", string password = "")
        {
			try
			{
				using (var client = new WebClient())
				{
					var jsonResponse = client.DownloadString($"http://localhost:3000/customer/{accountNumber}");
					var obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);

					if (obj.Count == 0)
					{
						return false;
					}

					var passwordResponse = obj[0]["Password"].ToString();

					if (password.Equals(passwordResponse))
					{
						return true;
					}
				}

				return false;
			}
			catch (WebException)
			{
				return false;
			}
        }
    }
}