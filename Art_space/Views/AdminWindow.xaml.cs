using Art_space.ViewModels;
using System.Windows;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public static AdminWindow adminWindow;
        public AdminWindow()
        {
            InitializeComponent();

            adminWindow = this;

            DataContext = new BrowseAdmin();

            frameForEveryone.Visibility = Visibility.Visible;
            frameForEveryone.NavigationService.Navigate(new AllExhibits());
        }
    }
}
