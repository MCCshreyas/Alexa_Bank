namespace WPFBankApplication
{
	using System.Windows;

	/// <summary>
	///     Interaction logic for ForgetAccountNumber.xaml
	/// </summary>
	public partial class ForgetAccountNumber
	{
		public ForgetAccountNumber()
		{
			InitializeComponent();
		}


		private void ButtonSubmit_OnClick(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			new LoggedIn().Show();
			Hide();
		}
	}
}
