using System.Windows;

namespace Tour_Management_System.windows
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        //Logout Button
        private void BttnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login windowLogin = new Login();
            windowLogin.Show();

            this.Close();
        }

        //Close Button
        private void BttnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Minimize Button
        private void BttnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
