using Art_space.ViewModels;
using System.Windows.Controls;

namespace Art_space.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagingEvaluations.xaml
    /// </summary>
    public partial class ManagingEvaluations : Page
    {
        public static ManagingEvaluations managingEvaluations;
        public ManagingEvaluations()
        {
            InitializeComponent();

            managingEvaluations = this;

            DataContext = new BrowseAccount();
        }
    }
}
