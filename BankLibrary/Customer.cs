using System;
using System.Text.RegularExpressions;
using Bank_REST;

namespace BankLibrary
{
	public class Customer
	{
		#region Fields

		private string _name;
		private string _address;
		private string _phoneNumber;
		private string _email;
		private string _password;
		private string _accountNumber;
		private string _balance;
		private string _image;
		private string _gender;
		private string _birthDate;
		private string _mobileNotification;

		#endregion

		#region FieldInitialization

		public void InitializeAllFieldsForExistingAccount(string accountNumber)
		{
			_accountNumber = accountNumber;
			_name = BankApi.GetCustomerUserName(_accountNumber);
			_address = BankApi.GetCustomerAddress(accountNumber);
			_phoneNumber = BankApi.GetCustomerPhoneNumber(accountNumber);
			_email = BankApi.GetCustomerEmail(accountNumber);
			_password = BankApi.GetCustomerPassword(accountNumber);
			_balance = BankApi.GetCustomerBalance(accountNumber);
			_image = BankApi.GetCustomerImagePath(accountNumber);
			_gender = BankApi.GetCustomerGender(accountNumber);
			_mobileNotification = BankApi.GetCustomerMobileVerificationStatus(accountNumber);
			_birthDate = BankApi.GetCustomerBirthDate(accountNumber);
		}


		public string Name
		{
			get => _name;

			set => _name = value ?? throw new Exception("Name cannot be null");
		}


		public string Address
		{
			get => _address;
			set => _name = value ?? throw new Exception("Address cannot be null");
		}

		public string PhoneNumber
		{
			get => _phoneNumber;
			set
			{
				if (value == null) throw new Exception("Phone number cannot be null");

				if (value.Length > 10) throw new Exception("Phone number cannot be greater than 10 numbers");

				if (value.Length < 10) throw new Exception("Phone number cannot be less than 10");

				_phoneNumber = value;
			}
		}


		public string BirthDate
		{
			get => _birthDate;
			set => _birthDate = value ?? throw new Exception("Birth date cannot be null");
		}

		public string Email
		{
			get => _email;
			set
			{
				var isEmail = Regex.IsMatch(value,
					@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
					RegexOptions.IgnoreCase);
				if (isEmail)
					_email = value;
				else
					throw new Exception("Email address is not valid");
			}
		}

		public string Password
		{
			get => _password;
			set
			{
				if (value.Length < 8) throw new Exception("Password cannot be less than 8 characters");

				_password = value;
			}
		}

		public string AccountNumber
		{
			get => _accountNumber;
			set
			{
				if (value.Length < 15) throw new Exception("Account number invalid");

				_accountNumber = value;
			}
		}

		public string Balance
		{
			get => _balance;
			set
			{
				if (value == null || value.Contains("-")) throw new Exception("Balance cannot be null or negative");

				_balance = value;
			}
		}

		public string Image
		{
			get => _image;
			set => Image = value ?? throw new Exception("Provide valid path to photo");
		}

		public string Gender
		{
			get => _gender;
			set
			{
				if (value == null) throw new Exception("Gender cannot be null");

				if (value != "Male" || value != "Female" || value != "Other") throw new Exception("Gender invalid");

				_gender = value;
			}
		}

		public string Notification
		{
			get => _mobileNotification;
			set
			{
				if (value == null) throw new Exception("Value cannot be null");

				if (value != "Yes" || value != "No") throw new Exception("Input invalid");

				_mobileNotification = value;
			}
		}

		#endregion
	}
}