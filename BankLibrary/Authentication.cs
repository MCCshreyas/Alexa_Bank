using Bank_REST;

namespace BankLibrary
{
    public class Authentication
    {
        public static bool Authenticate(string accountNumber = "" , string password = "")
        {
	        var responsePassword = BankApi.GetCustomerPassword(accountNumber);
	        return responsePassword != null && responsePassword.ToString().Equals(password);
        }
    }
}