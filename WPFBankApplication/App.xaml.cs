﻿
using Twilio;
using Twilio.Exceptions;

namespace WPFBankApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// Following method will initialize twilio account
        /// </summary>
        public static void InitializeTwilioAccount()
        {
            try
            {
                const string AccountSid = "ACa4e91ac77184d82e6b7e7db26612c8d0";
                const string AuthToken = "cf88bc0c7f9a1c67f9ea49d5917a9be6";

                TwilioClient.Init(AccountSid, AuthToken);
            }
            catch (TwilioException tw)
            {
                ///DialogBox.Show("ERROR", "Unable to initialize Twilio service " + tw.Message, "OK");
            }
        }
    }
}
