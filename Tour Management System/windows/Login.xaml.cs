using System.Windows;
using System.Windows.Controls;
using Tour_Management_System.user_controls;

namespace Tour_Management_System.windows
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            GridLogin.Children.Add(new LoginInterface());
        }

        public void SwitchUserControl(UserControl newControl)
        {
            GridLogin.Children.Clear();
            GridRegister.Children.Add(newControl);
        }

        private void BttnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BttnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
