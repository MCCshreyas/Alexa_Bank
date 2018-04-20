using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace WPFBankApplication
{
	/// <summary>
	///     Interaction logic for SaveMoney.xaml
	/// </summary>
	public partial class SaveMoney
	{
		private readonly string _accountNum;
		private string _remainingBalance;

		public SaveMoney(string accountNumber)
		{
			InitializeComponent();
			_accountNum = accountNumber;

			// please refer operations.cs file for GetCurrentBalance method
		}



		private void SaveMoneyButtonClick(object sender, RoutedEventArgs e)
		{

		}


		private void SaveMoneyTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			var regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

		private void BackButton_OnClick(object sender, RoutedEventArgs e)
		{
			Hide();
			new Welcome(_accountNum).Show();
		}
	}
}
