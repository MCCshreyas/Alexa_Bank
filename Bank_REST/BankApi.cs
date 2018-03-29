namespace Bank_REST

{
	using System.Net;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System.Collections.Specialized;
	using System.Text;

	public class BankApi : Constants
	{
		#region GetMethods 

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

		#endregion

		#region UpdateMethods

		public static bool UpdateCustomerName(string accountNumber = null, string name = null)
		{
			if (accountNumber == null && name == null) return false;
			try
			{
				using (var client = new WebClient())
				{
					var data = new NameValueCollection
					{
						["id"] = accountNumber,
						["name"] = name
					};

					var response = client.UploadValues(UpdateCustomerNameById(accountNumber, name), "PUT", data);
					Encoding.UTF8.GetString(response);
					return true;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}

		public static bool UpdateCustomerAddress(string accountNumber = null, string address = null)
		{
			if (accountNumber == null && address == null) return false;
			try
			{
				using (var client = new WebClient())
				{
					var data = new NameValueCollection
					{
						["id"] = accountNumber,
						["address"] = address
					};

					var response = client.UploadValues(UpdateCustomerAddressById(accountNumber, address), "PUT", data);
					Encoding.UTF8.GetString(response);
					return true;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}

		public static bool UpdateCustomerPhoneNumber(string accountNumber = null, string phonenumber = null)
		{
			if (accountNumber == null && phonenumber == null) return false;
			try
			{
				using (var client = new WebClient())
				{
					var data = new NameValueCollection
					{
						["id"] = accountNumber,
						["phonenumber"] = phonenumber
					};

					var response = client.UploadValues(UpdateCustomerPhoneNumberById(accountNumber, phonenumber), "PUT", data);
					Encoding.UTF8.GetString(response);
					return true;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}

		public static bool UpdateCustomerEmail(string accountNumber = null, string email = null)
		{
			if (accountNumber == null && email == null) return false;
			try
			{
				using (var client = new WebClient())
				{
					var data = new NameValueCollection
					{
						["id"] = accountNumber,
						["email"] = email
					};

					var response = client.UploadValues(UpdateCustomerEmailById(accountNumber, email), "PUT", data);
					Encoding.UTF8.GetString(response);
					return true;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}

		public static bool UpdateCustomerPassword(string accountNumber = null, string password = null)
		{
			if (accountNumber == null && password == null) return false;
			try
			{
				using (var client = new WebClient())
				{
					var data = new NameValueCollection
					{
						["id"] = accountNumber,
						["password"] = password
					};

					var response = client.UploadValues(UpdateCustomerPasswordById(accountNumber, password), "PUT", data);
					Encoding.UTF8.GetString(response);
					return true;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}

		public static bool UpdateCustomerBalance(string accountNumber = null, string balance = null)
		{
			if (accountNumber == null && balance == null) return false;
			try
			{
				using (var client = new WebClient())
				{
					var data = new NameValueCollection
					{
						["id"] = accountNumber,
						["balance"] = balance
					};

					var response = client.UploadValues(UpdateCustomerAccountBalanceById(accountNumber, balance), "PUT", data);
					Encoding.UTF8.GetString(response);
					return true;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}


		//needs some attention
		public static bool UpdateCustomerImagePath(string accountNumber = null, string path = null)
		{
			if (accountNumber == null && path == null) return false;
			try
			{
				using (var client = new WebClient())
				{
					var data = new NameValueCollection
					{
						["id"] = accountNumber,
						["path"] = path
					};

					var response = client.UploadValues(UpdateCustomerImagePathById(accountNumber, path), "PUT", data);
					Encoding.UTF8.GetString(response);
					return true;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}

		public static bool UpdateCustomerGender(string accountNumber = null, string gender = null)
		{
			if (accountNumber == null && gender == null) return false;
			try
			{
				using (var client = new WebClient())
				{
					var data = new NameValueCollection
					{
						["id"] = accountNumber,
						["gender"] = gender
					};

					var response = client.UploadValues(UpdateCustomerGenderById(accountNumber, gender), "PUT", data);
					Encoding.UTF8.GetString(response);
					return true;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}

		public static bool UpdateCustomerMobileVerificationStatus(string accountNumber = null, string status = null)
		{
			if (accountNumber == null && status == null) return false;
			try
			{
				using (var client = new WebClient())
				{
					var data = new NameValueCollection
					{
						["id"] = accountNumber,
						["mobile"] = status
					};

					var response = client.UploadValues(UpdateCustomerMobileVerificationById(accountNumber, status), "PUT", data);
					Encoding.UTF8.GetString(response);
					return true;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}

		public static bool UpdateCustomerBirthDate(string accountNumber = null, string birthdate = null)
		{
			if (accountNumber == null && birthdate == null) return false;
			try
			{
				using (var client = new WebClient())
				{
					var data = new NameValueCollection
					{
						["id"] = accountNumber,
						["date"] = birthdate
					};

					var response = client.UploadValues(UpdateCustomerBirthDateById(accountNumber, birthdate), "PUT", data);
					Encoding.UTF8.GetString(response);
					return true;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}

		#endregion

		#region DeleteMethod

		public static bool DeleteCustomer(string accountNumber = "")
		{
			if (accountNumber == "") return false;
			try
			{
				var request = WebRequest.Create(DeleteCustomerById(accountNumber));
				request.Method = "DELETE";

				var response = (HttpWebResponse)request.GetResponse();
				return true;
			}
			catch (WebException)
			{
				return false;
			}
		}

		#endregion

	}
}