using Art_space.ViewModels;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public static Registration registration;

        private BrowseUsers _browseUsers;

        public Registration()
        {
            InitializeComponent();

            registration = this;

            _browseUsers = new BrowseUsers();
            DataContext = _browseUsers;
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            registration.Visibility = Visibility.Hidden;
        }

        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                string password = new NetworkCredential(string.Empty, passwordBox.SecurePassword).Password;
                _browseUsers.PasswordUser = password;
            }
        }

        private void toggleShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (toggleShowPassword.IsChecked == true)
            {
                pbPassword.Visibility = Visibility.Collapsed;
                tbPassword.Visibility = Visibility.Visible;
                tbPassword.Text = pbPassword.Password;
                toggleShowPassword.Content = "👁️‍🗨️";
            }
            else
            {
                pbPassword.Visibility = Visibility.Visible;
                tbPassword.Visibility = Visibility.Collapsed;
                pbPassword.Password = tbPassword.Text;
                toggleShowPassword.Content = "👁";
            }
        }
    }
}
