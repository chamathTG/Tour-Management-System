using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tour_Management_System.windows;

namespace Tour_Management_System.user_controls
{
    public partial class LoginInterface : UserControl
    {
        private Login _mainWindow;
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-02U6DME\\SQLEXPRESS;Initial Catalog=DB_TourManageSys;Integrated Security=True;");

        public LoginInterface(Login mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        //Database Table Validation
        private bool ValidateUser(string table, string username, string password)
        {
            string query = $"SELECT COUNT(1) FROM {table} WHERE Username=@username AND Password=@password";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                int count = (int)command.ExecuteScalar();
                return count == 1;
            }
        }

        //Reset Text
        private void BttnReset_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mainWindow.SwitchUserControl(new ResetInterface(_mainWindow));
        }

        //Register Text
        private void BttnRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            _mainWindow.SwitchUserControl(new RegisterInterface(_mainWindow));
        }

        //Login Button
        private void BttnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbUsername.Text))
            {
                MessageBox.Show("Username is Empty!");
            }

            if (string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Password is Empty!");
            }

            //-------------------

            string username = TbUsername.Text;
            string password = PbPassword.Password;

            try
            {
                connection.Open();

                if (ValidateUser("Admin", username, password))
                {
                    new Admin().Show();
                    Window.GetWindow(this).Close();
                    return;
                }

                MessageBox.Show("Invalid Username or password!");

            }
            finally
            {
                connection.Close();
            }
        }

        //Username
        private void TbUsername_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[a-zA-Z0-9.@]+$");
        }

        private void TbUsername_Pasting(object sender, System.Windows.DataObjectPastingEventArgs e)
        {
            string input = e.DataObject.GetData(DataFormats.Text) as string;

            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9.@]+$"))
            {
                e.CancelCommand();
            }
        }

        private void TbUsername_PreviewKeyDown(object sender, KeyEventArgs e)
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
    }
}
