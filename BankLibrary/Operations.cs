namespace BankLibrary
{
	using System;
	using Bank_REST;
	using System.Collections.Generic;
	using System.Text;


	public class Operations
	{
		private static readonly Random Rng = new Random();

		public static int WithDrawMoney(string accountNumber = null, long amount = 0)
		{
			if (accountNumber != null && amount != 0)
			{
				var responseBalance = BankApi.GetCustomerBalance(accountNumber);

				if (responseBalance != null)
				{
					var balance = Convert.ToInt64(responseBalance);

					if (balance < amount)
					{
						return -2;
					}

					if (balance > amount)
					{
						balance = balance - amount;
						BankApi.UpdateCustomerBalance(accountNumber, Convert.ToString(balance));
						return 0;
					}
				}
			}
			return -1;
		}

		public static int GetCurrentBalance(string accountNumber)
		{
			var balance = BankApi.GetCustomerBalance(accountNumber);
			if (balance != null)
			{
				return Convert.ToInt32(balance);
			}

			return -2;
		}

		public static int SetCurrentBalance(string accountNumber = "", string amount = "")
		{
			if (accountNumber != "" && amount != "")
			{
				var balance = BankApi.UpdateCustomerBalance(accountNumber, amount);
				if (balance)
				{
					return 0;
				}
			}
			return -1;
		}



		public static int DepositeMoney(string accountNumber = "", long amount = 0)
		{
			if (accountNumber != null && amount != 0)
			{
				var responseBalance = BankApi.GetCustomerBalance(accountNumber);
				if (responseBalance != null)
				{
					var balance = Convert.ToInt64(responseBalance);
					balance = balance + amount;
					BankApi.UpdateCustomerBalance(accountNumber, Convert.ToString(balance));

				}
			}
			return 0;
		}

		public static int TransferMoney(string sourceAccountNumber = "", string destinationAccountNumber = "", long amount = 0, string userPassword = "")
		{
			if (sourceAccountNumber != "" && destinationAccountNumber != "" && amount != 0 && userPassword != "" && amount >= 0)
			{
				var isDestinationAccountExits = CheckAccountExistance(destinationAccountNumber);

				if (isDestinationAccountExits)
				{
					var sourceAccountBalance = GetCurrentBalance(sourceAccountNumber);
					if (sourceAccountBalance < amount)
					{
						return -3;
					}
					else
					{
						//source site
						var srcCurrentBalance = GetCurrentBalance(sourceAccountNumber);
						srcCurrentBalance = (int)(srcCurrentBalance - amount);
						SetCurrentBalance(sourceAccountNumber, srcCurrentBalance.ToString());
						
						//destination side
						var destcurrentBalance = GetCurrentBalance(destinationAccountNumber);
						destcurrentBalance = (int)(destcurrentBalance + amount);
						SetCurrentBalance(destinationAccountNumber, destcurrentBalance.ToString());
						return 0;
					}	
				}
				return -2;
			}
			return -1;
		}

		private static bool CheckAccountExistance(string accountNumber = "")
		{
			var availableAccountNumberList = BankApi.GetCustomersAccountNumbers();
			foreach (var account in availableAccountNumberList)
			{
				if (account.Equals(accountNumber))
				{
					return true;
				}
			}

			return false;
		}


		private static string GetUserPassword(string accountNumber = "")
		{
			if (accountNumber != "")
			{
				var password = BankApi.GetCustomerPassword(accountNumber);
				return password;
			}
			else
			{
				return string.Empty;
			}
		}



		public static long InitializeNewAccount()
		{
			long GenerateAccountNumber()
			{
				var builder = new StringBuilder();
				while (builder.Length < 15)
				{
					builder.Append(Rng.Next(10).ToString());
				}
				return Convert.ToInt64(builder.ToString());
			}

			var generatedNumber = GenerateAccountNumber();

			List<string> availableAccountNumber = BankApi.GetCustomersAccountNumbers();

			foreach (var number in availableAccountNumber)
			{
				if (number == generatedNumber.ToString())
				{
					generatedNumber = generatedNumber + 1;
				}
			}

			return generatedNumber;
		}
	}
}