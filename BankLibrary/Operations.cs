using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_REST;
namespace BankLibrary
{
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
	}
}