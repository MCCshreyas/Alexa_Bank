using System.Runtime.InteropServices;

namespace WPFBankApplication
{
	public static class Resource
    {
        public const string DATABASE_URL = "jdbc:mysql://localhost/bankapplication";
        public const string USERNAME = "root";
        public const string PASSWORD = "9970209265";
        public const string TWILIO_PHONENUMBER = "+16674018291";


        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int description, int reservedValue);

        public static bool IsInternetAvailable()
        {
            return InternetGetConnectedState(out int _, 0);
        }
    }
}
