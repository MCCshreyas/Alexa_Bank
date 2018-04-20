using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace WPFBankApplication
{
    /// <summary>
    /// Interaction logic for EditPersonalDetails.xaml
    /// </summary>
    public partial class EditPersonalDetails
    {
        private OpenFileDialog fileDialog;
        private readonly string Accc;
        private string _imageFilePath = "";

        public EditPersonalDetails(string accountNumber)
        {
            InitializeComponent();
            Accc = accountNumber;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            Hide();
            new AccountSettings(Accc).Show();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_phonenumber_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            
            
        }
            
    }
}
