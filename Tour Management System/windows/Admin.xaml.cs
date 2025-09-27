using System.Windows;

namespace Tour_Management_System.windows
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void BttnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login windowLogin = new Login();
            windowLogin.Show();

            this.Close();
        }

        private void BttnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BttnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
