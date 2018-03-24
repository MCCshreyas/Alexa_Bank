using Bank_REST;

namespace BankLibrary
{
    public class Authentication
    {
        public static bool Authenticate(string account_number = "" , string password = "")
        {
             return BankApi.CheckCustomerAuthentication(account_number, password);
        }
    }
}