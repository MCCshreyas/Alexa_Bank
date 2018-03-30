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

		public Customer(string accountNumber)
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
			get => this._name;

			set
			{
				//value = ;
				_name = value;
			}
		}


		public string Address
		{
			get => _address;
			set
			{
				value = BankApi.GetCustomerAddress(this._accountNumber);
				_name = value;
			}
		}

		public string PhoneNumber
		{
			get => _phoneNumber;
			set
			{
				value = BankApi.GetCustomerPhoneNumber(this._accountNumber);

				if (value == null)
				{
					throw new Exception("Phone number cannot be null");
				}

				if (value.Length > 10)
				{
					throw new Exception("Phone number cannot be greater than 10 numbers");
				}

				if (value.Length < 10)
				{
					throw new Exception("Phone number cannot be less than 10");
				}

				_phoneNumber = value;
			}
		}


		public string BirthDate
		{
			get => _birthDate;
			set
			{
				//value = Convert.ToDateTime(BankApi.GetCustomerBirthDate(this._accountNumber));
				
				if (value == null)
				{
					throw new Exception("Birth date cannot be null");
				}

				_birthDate = value;
			}

		}

		public string Email
		{
			get => _email;
			set
			{
				value = BankApi.GetCustomerEmail(this._accountNumber);

				bool isEmail = Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
				if (isEmail)
				{
					_email = value;
				}
				else
				{
					throw new Exception("Email address is not valid");
				}
			}
		}

		public string Password
		{
			get => _password;
			set
			{
				value = BankApi.GetCustomerPassword(this._accountNumber);
				if (value.Length < 8)
				{
					throw new Exception("Password cannot be less than 8 characters");
				}

				_password = value;
			}
		}

		public string AccountNumber => _accountNumber;

		public string Balance
		{
			get => _balance;
			set
			{
				value = BankApi.GetCustomerBalance(this._accountNumber);

				if (value == null || value.Contains("-"))
				{
					throw new Exception("Balance cannot be null or negative");
				}

				this._balance = value;
			}
		}

		public string Image
		{
			get => _image;
			set => _image = BankApi.GetCustomerImagePath(this._accountNumber);
		}

		public string Gender
		{
			get => _gender;
			set => BankApi.GetCustomerGender(this._accountNumber);
		}

		public string Notification
		{
			get => _mobileNotification;
			set => BankApi.GetCustomerMobileVerificationStatus(this._accountNumber);
		}

		#endregion
		
				
	}
}