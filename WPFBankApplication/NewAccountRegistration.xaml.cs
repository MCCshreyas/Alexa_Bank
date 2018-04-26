using System;

namespace WPFBankApplication
{
	using MaterialDesignThemes.Wpf;
	using System.Text.RegularExpressions;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;
	using System.Windows.Media;
	using Microsoft.Win32;

	public partial class NewAccountRegistration
	{
		OpenFileDialog _open;

		public NewAccountRegistration()
		{
			InitializeComponent();
			RadioButtonMale.IsChecked = true;
			MyDatePicker.Focusable = false;
			MyComboBox.SelectedIndex = 2;
		}


		private string SelectAccountHolderImage()
		{
			try
			{
				_open = new OpenFileDialog
				{
					Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
				};
				var result = _open.ShowDialog();

				var fileName = result == true ? _open.FileName : string.Empty;

				var con = new ImageSourceConverter();
				AccountHolderImage.Source = (ImageSource)con.ConvertFromString(fileName);
				return fileName;
			}
			catch (Exception)
			{
				MessageBox.Show("Please select profile image.");
				return string.Empty;
			}
		}

		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			var profilePicPath = SelectAccountHolderImage();
		}

		private void BtnSaveClick(object sender, RoutedEventArgs e)
		{

		}

		private void MyComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (MyComboBox.SelectedIndex == 0)
			{
				HintAssist.SetIsFloating(WorkDetailsTextBox, true);
				HintAssist.SetHint(WorkDetailsTextBox, "Company name");
			}
			else if (MyComboBox.SelectedIndex == 1)
			{
				HintAssist.SetIsFloating(WorkDetailsTextBox, true);
				HintAssist.SetHint(WorkDetailsTextBox, "Corporation name");
			}
			else if (MyComboBox.SelectedIndex == 2)
			{
				HintAssist.SetIsFloating(WorkDetailsTextBox, true);
				HintAssist.SetHint(WorkDetailsTextBox, "College name");
			}
		}

		private void TextBox_phonenumber_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			var regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}
		
		private void TextBoxPhonenumberTextChanged(object sender, TextChangedEventArgs e)
		{
			MainSnackbar.MessageQueue.Enqueue(
				"Make sure you give correct phone number to recive OTP to activate your acoount");

		}

		private void BackButton_OnClick(object sender, RoutedEventArgs e)
		{
			new LoggedIn().Show();
			Hide();
		}


		private void Btn_clear_details_OnClick(object sender, RoutedEventArgs e)
		{
			TextBoxPhonenumber.Text = TextBoxAddress.Text = TextBoxEmail.Text = TextBoxFirstname.Text = TextBoxLastname.Text = TextBoxPass.Password = MyDatePicker.Text = "";

			new ImageSourceConverter();
			AccountHolderImage.Source = null;
		}
	}
}
