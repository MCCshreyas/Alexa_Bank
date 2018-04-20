using System;
using System.Windows.Forms;
using BankLibrary;
using Newtonsoft.Json;

namespace Alexa_Console
{
	internal class Program
	{
		[STAThreadAttribute]
		private static void Main(string[] args)
		{
			try
			{
				var userChoice = 0;
				do
				{
					Console.WriteLine();
					Console.WriteLine("==================================");
					Console.WriteLine("Welcome to Alexa Bank of India");
					Console.WriteLine();
					Console.WriteLine("Select from following option");
					Console.WriteLine("1. Log in");
					Console.WriteLine("2. Create a new account");
					Console.WriteLine("3. Exit");
					Console.WriteLine("==================================");
					userChoice = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

					switch (userChoice)
					{
						case 1:
							LogIn();
							break;

						case 2:
							CreateNewAccount();
							break;

						case 3:
							Application.Exit();
							break;

						case 4:
							break;
					}
				} while (userChoice != 3);
			}
			catch (Exception e)
			{
				Console.WriteLine($"Something went wrong. Problem description : {e.Message}");
			}
		}

		private static void CreateNewAccount()
		{
			Console.Clear();
			try
			{
				var accountNumber = Operations.InitializeNewAccount();

				Console.WriteLine("Enter following details");

				var customerobj = new Customer
				{
					AccountNumber = accountNumber.ToString()
				};

				Console.Write("Enter full name: ");
				customerobj.Name = Console.ReadLine();

				Console.Write("Address: ");
				customerobj.Address = Console.ReadLine();

				Console.Write("Phone Number: ");
				customerobj.PhoneNumber = Console.ReadLine();

				Console.Write("Email: ");
				customerobj.Email = Console.ReadLine();

				Console.Write("Birth Date: ");
				customerobj.BirthDate = Console.ReadLine();

				Console.Write("Password: ");
				customerobj.Password = Console.ReadLine();

				Console.Write("Initial balance: ");
				customerobj.Balance = Console.ReadLine();

				Console.Write("Select passport size photo: ");

				var open = new OpenFileDialog
				{
					Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
				};

				if (open.ShowDialog() == DialogResult.OK)
				{
					Console.WriteLine($"Selected image path: {open.FileName}");
					customerobj.Image = open.FileName;
				}
				

				Console.Write("Select gender from following ");
				Console.WriteLine("1. Male");
				Console.WriteLine("2. Female");
				Console.WriteLine("3. Other");
				var gender = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
				switch (gender)
				{
					case 1:
						customerobj.Gender = "Male";
						break;
					case 2:
						customerobj.Gender = "Female";
						break;
					case 3:
						customerobj.Gender = "Other";
						break;
				}

				Console.WriteLine("Do you want to enable Mobile notification for your account. ");
				Console.WriteLine(@"Type 'y' for Yes and 'n' for no");

				var choice = Console.ReadLine();
				switch (choice)
				{
					case "y":
						customerobj.Notification = "Yes";
						break;
					case "n":
						customerobj.Notification = "No";
						break;
				}

				Console.WriteLine("Account created sucessfully");

				string json = JsonConvert.SerializeObject(customerobj);
				Console.WriteLine(json);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void LogIn()
		{
			Console.Clear();
			Console.WriteLine("Enter account number");
			var accountnumber = Console.ReadLine();

			Console.WriteLine("Enter password");
			var pass = Console.ReadLine();

			var result = Authentication.Authenticate(accountnumber, pass);

			if (result)
			{
				Console.Clear();
				ShowWelcomeWindow(accountnumber);
			}
			else
			{
				MessageBox.Show("Plese enter correct username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Console.Clear();
			}
		}

		private static void ShowWelcomeWindow(string accountnumber = null)
		{
			var acc = accountnumber;
			var result = 0;
			do
			{
				Console.WriteLine();
				Console.WriteLine("1. Check account status");
				Console.WriteLine("2. WithDraw Money");
				Console.WriteLine("3. Save Money");
				Console.WriteLine("4. Account settings");
				var convertResult = int.TryParse(Console.ReadLine(), out result);

				if (!convertResult) return;

				switch (result)
				{
					case 1:
						ShowAccountStatus(acc);
						break;

					case 2:
						WithDrawMoney(acc);
						break;

					case 3:
						DepositeMoney(acc);
						break;
				}
			} while (result != 5);
		}


		private static void DepositeMoney(string accountNo)
		{
			var currentBalance = Operations.GetCurrentBalance(accountNo);

			if (currentBalance == -2)
			{
				currentBalance = -0000000;
			}

			Console.WriteLine($"Current balance = {currentBalance}");

			Console.WriteLine("Enter amount for deposite : ");
			var amount = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

			var status = Operations.DepositeMoney(accountNo, amount);

			switch (status)
			{
				case 0:
					Console.WriteLine(
						$"Money deposited sucessfully. Your current balance is {Operations.GetCurrentBalance(accountNo)}");
					break;
			}
		}

		private static void WithDrawMoney(string accountNo)
		{
			var currentBalance = Operations.GetCurrentBalance(accountNo);

			if (currentBalance == -2)
			{
				currentBalance = -0000000;
			}

			Console.WriteLine($"Current balance = {currentBalance}");

			Console.WriteLine("Enter Withdraw amount : ");
			var amount = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

			var status = Operations.WithDrawMoney(accountNo, amount);

			switch (status)
			{
				case 0:
					Console.WriteLine(
						$"Money withdraw sucessfully. Your current balance is {Operations.GetCurrentBalance(accountNo)} ");
					break;
				case -1:
					Console.WriteLine("Something went wrong");
					break;
			}
		}

		private static void ShowAccountStatus(string accountNo)
		{
			var cs = new Customer();
			cs.InitializeAllFieldsForExistingAccount(accountNo);
			Console.WriteLine("=======================================");
			Console.WriteLine($"Account number: {cs.AccountNumber}");
			Console.WriteLine($"Account holder name: {cs.Name}");
			Console.WriteLine($"Current balance: Rs.{cs.Balance}");
			Console.WriteLine("=======================================");
		}
	}
}