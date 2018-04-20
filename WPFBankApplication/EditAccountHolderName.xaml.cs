
namespace WPFBankApplication
{
	using System.Windows;


	/// <summary>
	/// Interaction logic for EditAccountHolderName.xaml
	/// </summary>
	public partial class EditAccountHolderName
	{
		private readonly string accNum;

		public EditAccountHolderName(string accountNumber)
		{
			InitializeComponent();
			accNum = accountNumber;
		}

		private void ButtonClick(object sender, RoutedEventArgs e)
		{
		}

		private void BackButtonClick(object sender, RoutedEventArgs e)
		{
			Window parentWindow = Window.GetWindow(new AccountSettings(accNum));
			parentWindow.Show();
		}
	}
}
