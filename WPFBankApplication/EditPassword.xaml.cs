using System.Windows;


namespace WPFBankApplication
{
	/// <summary>
	///     Interaction logic for EditPassword.xaml
	/// </summary>
	public partial class EditPassword
	{
		private readonly string _acc;

		public EditPassword(string accountNumber)
		{
			InitializeComponent();
			_acc = accountNumber;
		}

		private void SaveButtonClick(object sender, RoutedEventArgs e)
		{
		}

		private void BackButtonClick(object sender, RoutedEventArgs e)
		{
			var parentWindow = Window.GetWindow(new AccountSettings(_acc));
			parentWindow?.Show();
		}
	}
}