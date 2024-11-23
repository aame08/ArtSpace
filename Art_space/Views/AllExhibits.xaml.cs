using Art_space.ViewModels;
using System.Windows.Controls;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для AllExhibits.xaml
    /// </summary>
    public partial class AllExhibits : Page
    {
        public static AllExhibits allExhibits;
        public AllExhibits()
        {
            InitializeComponent();

            allExhibits = this;

            DataContext = new BrowseAdmin();
        }
    }
}
