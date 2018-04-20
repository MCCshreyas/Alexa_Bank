using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Process = System.Diagnostics.Process;

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

        private void Button1Click(object sender, RoutedEventArgs e)
        {
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

        #region ForgetModulesClickEvent

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
        #endregion

        #region FloatingButtonControls

        private void ButtonGitHub_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/MCCshreyas");

        }

        private void ButtonEmail_OnClick(object sender, RoutedEventArgs e)
        {
            DialogBox.Show("Contact", "Email - shreyasjejurkar123@live.com", "OK");
        }

        private void ButtonTwitter_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://twitter.com/MCCshreyas");
        }

        #endregion

        private void LoggedIn_OnLoaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
