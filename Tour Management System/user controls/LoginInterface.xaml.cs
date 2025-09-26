using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tour_Management_System.windows;

namespace Tour_Management_System.user_controls
{
    public partial class LoginInterface : UserControl
    {
        private Login _mainWindow;

        public LoginInterface(Login mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void BttnReset_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mainWindow.SwitchUserControl(new ResetInterface(_mainWindow));
        }

        private void BttnRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            _mainWindow.SwitchUserControl(new RegisterInterface(_mainWindow));
        }

        private void BttnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbUsername.Text))
            {
                MessageBox.Show("Username is Empty!");
            }

            if (string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Password is Empty!");
            }
        }

        //Username
        private void TbUsername_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[a-zA-Z0-9]+$");
        }

        private void TbUsername_Pasting(object sender, System.Windows.DataObjectPastingEventArgs e)
        {
            string input = e.DataObject.GetData(DataFormats.Text) as string;

            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9]+$"))
            {
                e.CancelCommand();
            }
        }

        private void TbUsername_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        //Password
        private void PbPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[a-zA-Z0-9.*$#@!&]+$");
        }

        private void PbPassword_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            string input = e.DataObject.GetData(DataFormats.Text) as string;

            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9.*$#@!&]+$"))
            {
                e.CancelCommand();
            }
        }

        private void PbPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
