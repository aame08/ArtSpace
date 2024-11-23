using Art_space.Models;
using Art_space.ViewModels;
using System.Windows.Controls;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для ExhibitInfo.xaml
    /// </summary>
    public partial class ExhibitInfo : Page
    {
        public static ExhibitInfo exhibitInfo;
        private BrowseExhibitInfo _exhibitInfo;

        public ExhibitInfo(Exhibit exhibit)
        {
            InitializeComponent();

            exhibitInfo = this;

            _exhibitInfo = new BrowseExhibitInfo(exhibit);
            DataContext = _exhibitInfo;
        }

        private void bExit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            exhibitInfo.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
