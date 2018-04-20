
namespace WPFBankApplication
{
	using System;
	using System.Text.RegularExpressions;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;
	using Twilio.Rest.Api.V2010.Account;
	using Twilio.Types;

	using Exception = System.Exception;

	/// <summary>
	/// The withdraw money.
	/// </summary>
	public partial class WithdrawMoney
    {
        private readonly string accountNum;
        private string remainingBalance;

        /// <summary>
        ///     Following is constructor. Line no 27 code will read the current balance from database user account. Refer
        ///     Operations.cs and
        ///     look for method GetCurrentBalance
        /// </summary>
        // ReSharper disable once StyleCop.SA1642
        public WithdrawMoney(string accountNumber)
        {
            InitializeComponent();
        }
        


        /// <summary>
        ///     following method will execute when withdraw money button gets clicked
        /// </summary>
        private void WithDrawMoneyClick(object sender, RoutedEventArgs e)
        {
        }

	    /// <summary>
        ///     Following code will restrict textbox to only accepts numbers and not chars.
        ///     As details will be numerics and not char
        /// </summary>
        private void WithDrawMoneyTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
       
        private void WithDrawMoneyTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        /// <summary>
        ///     Back button code
        /// </summary>
        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            new Welcome(accountNum).Show();
            Hide();
        }
    }
}
