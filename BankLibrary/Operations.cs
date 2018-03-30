using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
	using System;
	using Bank_REST;

	public class Operations
	{
		private static readonly Random Rng = new Random();
		static void Main(string[] args)
		{
			CreateNewAccount();
		}


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

		public static long CreateNewAccount()
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
					generatedNumber = GenerateAccountNumber();
				}
			}

			return generatedNumber;
		}

		

	}
}