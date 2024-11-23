using Art_space.Models;
using Art_space.Services;
using Art_space.ViewModels;
using System.Windows.Controls;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для EditExhibit.xaml
    /// </summary>
    public partial class EditExhibit : Page
    {
        public static EditExhibit editExhibit;

        private BrowseAdmin _browseAdmin;
        public static List<string> SelectedAuthors;
        public static List<string> SelectedTechniques;

        public EditExhibit(Exhibit exhibit)
        {
            InitializeComponent();

            editExhibit = this;

            _browseAdmin = new BrowseAdmin();
            DataContext = _browseAdmin;
            _browseAdmin.SelectedExhibit = exhibit;

            SelectedAuthors = ExhibitsService.GetAuthorsByIdExhibit(exhibit.IdExhibit);
            SelectedTechniques = ExhibitsService.GetTechniquesByIdExhibit(exhibit.IdExhibit);

            foreach (var author in SelectedAuthors)
            {
                lbAuthors.SelectedItems.Add(author);
            }
            foreach (var technique in SelectedTechniques)
            {
                lbTechniquesOfExecution.SelectedItems.Add(technique);
            }
        }

        private void lbAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> selectedAuthors = ((ListBox)sender).SelectedItems.Cast<string>().ToList();
            _browseAdmin.SelectedAuthors = selectedAuthors;
        }

        private void lbTechniquesOfExecution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> selectedTecniques = ((ListBox)sender).SelectedItems.Cast<string>().ToList();
            _browseAdmin.SelectedTechniquesOfExecution = selectedTecniques;
        }
    }
}
