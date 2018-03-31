﻿namespace WPFBankApplication
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    using ExtraTools;
    

    using MaterialDesignThemes.Wpf;

    using Microsoft.Win32;

    using Connection = com.mysql.jdbc.Connection;
    using Exception = System.Exception;

    public partial class NewAccountRegistration
    {
        private OpenFileDialog _fileDialog;
        private int _accc;

        private string _imageFilePath = "";

        public NewAccountRegistration()
        {
            InitializeComponent();
            RadioButtonMale.IsChecked = true;
            MyDatePicker.Focusable = false;
            MyComboBox.SelectedIndex = 2;
        }

        /// <summary>
        ///     Following method will check which radiobutton is checked Male or Female. And will return result accordingly.
        /// </summary>
        private string GetGenderInfo()
        {
            if (RadioButtonMale.IsChecked != null && (bool)RadioButtonMale.IsChecked) return "Male";
            if (RadioButtonFemale.IsChecked != null && (bool)RadioButtonFemale.IsChecked) return "Female";
            return null;
        }

        /// <summary>
        ///     Following code will execute when upload image button gets clicked
        /// </summary>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _fileDialog = new OpenFileDialog { Filter = "Image files | *.jpg" };

                _fileDialog.ShowDialog();
                _imageFilePath = _fileDialog.FileName;
                var img = new ImageSourceConverter();
                AccountHolderImage.SetValue(Image.SourceProperty, img.ConvertFromString(_fileDialog.FileName));
            }
            catch (Exception exception)
            {
                DialogBox.Show("Error", "Something went wrong. " + exception.Message);
            }
        }

        private bool DoDataValidation()
        {
            const int PHONE_NUMBER_LENGTH = 10;

            //saving phone number leangh into a length variable
            var length = TextBoxPhonenumber.Text.Length;

            //checking email validation which returns bool value 
            var isEmailValid = TextBoxEmail.Text.Contains("@");
            var isEmailValid2 = TextBoxEmail.Text.Contains(".com");

            // Is there any textbox is empty or not. If there then it will fire error message
            if (TextBoxFirstname.Text == "" || TextBoxLastname.Text == "" || TextBoxEmail.Text == ""
                || TextBoxPass.Password == "" || TextBoxAddress.Text == ""
                || TextBoxPhonenumber.Text == "" || AccountHolderImage.Source == null
                || MyDatePicker.Text == "")
            {
                DialogBox.Show("Error", "Please enter all field", "OK");
                return false;
            }

            // we are checking phone number here
            if (length < PHONE_NUMBER_LENGTH || length == 0 || length > PHONE_NUMBER_LENGTH)
            {
                DialogBox.Show("Error", "Please check your phone number", "OK");
                return false;
            }

            // we are checking email validation here
            if (isEmailValid && isEmailValid2) return true;
            DialogBox.Show("Error", "Please check your email ID", "OK");
            return false;
        }

        //  if it is check it will return Yes otherwise No
        /// <summary>
        ///     following code will check is MobileNotification checkbox is check or not by user. Please refer design for it.
        /// </summary>
        private string EnableMobileNotifications()
        {
            var isMobileNotifications = CheckBoxMobileNotification.IsChecked != null
                                        && (bool)CheckBoxMobileNotification.IsChecked;

            return isMobileNotifications ? "Yes" : "No";
        }

        
        /// <summary>
        ///     Following is a JAVA code which saves data to database
        /// </summary>
        private void SaveDataToDatabase()
        {
            const int MAX_ACCOUNT_NO = 1000000000;

            var fullName = TextBoxFirstname.Text + " " + TextBoxLastname.Text;

            // following code will generate random number which will be user account number 
            _accc = new Random().Next(MAX_ACCOUNT_NO);

            try
            {
                Class.forName("com.mysql.jdbc.Driver");
                var connection = (Connection)DriverManager.getConnection(
                    Resource.DATABASE_URL,
                    Resource.USERNAME,
                    Resource.PASSWORD);

                var ps = connection.prepareStatement(
                    "insert into info(Name,Address,phone_number,Email,Password,account_number,Balance,ImagePath,Gender,MobileVerification,BirthDate)values(?,?,?,?,?,?,'100',?,?,?,?)");
                ps.setString(1, fullName);
                ps.setString(2, TextBoxAddress.Text);
                ps.setString(3, TextBoxPhonenumber.Text);
                ps.setString(4, TextBoxEmail.Text);
                ps.setString(5, TextBoxPass.Password);
                ps.setString(6, _accc.ToString());
                ps.setString(7, _imageFilePath);
                ps.setString(8, GetGenderInfo());
                ps.setString(9, EnableMobileNotifications());
                ps.setString(10, MyDatePicker.Text);
                ps.executeUpdate();
                connection.close();
                DialogBox.Show("Sucess", "Account created sucessfully", "OK");

                DialogBox.Show("Sucess", "Your account number is " + _accc, "OK");
            }
            catch (SQLException exception)
            {
                DialogBox.Show("Error", "Something went wrong." + exception.Message, "OK");
            }
        }

        /// <summary>
        ///     Following code will execute when save button gets clicked
        /// </summary>
        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            if (Resource.IsInternetAvailable())
            {
                if (!DoDataValidation()) return;
                SaveDataToDatabase();
                new OtpVerification(TextBoxPhonenumber.Text).ShowDialog();
            }
            else
            {
               MainSnackbar.MessageQueue.Enqueue("Please check internet connectivity.");
            }
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
