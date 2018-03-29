namespace BankLibrary
{
	using System;
	using Bank_REST;

	public class Operations
	{
		public static int WithDrawMoney(string accountNumber = null , long amount = 0 )
		{
			if (accountNumber!= null && amount != 0)
			{
				var responseBalance = BankApi.GetCustomerBalance(accountNumber);
				if (responseBalance!= null)
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
	}
}