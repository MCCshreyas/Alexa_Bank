using System.Net.Mail;

namespace Bank_REST.Config
{
    /// <summary>
    /// Setting for Mail 
    /// </summary>
    public class MailConfiguration
    {
        protected static string MailAddress = @"shreyasjejurkar123@live.com";


        protected static string MailSubject = "Alexa Bank account confirmation mail";

        protected static SmtpClient SetUpMailServer()
        {
            var smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("shreyasjejurkar123@live.com", "MCCshreyas9970209265"),
                EnableSsl = true
            };
            return smtp;
        }


    }
}
