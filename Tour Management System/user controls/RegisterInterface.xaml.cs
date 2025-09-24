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
            
        }
    }
}
