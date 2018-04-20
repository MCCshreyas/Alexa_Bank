using System.Windows;

namespace WPFBankApplication
{
	/// <summary>
	///     Interaction logic for ForgetPassword.xaml
	/// </summary>
	public partial class ForgetPassword
	{
		public ForgetPassword()
		{
			InitializeComponent();
		}


		private void ButtonClick(object sender, RoutedEventArgs e)
		{

		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			Hide();
			new LoggedIn().Show();
		}
	}
}
