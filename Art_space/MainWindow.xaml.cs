using Art_space.ViewModels;
using Art_space.Views;
using System.Windows;

namespace Art_space
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public MainWindow()
        {
            InitializeComponent();

            mainWindow = this;

            DataContext = new BrowseExhibits();
        }

        private void bEnter_Click(object sender, RoutedEventArgs e)
        {
            frameToAuthorizationOrRegistration.NavigationService.Navigate(new Authorization(), Visibility.Visible);
        }

        private void bRegistration_Click(object sender, RoutedEventArgs e)
        {
            frameToAuthorizationOrRegistration.NavigationService.Navigate(new Registration(), Visibility.Visible);
        }
    }
}