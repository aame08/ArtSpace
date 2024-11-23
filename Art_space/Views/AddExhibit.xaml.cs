using Art_space.ViewModels;
using System.Windows.Controls;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для AddExhibit.xaml
    /// </summary>
    public partial class AddExhibit : Page
    {
        public static AddExhibit addExhibit;
        private BrowseAdmin _browseAdmin;
        public AddExhibit()
        {
            InitializeComponent();

            addExhibit = this;

            _browseAdmin = new BrowseAdmin();
            DataContext = _browseAdmin;
        }

        private void lbTechniquesOfExecution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> selectedTechniquesOfExecution = ((ListBox)sender).SelectedItems.Cast<string>().ToList();
            _browseAdmin.SelectedTechniquesOfExecution = selectedTechniquesOfExecution;
        }

        private void lbAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> selectedAuthors = ((ListBox)sender).SelectedItems.Cast<string>().ToList();
            _browseAdmin.SelectedAuthors = selectedAuthors;
        }
    }
}
