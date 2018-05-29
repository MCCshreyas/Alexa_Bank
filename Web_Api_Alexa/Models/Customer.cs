namespace Web_Api_Alexa.Models
{
    public class Customer
    {
        public string Name;
        public string Address;
        public string Phone_number;
        public string Email;
        public string Password;
        public string Balance;
        public string Account_number;
        public string ImagePath;
        public string Gender;
        public string BirthDate;

        public Customer()
        {
        }

        public Customer(string name, string address, string phoneNumber, string email, string password, string accountBalance, string accountNumber, string imagePath, string gender, string Birth_date)
        {
            Name = name;
            Address = address;
            Phone_number = phoneNumber;
            Email = email;
            Password = password;
            Balance = accountBalance;
            Account_number = accountNumber;
            ImagePath = imagePath;
            Gender = gender;
            BirthDate = Birth_date;
        }



    }
}