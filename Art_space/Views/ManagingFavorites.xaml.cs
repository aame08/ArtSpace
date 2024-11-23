using Art_space.ViewModels;
using System.Windows.Controls;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagingFavorites.xaml
    /// </summary>
    public partial class ManagingFavorites : Page
    {
        public static ManagingFavorites managingFavorites;
        public ManagingFavorites()
        {
            InitializeComponent();

            managingFavorites = this;

            DataContext = new BrowseAccount();
        }
    }
}
