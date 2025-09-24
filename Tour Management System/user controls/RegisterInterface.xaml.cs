using System.Windows.Controls;
using Tour_Management_System.windows;

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

        private void PbPassword_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            GridPassRules.Visibility = System.Windows.Visibility.Visible;
        }

        private void PbPassword_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            GridPassRules.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
