using System.Windows.Controls;
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
    }
}
