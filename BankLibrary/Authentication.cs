using System.Diagnostics;
using Bank_REST;

namespace BankLibrary
{
    public class Authentication
    {
        public static bool Authenticate(string accountNumber = "", string password = "")
        {
            try
            {
                var responsePassword = BankApi.GetCustomerPassword(accountNumber);
                return responsePassword != null && responsePassword.ToString().Equals(password);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e);
            }

            return false;
        }
    }
}