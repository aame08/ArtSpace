using Art_space.ViewModels;
using System.Windows.Controls;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagingReviews.xaml
    /// </summary>
    public partial class ManagingReviews : Page
    {
        public static ManagingReviews managingReviews;
        public ManagingReviews()
        {
            InitializeComponent();

            managingReviews = this;

            DataContext = new BrowseAccount();
        }
    }
}
