using BankLibrary;
using System;
using System.Windows;
using System.Windows.Input;

namespace Alexa_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_acc_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ForgetAccountNumberHyperLink_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ForgetpasswordHyperLink1_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private bool DoValidation()
        {
            if (TextBoxAcc.Text.Equals(string.Empty) && PasswordBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Please enter all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DoValidation())
                {
                    if (Authentication.Authenticate(TextBoxAcc.Text, PasswordBox.Text))
                    {
                        MessageBox.Show("Sucess");
                        Hide();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonGitHub_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonTwitter_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonEmail_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
