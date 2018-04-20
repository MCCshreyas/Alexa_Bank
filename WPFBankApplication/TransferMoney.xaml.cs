using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFBankApplication
{
	/// <summary>
	///     Interaction logic for TransferMoney.xaml
	/// </summary>
	public partial class TransferMoney
	{
		private readonly string accountNum;
		private string remainingReceiverBalance;
		private string remainingSenderBalance;


		public TransferMoney(string accountNumber)
		{
			InitializeComponent();
			accountNum = accountNumber;
		}
		private void ButtonClick(object sender, RoutedEventArgs e)
		{
		}

		/// <summary>
		///     Following method will send mobile notification to registered mobile number
		/// </summary>

		private void TextBoxAccoutPassword_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			var regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}


		private void TextBoxMoneyAmountTextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void BackButtonClick(object sender, RoutedEventArgs e)
		{
			new Welcome(accountNum).Show();
			Hide();
		}
	}
}
