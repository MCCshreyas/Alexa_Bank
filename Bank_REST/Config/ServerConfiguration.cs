namespace Bank_REST.Config
{
    class ServerConfiguration
    {
        /// <summary>
        /// Default server name
        /// </summary>
        public const string ServerName = "localhost";

        /// <summary>
        /// Default Website URL
        /// </summary>
        public const string Url = "alexabank";

        /// <summary>
        /// Base address
        /// </summary>
        public static string BaseAddress = $"{ServerName}/{Url}";
    }
}
