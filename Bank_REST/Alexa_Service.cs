using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using Bank_REST;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Alexa_Server
{
    public class AlexaService
    {
        public static ArrayList GetAllAccountNumber()
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{Constants.BaseAddress}/api/customer/GetAccountNumbers");
            request.Method = "GET";
            var test = string.Empty;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }

            var result = JsonConvert.DeserializeObject<ArrayList>(test);
            return result;

        }

        public static string GetPassword(string accountNumber)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{Constants.BaseAddress}/api/customer/getpassword/{accountNumber}");

            request.Method = "GET";

            var test = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    test = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }

            var result = JsonConvert.DeserializeObject<string>(test);
            return result;
        }

        /// <summary>
        /// Return specified Customer object with respect to Account number passed
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public  static Customer GetCustomer(string accountNumber)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{Constants.BaseAddress}/api/customer/{accountNumber}");

            request.Method = "GET";

            var test = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    test = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }

            var result = JsonConvert.DeserializeObject<Customer>(test);
            return result;
        }

        /// <summary>
        /// Generate random 12 digit account number
        /// </summary>
        /// <returns></returns>
        public static string GenerateNewAccountNumber()
        {
            var bytes = new byte[sizeof(Int64)];
            RNGCryptoServiceProvider Gen = new RNGCryptoServiceProvider();
            Gen.GetBytes(bytes);

            long random = BitConverter.ToInt64(bytes, 0);

            //Remove any possible negative generator numbers and shorten the generated number to 12-digits
            string pos = random.ToString().Replace("-", "").Substring(0, 12);

            var account = Convert.ToInt64(pos).ToString();
            
            var availableAccountNumbers = new ArrayList();

            availableAccountNumbers = GetAllAccountNumber();
            
            foreach (var acc in availableAccountNumbers)
            {
                if (acc.Equals(account))
                {
                   long no = Convert.ToInt64(account);
                   no = no + 1;
                   return no.ToString();
                }
                else
                {
                    return account;
                }
            }
            return null;
        }
    }
}