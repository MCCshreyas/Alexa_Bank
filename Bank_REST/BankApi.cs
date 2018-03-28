namespace Bank_REST
{
	using System.Net;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;

	public class BankApi : Constants
	{
		/// <summary>
		/// Returns customer registered user name of specified account number 
		/// </summary>
		/// <param name="accountNumber">Customer account number </param>
		/// <returns></returns>
		public static string GetCustomerUserName(string accountNumber = "")
		{
			if (accountNumber == "") return null;
			try
			{
				using (var client = new WebClient())
				{

					var jsonResponse = client.DownloadString(GetCustomerById(accountNumber));
					var obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);

					if (obj.Count == 0)
					{
						return null;
					}

					var usernameResponse = obj[0]["Name"].ToString();
					return usernameResponse;
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		/// <summary>
		/// Returns customer registered password of specified account number 
		/// </summary>
		/// <param name="accountNumber">Customer account number </param>
		/// <returns></returns>
		public static string GetCustomerPassword(string accountNumber = "")
		{
			if (accountNumber == "") return null;
			try
			{
				using (var client = new WebClient())
				{

					var jsonResponse = client.DownloadString(GetCustomerById(accountNumber));
					var obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);

					if (obj.Count == 0)
					{
						return null;
					}

					var usernameResponse = obj[0]["Password"].ToString();
					return usernameResponse;
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		/// <summary>
		/// Returns customer registered email of specified account number 
		/// </summary>
		/// <param name="accountNumber">Customer account number </param>
		/// <returns></returns>
		public static string GetCustomerEmail(string accountNumber = "")
		{
			if (accountNumber == "") return null;
			try
			{
				using (var client = new WebClient())
				{

					var jsonResponse = client.DownloadString(GetCustomerById(accountNumber));
					var obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);

					if (obj.Count == 0)
					{
						return null;
					}

					var usernameResponse = obj[0]["Email"].ToString();
					return usernameResponse;
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		/// <summary>
		/// Returns customer current balance of specified account number 
		/// </summary>
		/// <param name="accountNumber">Customer account number </param>
		/// <returns></returns>
		public static string GetCustomerBalance(string accountNumber = "")
		{
			if (accountNumber == "") return null;
			try
			{
				using (var client = new WebClient())
				{

					var jsonResponse = client.DownloadString(GetCustomerById(accountNumber));
					var obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);

					if (obj.Count == 0)
					{
						return null;
					}

					var usernameResponse = obj[0]["Balance"].ToString();
					return usernameResponse;
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		/// <summary>
		/// Returns customer gender of specified account number 
		/// </summary>
		/// <param name="accountNumber">Customer account number </param>
		/// <returns></returns>
		public static string GetCustomerGender(string accountNumber = "")
		{
			if (accountNumber == "") return null;
			try
			{
				using (var client = new WebClient())
				{

					var jsonResponse = client.DownloadString(GetCustomerById(accountNumber));
					var obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);

					if (obj.Count == 0)
					{
						return null;
					}

					var usernameResponse = obj[0]["Gender"].ToString();
					return usernameResponse;
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		/// <summary>
		/// Returns customer mobile verfication status of specified account number 
		/// </summary>
		/// <param name="accountNumber">Customer account number </param>
		/// <returns></returns>
		public static string GetCustomerMobileVerificationStatus(string accountNumber = "")
		{
			if (accountNumber == "") return null;
			try
			{
				using (var client = new WebClient())
				{

					var jsonResponse = client.DownloadString(GetCustomerById(accountNumber));
					var obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);

					if (obj.Count == 0)
					{
						return null;
					}

					var usernameResponse = obj[0]["MobileVerification"].ToString();
					return usernameResponse;
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		/// <summary>
		/// Returns customer registered birth date of specified account number 
		/// </summary>
		/// <param name="accountNumber">Customer account number </param>
		/// <returns></returns>
		public static string GetCustomerBirthDate(string accountNumber = "")
		{
			if (accountNumber == "") return null;
			try
			{
				using (var client = new WebClient())
				{

					var jsonResponse = client.DownloadString(GetCustomerById(accountNumber));
					var obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);

					if (obj.Count == 0)
					{
						return null;
					}

					var usernameResponse = obj[0]["BirthDate"].ToString();
					return usernameResponse;
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		/// <summary>
		/// Returns customer registered address of specified account number 
		/// </summary>
		/// <param name="accountNumber">Customer account number </param>
		/// <returns></returns>
		public static string GetCustomerAddress(string accountNumber = "")
		{
			if (accountNumber == "") return null;
			try
			{
				using (var client = new WebClient())
				{

					var jsonResponse = client.DownloadString(GetCustomerById(accountNumber));
					var obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);

					if (obj.Count == 0)
					{
						return null;
					}

					var usernameResponse = obj[0]["Address"].ToString();
					return usernameResponse;
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		/// <summary>
		/// Returns customer registered Image path of specified account number 
		/// </summary>
		/// <param name="accountNumber">Customer account number </param>
		/// <returns></returns>
		public static string GetCustomerImagePath(string accountNumber = "")
		{
			if (accountNumber == "") return null;
			try
			{
				using (var client = new WebClient())
				{

					var jsonResponse = client.DownloadString(GetCustomerById(accountNumber));
					var obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);

					if (obj.Count == 0)
					{
						return null;
					}

					var usernameResponse = obj[0]["ImagePath"].ToString();
					return usernameResponse;
				}
			}
			catch (WebException)
			{
				return null;
			}
		}
	}
}