using Bank_REST;
using Alexa_Server;

// ReSharper disable once CheckNamespace
namespace Alexa_API
{
    public class Authentication
    {
      
        public static int Authenticate(string accountNumber = "", string password = "")
        {
            if (accountNumber != "" && password != "")
            {
                var availability = IsAccountExists(accountNumber);

                if (availability)
                {
                    var responsePassword = AlexaService.GetPassword(accountNumber);

                    if (responsePassword.Equals(password))
                    {
                        return 0;
                    }

                    return -1;
                }

                return -2;


            }

            return -3;
        }
        
        public static bool IsAccountExists(string accountNumber = "")
        {
            if (accountNumber != "")
            {
                var allAccountNumber = AlexaService.GetAllAccountNumber();

                foreach (var acc in allAccountNumber)
                {
                    if (acc.Equals(accountNumber))
                    {
                        return true;
                    }
                }

            }
            else
            {
                return false;
            }

            return false;
        }
    }
}