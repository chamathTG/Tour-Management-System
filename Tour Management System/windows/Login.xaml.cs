using System.Windows;

namespace Tour_Management_System.windows
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
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
