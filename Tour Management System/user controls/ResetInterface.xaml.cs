using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tour_Management_System.windows;

namespace Tour_Management_System.user_controls
{
    public partial class ResetInterface : UserControl
    {
        private Login _mainWindow;

        public ResetInterface(Login mainWindow)
        {
            InitializeComponent();

            _mainWindow = mainWindow;
        }

        private void BttnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainWindow.SwitchUserControl(new LoginInterface(_mainWindow));
        }

        //Username
        private void TbUsername_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
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

        private void TbUsername_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        //Reset Pin
        private void PbResetPin_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[a-zA-Z0-9.*$#@!&]+$");
        }

        private void PbResetPin_Pasting(object sender, System.Windows.DataObjectPastingEventArgs e)
        {
            string input = e.DataObject.GetData(DataFormats.Text) as string;

            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9.*$#@!&]+$"))
            {
                e.CancelCommand();
            }
        }

        private void PbResetPin_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        //Password
        private void PbNewPassword_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[a-zA-Z0-9.*$#@!&]+$");
        }

        private void PbNewPassword_Pasting(object sender, System.Windows.DataObjectPastingEventArgs e)
        {
            string input = e.DataObject.GetData(DataFormats.Text) as string;

            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9.*$#@!&]+$"))
            {
                e.CancelCommand();
            }
        }

        private void PbNewPassword_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
