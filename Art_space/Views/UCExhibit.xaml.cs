using Art_space.Models;
using Art_space.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для UCExhibit.xaml
    /// </summary>
    public partial class UCExhibit : UserControl
    {
        public static UCExhibit ucExhibit;

        public Exhibit Exhibit { get; private set; }
        Exhibit exhibit_info = new Exhibit();

        public UCExhibit(Exhibit exhibit)
        {
            InitializeComponent();

            ucExhibit = this;

            this.DataContext = this;

            using (var context = new ArtSpaceContext())
            {
                this.Exhibit = context.Exhibits
                    .Include(e => e.Images)
                    .FirstOrDefault(e => e.IdExhibit == exhibit.IdExhibit);
            }
            exhibit_info = exhibit;
        }

        private void bView_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.mainWindow.frameForEveryone.Visibility = System.Windows.Visibility.Visible;
            MainWindow.mainWindow.frameForEveryone.NavigationService.Navigate(new ExhibitInfo(exhibit_info));
        }
    }
}
