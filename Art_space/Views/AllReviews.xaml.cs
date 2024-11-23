using Art_space.ViewModels;
using System.Windows.Controls;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для AllReviews.xaml
    /// </summary>
    public partial class AllReviews : Page
    {
        public static AllReviews allReviews;
        public AllReviews()
        {
            InitializeComponent();

            allReviews = this;

            DataContext = new BrowseAdmin();
        }
    }
}
