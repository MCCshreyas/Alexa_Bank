namespace Bank_REST
{
	public class Constants
	{
		#region DefaultServerConfiguration 
		private const string ServerName = "localhost";
		private const string PortNumber = "3000";
		#endregion

		/// <summary>
		/// Returns REST API call for to get all available Customers 
		/// </summary>
		public static readonly string GetAllCustomers = $@"http://{ServerName}:{PortNumber}/customer/";
		
		/// <summary>
		/// Returns specified REST API call for customer ID
		/// </summary>
		/// <param name="id">Customer ID </param>
		/// <returns></returns>
		public static string GetCustomerById(string id = null)
		{
			return id != null ? $@"http://{ServerName}:{PortNumber}/customer/{id}" : null;
		}

		/// <summary>
		/// Returns specified REST API call for Customer ID to update Name
		/// </summary>
		/// <param name="id">Customer ID</param>
		/// <param name="name">Customer updated name</param>
		/// <returns></returns>
		public static string UpdateCustomerNameById(string id = null, string name = null)
		{
			if (id != null && name != null)
				return $@"http://{ServerName}:{PortNumber}/customer/updatename/{id}/{name}";
			return null;
		}

		public static string UpdateCustomerAddressById(string id = null, string address = null)
		{
			if (id != null && address != null)
				return $@"http://{ServerName}:{PortNumber}/customer/updateaddress/{id}/{address}";
			return null;
		}

		public static string UpdateCustomerPhoneNumberById(string id = null, string phonenumber = null)
		{
			if (id != null && phonenumber != null)
				return $@"http://{ServerName}:{PortNumber}/customer/updatephonenumber/{id}/{phonenumber}";
			return null;
		}

		public static string UpdateCustomerEmailById(string id = null, string email = null)
		{
			if (id != null && email != null)
				return $@"http://{ServerName}:{PortNumber}/customer/updateemail/{id}/{email}";
			return null;
		}

		public static string UpdateCustomerPasswordById(string id = null, string password = null)
		{
			if (id != null && password != null)
				return $@"http://{ServerName}:{PortNumber}/customer/updatepassword/{id}/{password}";
			return null;
		}

		public static string UpdateCustomerAccountBalanceById(string id = null, string balance = null)
		{
			if (id != null && balance != null)
				return $@"http://{ServerName}:{PortNumber}/customer/updatebalance/{id}/{balance}";
			return null;
		}

		public static string UpdateCustomerImagePathById(string id = null, string path = null)
		{
			if (id != null && path != null)
				return $@"http://{ServerName}:{PortNumber}/customer/updateImagePath/{id}/{path}";
			return null;
		}

		public static string UpdateCustomerGenderById(string id = null, string gender= null)
		{
			if (id != null && gender != null)
				return $@"http://{ServerName}:{PortNumber}/customer/updateaddress/{id}/{gender}";
			return null;
		}

		public static string UpdateCustomerMobileVerificationById(string id = null, string mobileverification = null)
		{
			if (id != null && mobileverification != null)
				return $@"http://{ServerName}:{PortNumber}/customer/updatemobileverification/{id}/{mobileverification}";
			return null;
		}

		public static string UpdateCustomerBirthDateById(string id = null, string birthdate = null)
		{
			if (id != null && birthdate != null)
				return $@"http://{ServerName}:{PortNumber}/customer/updatebirthdate/{id}/{birthdate}";
			return null;
		}
	}
}
