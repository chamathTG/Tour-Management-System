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

        private void BttnRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            _mainWindow.SwitchUserControl(new RegisterInterface(_mainWindow));
        }

        private void BttnReset_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mainWindow.SwitchUserControl(new ResetInterface(_mainWindow));
        }
    }
}
