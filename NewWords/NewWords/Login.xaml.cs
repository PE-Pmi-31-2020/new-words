using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL;


namespace NewWords
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            Authorization auth = new Authorization();
            if (auth.TryLogin(username, password))
            {
                MessageBox.Show("Successfully logged in!");
                Session session = new Session();
                int sessionId = session.getSessionId(username);
                MainWindow mainWindow = new MainWindow(sessionId);
                mainWindow.Show();
                return;
            }
            MessageBox.Show("Invalid credentials.");
            
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            Authorization auth = new Authorization();
            if (auth.TrySignup(username, password))
            {
                MessageBox.Show("Successfully signed up!");
                return;
            }
            MessageBox.Show("There is already a registered user with that email");
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
