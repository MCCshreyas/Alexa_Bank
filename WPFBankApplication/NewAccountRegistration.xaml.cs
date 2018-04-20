namespace WPFBankApplication
{
	using System.Text.RegularExpressions;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;
	using System.Windows.Media;


	using MaterialDesignThemes.Wpf;

	public partial class NewAccountRegistration
	{

		public NewAccountRegistration()
		{
			InitializeComponent();
			RadioButtonMale.IsChecked = true;
			MyDatePicker.Focusable = false;
			MyComboBox.SelectedIndex = 2;
		}

		/// <summary>
		///     Following code will execute when upload image button gets clicked
		/// </summary>
		private void ButtonClick(object sender, RoutedEventArgs e)
		{

		}




		/// <summary>
		///     Following code will execute when save button gets clicked
		/// </summary>
		private void BtnSaveClick(object sender, RoutedEventArgs e)
		{

		}

		/// <summary>
		///     following method will check for internet connection if its there it will return true otherwise false
		/// </summary>

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

		/// <summary>
		///     following method will execute whenever the text in phone number textbox gets changed
		/// </summary>
		private void TextBoxPhonenumberTextChanged(object sender, TextChangedEventArgs e)
		{
			MainSnackbar.MessageQueue.Enqueue(
				"Make sure you give correct phone number to recive OTP to activate your acoount");

		}

		/// <summary>
		///     back button code which is at top left corner
		/// </summary>
		private void BackButton_OnClick(object sender, RoutedEventArgs e)
		{
			new LoggedIn().Show();
			Hide();
		}

		/// <summary>
		///     following method will clear the textbox values
		/// </summary>
		private void Btn_clear_details_OnClick(object sender, RoutedEventArgs e)
		{
			TextBoxPhonenumber.Text = TextBoxAddress.Text = TextBoxEmail.Text = TextBoxFirstname.Text = TextBoxLastname.Text = TextBoxPass.Password = MyDatePicker.Text = "";

			new ImageSourceConverter();
			AccountHolderImage.Source = null;
		}
	}
}
