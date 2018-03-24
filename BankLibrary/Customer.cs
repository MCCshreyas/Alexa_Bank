using System;
using System.Text.RegularExpressions;

namespace BankLibrary
{
	public enum Gender
	{
		Male = 1,
		Female = 2,
		Other = 3
	}

	public enum MobileNotification
	{
		Yes = 1,
		No = 2
	}

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
		private Gender _gender;
		private DateTime _birthDate;
		private MobileNotification _mobileNotification;
		#endregion

		#region FieldInitialization

		private string Name
		{
			get => _name;
			set
			{
				if (value == null)
				{
					throw new Exception("Name cannot be null");
				}
			}
		}

		public string Address
		{
			get => _address;
			set => _address = value;
		}

		public string PhoneNumber
		{
			get => _phoneNumber;
			set
			{
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


		public DateTime BirthDate
		{
			get => _birthDate;
			set
			{
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
				if (value.Length < 8)
				{
					throw new Exception("Password cannot be less than 8 characters");
				}

				_password = value;
			}
		}

		public string AccountNumber
		{
			get => _accountNumber;
			set => _accountNumber = value;
		}

		public string Balance
		{
			get => _balance;
			set
			{
				if (value == null || value.Contains("-"))
				{
					throw new Exception("Balance cannot be null or negative");
				}
			}
		}

		public string Image
		{
			get => _image;
			set => _image = value;
		}

		public Gender Gender1
		{
			get => _gender;
			set => _gender = value;
		}

		public MobileNotification Notification
		{
			get => _mobileNotification;
			set => _mobileNotification = value;
		}

		#endregion

		#region Constructor

		public Customer()
		{
		}
		#endregion
	}
}