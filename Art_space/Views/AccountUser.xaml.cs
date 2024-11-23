using Art_space.ViewModels;
using System.Windows.Controls;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для AccountUser.xaml
    /// </summary>
    public partial class AccountUser : Page
    {
        public static AccountUser accountUser;
        public AccountUser()
        {
            InitializeComponent();

            accountUser = this;

            DataContext = new BrowseUsers();
        }
    }
}
