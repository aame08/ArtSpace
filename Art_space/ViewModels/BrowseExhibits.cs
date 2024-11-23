using Art_space.Models;
using Art_space.Services;
using Art_space.Views;
using DevExpress.Mvvm;
using System.ComponentModel;

namespace Art_space.ViewModels
{
    public class BrowseExhibits : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BrowseExhibits()
        {
            Exhibits = ExhibitsService.GetAllExhibits();
        }

        private List<Exhibit> _exhibits = ExhibitsService.GetAllExhibits();
        public List<Exhibit> Exhibits
        {
            get { return _exhibits; }
            set
            {
                _exhibits = value;
                NotifyPropertyChanged(nameof(Exhibits));
                NotifyPropertyChanged(nameof(UCExhibits));
            }
        }
        public List<UCExhibit> UCExhibits
        {
            get { return Exhibits.Select(e => new UCExhibit(e)).ToList(); }
        }

        private List<Exhibit> _topExhibits = ExhibitsService.GetTopViewedExhibits();
        public List<Exhibit> TopExhibits
        {
            get { return _topExhibits; }
            set
            {
                _topExhibits = value;
                NotifyPropertyChanged(nameof(TopExhibits));
                NotifyPropertyChanged(nameof(UCTopExhibits));
            }
        }
        public List<UCExhibit> UCTopExhibits
        {
            get { return TopExhibits.Select(e => new UCExhibit(e)).ToList(); }
        }

        // Фильтрация и поиск.
        public List<string> Filters { get; set; } = ExhibitsService.GetAllArtForm();
        public string SelectedFilter
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: UpdateExhibits); }
        }
        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                NotifyPropertyChanged(nameof(Search));
                UpdateExhibits();
            }
        }
        private void UpdateExhibits()
        {
            var currentExhibits = ExhibitsService.GetAllExhibits();
            if (!string.IsNullOrEmpty(SelectedFilter))
            {
                currentExhibits = currentExhibits.Where(e => SelectedFilter == "Все виды искусств" || e.IdArtFormNavigation.NameAF == SelectedFilter).ToList();
            }
            if (!string.IsNullOrEmpty(Search))
            {
                currentExhibits = currentExhibits.Where(e => e.NameExhibit.ToLower().Contains(Search.ToLower()) || e.IdAuthors.Any(a => a.NameAuthor.ToLower().Contains(Search.ToLower()) || a.SurnameAuthor.ToLower().Contains(Search.ToLower()))).ToList();
            }

            Exhibits = currentExhibits;
        }
    }
}
