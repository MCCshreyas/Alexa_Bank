
namespace WPFBankApplication
{
	using System.Windows;

	/// <summary>
	///     Interaction logic for Welcome.xaml
	/// </summary>
	public partial class Welcome
	{
		private static string _accountNumber = string.Empty;

		public Welcome(string accountNum)
		{
			InitializeComponent();

		}


		private void ButtonWithdrawMoneyClick(object sender, RoutedEventArgs e)
		{
			Hide();
			new WithdrawMoney(_accountNumber).Show();
		}

		private void ButtonSaveMoneyClick(object sender, RoutedEventArgs e)
		{
			new SaveMoney(_accountNumber).Show();
			Hide();
		}

		private void TransferMoneyButton_OnClick(object sender, RoutedEventArgs e)
		{
			new TransferMoney(_accountNumber).Show();
			Hide();
		}

		private void ButtonLogOut_OnClick(object sender, RoutedEventArgs e)
		{
		
		}

		private void ButtonAccountSettings_OnClick(object sender, RoutedEventArgs e)
		{
			Hide();
			new AccountSettings(_accountNumber).Show();
		}
	}
}
