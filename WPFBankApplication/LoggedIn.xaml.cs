using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using BankLibrary;

namespace WPFBankApplication
{
	public partial class LoggedIn
	{
		public LoggedIn()
		{
			InitializeComponent();
			ShowWelcomeSnakbar();
		}

		private void ShowWelcomeSnakbar() => MainSnackbar.MessageQueue.Enqueue("Welcome to Alexa Bank Of India");

		private bool Validation()
		{
			var accountNumber = TextBoxAccountNumber.Text.Trim();
			var accountPassword = PasswordBoxAccountNumber.Password.Trim();

			if (accountNumber.Equals(string.Empty) || accountPassword.Equals(string.Empty))
			{
				return false;
			}
			else return true;
		}

		private void Button1Click(object sender, RoutedEventArgs e)
		{
			if (Validation())
			{
				var status = Authentication.Authenticate(TextBoxAccountNumber.Text.Trim(), PasswordBoxAccountNumber.Password.Trim());

				if (status)
				{
					MessageBox.Show("Login Sucessfully");
					Welcome m = new Welcome(TextBoxAccountNumber.Text.Trim());
					m.Show();
				}
				else
				{
					MessageBox.Show("Credentials are incorrect");
				}
			}
			else
			{
				MessageBox.Show("Please enter all the fields");
			}
		}


		private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
		{
			new NewAccountRegistration().Show();
			Hide();
		}

		private void TextBox_acc_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			var regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}
		
		private void ForgetAccountNumberHyperLink_OnClick(object sender, RoutedEventArgs e)
		{
			new ForgetAccountNumber().Show();
			Hide();
		}

		private void ForgetpasswordHyperLink1_OnClick(object sender, RoutedEventArgs e)
		{
			new ForgetPassword().Show();
			Hide();
		}

		private void ButtonGitHub_OnClick(object sender, RoutedEventArgs e)
		{
			Process.Start("https://github.com/MCCshreyas");

		}
	
		private void ButtonTwitter_OnClick(object sender, RoutedEventArgs e) => Process.Start("https://twitter.com/MCCshreyas");
	}
}
