using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tour_Management_System.windows;
using static System.Net.Mime.MediaTypeNames;

namespace Tour_Management_System.user_controls
{
    public partial class RegisterInterface : UserControl
    {
        private Login _mainWindow;
        
        public RegisterInterface(Login mainWindow)
        {
            InitializeComponent();

            _mainWindow = mainWindow;
        }

        private void BttnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainWindow.SwitchUserControl(new LoginInterface(_mainWindow));
        }

        private void CbTermsCondition_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            BttnRegister.IsEnabled = true;
        }

        private void CbTermsCondition_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            BttnRegister.IsEnabled = false;
        }

        private void PbPassword_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            GridPassRules.Visibility = Visibility.Visible;
        }

        private void PbPassword_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            GridPassRules.Visibility = Visibility.Collapsed;
        }

        //Name
        private void TbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[a-zA-Z ]+$");
        }

        private void TbName_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            string input = e.DataObject.GetData(DataFormats.Text) as string;

            if (!Regex.IsMatch(input, @"^[a-zA-Z ]+$"))
            {
                e.CancelCommand();
            }
        }

        //Username
        private void TbUsername_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[a-zA-Z0-9]+$");
        }

        private void TbUsername_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            string input = e.DataObject.GetData(DataFormats.Text) as string;

            if(!Regex.IsMatch(input, @"^[a-zA-Z0-9]+$"))
            {
                e.CancelCommand();
            }
        }

        private void TbUsername_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        //Email
        private void TbEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[a-zA-Z0-9@.]+$");
        }

        private void TbEmail_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            string input = e.DataObject.GetData(DataFormats.Text) as string;

            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9@.]+$"))
            {
                e.CancelCommand();
            }
        }

        private void TbEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        //Contact Number
        private void TbContactNumber_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9-+]+$");
        }

        private void TbContactNumber_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            string input = e.DataObject.GetData(DataFormats.Text) as string;

            if (!Regex.IsMatch(input, @"[0-9-+]+$"))
            {
                e.CancelCommand();
            }
        }

        private void TbContactNumber_PreviewKeyDown(object sender, KeyEventArgs e)
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

        //Reset Pin
        private void PbResetPin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[a-zA-Z0-9.*$#@!&]+$");
        }

        private void PbResetPin_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            string input = e.DataObject.GetData(DataFormats.Text) as string;

            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9.*$#@!&]+$"))
            {
                e.CancelCommand();
            }
        }

        private void PbResetPin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
