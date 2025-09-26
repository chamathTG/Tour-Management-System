using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Tour_Management_System.windows;

namespace Tour_Management_System.user_controls
{
    public partial class RegisterInterface : UserControl
    {
        private Login _mainWindow;
        private readonly Regex checkSymbols = new Regex(@"[.*$#@!&]");
        private readonly Regex checkNumbers = new Regex(@"[0-9]");

        public RegisterInterface(Login mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void BttnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainWindow.SwitchUserControl(new LoginInterface(_mainWindow));
        }

        private void BttnRegister_Click(object sender, RoutedEventArgs e)
        {
            bool fieldsEmpty = GridRegisterInterface.Children.OfType<Control>().Any
                (field => (field is TextBox tb && string.IsNullOrWhiteSpace(tb.Text)) || (field is PasswordBox pb && string.IsNullOrWhiteSpace(pb.Password)));

            if (fieldsEmpty)
            {
                MessageBox.Show("Please fill the all the details!");
            }
        }

        private void CbTermsCondition_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            BttnRegister.IsEnabled = true;
        }

        private void CbTermsCondition_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            BttnRegister.IsEnabled = false;
        }

        //Name
        private void TbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[a-zA-Z]+$");
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

            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9]+$"))
            {
                e.CancelCommand();
            }
        }

        private void TbUsername_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
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

        private void PbPassword_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            GridPassRules.Visibility = Visibility.Visible;
        }

        private void PbPassword_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            GridPassRules.Visibility = Visibility.Collapsed;
        }

        private void PbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (checkNumbers.IsMatch(PbPassword.Password))
            {
                TbPassRule01.Foreground = (Brush)new BrushConverter().ConvertFrom("#00cc00");
            }
            else
            {
                TbPassRule01.Foreground = (Brush)new BrushConverter().ConvertFrom("#a6a6a6");
            }

            if (checkSymbols.IsMatch(PbPassword.Password))
            {
                TbPassRule02.Foreground = (Brush)new BrushConverter().ConvertFrom("#00cc00");
            }
            else
            {
                TbPassRule02.Foreground = (Brush)new BrushConverter().ConvertFrom("#a6a6a6");
            }

            if (PbPassword.Password.Length >= 5)
            {
                TbPassRule03.Foreground = (Brush)new BrushConverter().ConvertFrom("#00cc00");
            }
            else
            {
                TbPassRule03.Foreground = (Brush)new BrushConverter().ConvertFrom("#a6a6a6");
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
