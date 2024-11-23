using Art_space.Models;
using Art_space.Models.Data;
using Art_space.Services;
using Art_space.Views;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace Art_space.ViewModels
{
    public class BrowseAdmin : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BrowseAdmin()
        {
            LoadExhibits();
            LoadReviews();
        }

        //// Экспонаты.
        // Просмотр всех экспонатов.
        private RelayCommand _viewExhibitsWnd;
        public RelayCommand ViewExhibitsWnd
        {
            get
            {
                return _viewExhibitsWnd ?? new RelayCommand(obj =>
                {
                    ViewExhibitsWndMethod();
                });
            }
        }
        public void ViewExhibitsWndMethod()
        {
            AdminWindow.adminWindow.frameForEveryone.Visibility = Visibility.Visible;
            AdminWindow.adminWindow.frameForEveryone.NavigationService.Navigate(new AllExhibits());
        }

        private List<Exhibit> _exhibits;
        private List<Exhibit> _originalExhibits;
        public List<Exhibit> Exhibits
        {
            get { return _exhibits; }
            set
            {
                _exhibits = value;
                NotifyPropertyChanged(nameof(Exhibits));
            }
        }
        private void LoadExhibits()
        {
            _originalExhibits = ExhibitsService.GetAllExhibits();
            _exhibits = _originalExhibits;

            _countries = ["Австралия", "Австрия", "Азербайджан", "Албания", "Алжир", "Ангола", "Антигуа и Барбуда", "Аргентина", "Армения", "Афганистан",
                                        "Багамские Острова", "Бангладеш", "Барбадос", "Беларусь", "Бельгия", "Белиз", "Бенин", "Ботсвана", "Бразилия", "Бруней", "Болгария", "Буркина-Фасо", "Бурунди", "Бутан",
                                        "Венгрия", "Венесуэла", "Вьетнам", "Габон", "Гаити", "Гайана", "Гамбия", "Гана", "Гватемала", "Гвинея", "Гвинея-Бисау", "Германия", "Гренада", "Греция", "Грузия",
                                        "Дания", "Джибути", "Доминика", "Доминиканская Республика", "Египет",
                                        "Замбия", "Зимбабве", "Израиль", "Индия", "Индонезия", "Иордания", "Ирак", "Иран", "Ирландия", "Исландия", "Испания", "Италия", "Йемен",
                                        "Кабо-Верде", "Казахстан", "Камбоджа", "Камерун", "Канада", "Катар", "Кения", "Киргизия", "Кирибати", "Китай", "Колумбия", "Коморы", "Коста-Рика", "Кот-д’Ивуар", "Куба", "Кувейт",
                                        "Лаос", "Лесото", "Ливан", "Либерия", "Ливия", "Лихтенштейн", "Люксембург",
                                        "Маврикий", "Мавритания", "Мадагаскар", "Малави", "Малайзия", "Мали", "Мальдивы", "Мальта", "Марокко", "Маршалловы Острова", "Мексика", "Мозамбик", "Молдавия", "Монако", "Монголия", "Мьянма",
                                        "Намибия", "Науру", "Непал", "Нидерланды", "Никарагуа", "Нигер", "Нигерия", "Норвегия", "Новая Зеландия", "ОАЭ", "Оман",
                                        "Пакистан", "Палау", "Панама", "Папуа — Новая Гвинея", "Парагвай", "Перу", "Польша", "Португалия", "Республика Корея", "Россия", "Руанда", "Румыния",
                                        "Сальвадор", "Самоа", "Сан-Марино", "Сан-Томе и Принсипи", "Саудовская Аравия", "Сенегал", "Сербия", "Сейшелы", "Сингапур", "Сирия", "Словакия", "Словения", "Сомали", "Судан", "Суринам", "США", "Сьерра-Леоне",
                                        "Таджикистан", "Таиланд", "Танзания", "Того", "Тонга", "Тринидад и Тобаго", "Тувалу", "Тунис", "Туркменистан", "Турция",
                                        "Уганда", "Узбекистан", "Украина", "Уругвай", "Фиджи", "Филиппины", "Финляндия", "Франция",
                                        "Хорватия", "Центральноафриканская Республика", "Чад", "Черногория", "Чехия", "Швейцария", "Швеция", "Шри-Ланка",
                                        "Эквадор", "Эритрея", "Эсватини", "Эстония", "Эфиопия", "ЮАР", "Южный Судан", "Ямайка", "Япония"];
            _epochs = ExhibitsService.GetEpochs();
            _artForms = ExhibitsService.GetArtForms();
            _genres = ExhibitsService.GetGenres();
            _storageLocations = ExhibitsService.GetStorageLocations();
            _authors = ExhibitsService.GetAuthors();
            _techniquesOfExecution = ExhibitsService.GetTechniquesOfExecution();
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
            var filteredExhibits = _originalExhibits.AsQueryable();

            if (!string.IsNullOrEmpty(SelectedFilter) && SelectedFilter != "Все виды искусств")
            {
                filteredExhibits = filteredExhibits.Where(e => e.IdArtFormNavigation.NameAF == SelectedFilter);
            }

            if (!string.IsNullOrEmpty(Search))
            {
                filteredExhibits = filteredExhibits.Where(e => e.NameExhibit.ToLower().Contains(Search.ToLower()));
            }

            Exhibits = filteredExhibits.ToList();
        }

        //// Закрытие добавления.
        private RelayCommand _closeAddExhibitWnd;
        public RelayCommand CloseAddExhibitWnd
        {
            get
            {
                return _closeAddExhibitWnd ?? new RelayCommand(obj =>
                {
                    CloseAddExhibitWndMethod();
                });
            }
        }
        public void CloseAddExhibitWndMethod()
        {
            AdminWindow.adminWindow.frameForEveryone.Visibility = Visibility.Visible;
            AdminWindow.adminWindow.frameForEveryone.NavigationService.Navigate(new AllExhibits());
        }

        //// Добавление.
        private RelayCommand _openAddExhibitWnd;
        public RelayCommand OpenAddExhibitWnd
        {
            get
            {
                return _openAddExhibitWnd ?? new RelayCommand(obj =>
                {
                    OpenAddExhibitWndMethod();
                });
            }
        }
        public void OpenAddExhibitWndMethod()
        {
            AdminWindow.adminWindow.frameForEveryone.Visibility = Visibility.Visible;
            AdminWindow.adminWindow.frameForEveryone.NavigationService.Navigate(new AddExhibit());
        }

        //// Добавление жанра.
        private string _nameGenre;
        public string NameGenre
        {
            get { return _nameGenre; }
            set
            {
                _nameGenre = value;
                NotifyPropertyChanged(nameof(NameGenre));
            }
        }
        private RelayCommand _addGenreWnd;
        public RelayCommand AddGenreWnd
        {
            get
            {
                return _addGenreWnd ?? new RelayCommand(obj =>
                {
                    AddGenreWndMethod();
                });
            }
        }
        // Проверка данных на валидность.
        private bool IsNameGenreExists(string name)
        {
            using (var context = new ArtSpaceContext())
            {
                return context.Genres.Any(u => u.NameGenre == name);
            }
        }
        private bool IsNameGenreValidAndUnique(string name)
        {
            if (IsNameGenreExists(name))
                return false;
            if (string.IsNullOrEmpty(name))
                return false;
            if (name.Any(char.IsDigit))
                return false;
            if (name.Length > 100)
                return false;
            var regex = new Regex(@"^[А-ЯЁ][а-яё]*(\s[а-яё]+)*$");
            return regex.IsMatch(name);
        }
        public void AddGenreWndMethod()
        {
            if (IsNameGenreValidAndUnique(NameGenre))
            {
                using (var context = new ArtSpaceContext())
                {
                    var newGenre = new Genre
                    {
                        IdGenre = context.Genres.Any() ? context.Genres.Max(g => g.IdGenre) + 1 : 1,
                        NameGenre = NameGenre
                    };
                    context.Genres.Add(newGenre);
                    context.SaveChanges();

                    MessageBox.Show("Новый жанр добавлен.");

                    Genres.Add(newGenre.NameGenre);
                    NotifyPropertyChanged(nameof(Genres));
                    NameGenre = null;
                }
            }
            else { MessageBox.Show("Неверный формат данных."); }
        }

        //// Добавление места хранения.
        private string _nameStorageLocation;
        public string NameStorageLocation
        {
            get { return _nameStorageLocation; }
            set
            {
                _nameStorageLocation = value;
                NotifyPropertyChanged(nameof(NameStorageLocation));
            }
        }
        private string _countryStorageLocation;
        public string CountryStorageLocation
        {
            get { return _countryStorageLocation; }
            set
            {
                _countryStorageLocation = value;
                NotifyPropertyChanged(nameof(CountryStorageLocation));
            }
        }
        private string _cityStorageLocation;
        public string CityStorageLocation
        {
            get { return _cityStorageLocation; }
            set
            {
                _cityStorageLocation = value;
                NotifyPropertyChanged(nameof(CityStorageLocation));
            }
        }
        private RelayCommand _addStorageLocationWnd;
        public RelayCommand AddStorageLocationWnd
        {
            get
            {
                return _addStorageLocationWnd ?? new RelayCommand(obj =>
                {
                    AddStorageLocationWndMethod();
                });
            }
        }
        // Проверка данных на валидность.
        private bool IsNameStorageLocationExists(string name)
        {
            using (var context = new ArtSpaceContext())
            {
                return context.StorageLocations.Any(s => s.NameSL == name);
            }
        }
        private bool IsNameStorageLocationValidAndUnique(string name)
        {
            if (IsNameStorageLocationExists(name))
                return false;
            if (string.IsNullOrEmpty(name))
                return false;
            if (name.Any(char.IsDigit))
                return false;
            if (name.Length > 50)
                return false;
            var regex = new Regex(@"^[А-ЯЁ][а-яё]*(\s[А-ЯЁ][а-яё]*)*$");
            return regex.IsMatch(name);
        }
        private bool IsCityValid(string city)
        {
            if (string.IsNullOrEmpty(city))
                return false;
            if (city.Any(char.IsDigit))
                return false;
            if (city.Length > 100)
                return false;
            var regex = new Regex(@"^([А-ЯЁ][а-яё]+)([- ]([А-ЯЁ][а-яё]+))*$");
            return regex.IsMatch(city);
        }
        public void AddStorageLocationWndMethod()
        {
            if (IsNameStorageLocationValidAndUnique(NameStorageLocation) && CountryStorageLocation != null && IsCityValid(CityStorageLocation))
            {
                using (var context = new ArtSpaceContext())
                {
                    var newStorageLocation = new StorageLocation
                    {
                        IdStorageLocation = context.StorageLocations.Any() ? context.StorageLocations.Max(s => s.IdStorageLocation) + 1 : 1,
                        NameSL = NameStorageLocation,
                        City = CityStorageLocation,
                        Country = CountryStorageLocation
                    };
                    context.StorageLocations.Add(newStorageLocation);
                    context.SaveChanges();

                    MessageBox.Show("Новое место хранения добавлено.");

                    StorageLocations.Add(newStorageLocation.NameSL);
                    NotifyPropertyChanged(nameof(StorageLocations));
                    NameStorageLocation = null;
                    CityStorageLocation = null;
                    CountryStorageLocation = null;
                }
            }
            else { MessageBox.Show("Неверный формат данных."); }
        }

        //// Добавление техники исполнения.
        private string _nameTechnique;
        public string NameTechnique
        {
            get { return _nameTechnique; }
            set
            {
                _nameTechnique = value;
                NotifyPropertyChanged(nameof(NameTechnique));
            }
        }
        private RelayCommand _addTechniqueWnd;
        public RelayCommand AddTechniqueWnd
        {
            get
            {
                return _addTechniqueWnd ?? new RelayCommand(obj =>
                {
                    AddTechniqueWndMethod();
                });
            }
        }
        // Проверка данных на валидность.
        private bool IsNameTechniqueExists(string name)
        {
            using (var context = new ArtSpaceContext())
            {
                return context.TechniqueOfExecutions.Any(t => t.NameET == name);
            }
        }
        private bool IsNameTechniqueValidAndUnique(string name)
        {
            if (IsNameTechniqueExists(name))
                return false;
            if (string.IsNullOrEmpty(name))
                return false;
            if (name.Any(char.IsDigit))
                return false;
            var regex = new Regex(@"^[А-ЯЁ][а-яё]*(\s[а-яё]+)*$");
            return regex.IsMatch(name);
        }
        public void AddTechniqueWndMethod()
        {
            if (IsNameTechniqueValidAndUnique(NameTechnique))
            {
                using (var context = new ArtSpaceContext())
                {
                    var newTechique = new TechniqueOfExecution
                    {
                        IdET = context.TechniqueOfExecutions.Any() ? context.TechniqueOfExecutions.Max(t => t.IdET) + 1 : 1,
                        NameET = NameTechnique
                    };
                    context.TechniqueOfExecutions.Add(newTechique);
                    context.SaveChanges();

                    MessageBox.Show("Новая техника исполнения добавлена.");

                    TechniquesOfExecution.Add(newTechique.NameET);
                    NotifyPropertyChanged(nameof(TechniquesOfExecution));
                    NameTechnique = null;
                }
            }
            else { MessageBox.Show("Неверный формат данных."); }
        }

        //// Добавление автора.
        private string _nameAuthor;
        public string NameAuthor
        {
            get { return _nameAuthor; }
            set
            {
                _nameAuthor = value;
                NotifyPropertyChanged(nameof(NameAuthor));
            }
        }
        private string _surnameAuthor;
        public string SurnameAuthor
        {
            get { return _surnameAuthor; }
            set
            {
                _surnameAuthor = value;
                NotifyPropertyChanged(nameof(SurnameAuthor));
            }
        }
        private string _dateBirth;
        public string DateBirth
        {
            get { return _dateBirth; }
            set
            {
                _dateBirth = value;
                NotifyPropertyChanged(nameof(DateBirth));
            }
        }
        private string _dateDeath;
        public string DateDeath
        {
            get { return _dateDeath; }
            set
            {
                _dateDeath = value;
                NotifyPropertyChanged(nameof(DateDeath));
            }
        }
        private RelayCommand _addAuthorWnd;
        public RelayCommand AddAuthorWnd
        {
            get
            {
                return _addAuthorWnd ?? new RelayCommand(obj =>
                {
                    AddAuthorWndMethod();
                });
            }
        }
        // Проверка данных на валидность.
        private bool IsAuthorExists(string surname, string name)
        {
            using (var context = new ArtSpaceContext())
            {
                return context.Authors.Any(a => a.SurnameAuthor == surname && a.NameAuthor == name);
            }
        }
        private bool IsValidSurnameOrNameAuthor(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            if (str.Any(char.IsDigit))
                return false;
            if (str.Length > 50)
                return false;
            var regex = new Regex(@"^([А-ЯЁ][а-яё]+)([- ]([А-ЯЁ][а-яё]+))?$");
            return regex.IsMatch(str);
        }
        private bool IsValidDate(string date)
        {
            var regex = new Regex(@"^\d{4}-\d{2}-\d{2}$");
            return regex.IsMatch(date);
        }
        private bool IsAuthorValidAndUnique(string surname, string name)
        {
            if (IsAuthorExists(surname, name))
                return false;
            if (!IsValidSurnameOrNameAuthor(surname) || !IsValidSurnameOrNameAuthor(name))
                return false;
            return true;
        }
        public void AddAuthorWndMethod()
        {
            if (IsAuthorValidAndUnique(SurnameAuthor, NameAuthor))
            {
                if (DateDeath != null)
                {
                    if (IsValidDate(DateBirth) && IsValidDate(DateBirth))
                    {
                        using (var context = new ArtSpaceContext())
                        {
                            var newAuthor = new Author
                            {
                                IdAuthor = context.Authors.Any() ? context.Authors.Max(a => a.IdAuthor) + 1 : 1,
                                SurnameAuthor = SurnameAuthor,
                                NameAuthor = NameAuthor,
                                DateBirth = DateOnly.Parse(DateBirth),
                                DateDeath = DateOnly.Parse(DateDeath)
                            };
                            context.Authors.Add(newAuthor);
                            context.SaveChanges();

                            MessageBox.Show("Новый автор добавлен.");

                            Authors.Add(newAuthor.NameAuthor + " " + newAuthor.SurnameAuthor);
                            NotifyPropertyChanged(nameof(Authors));
                            SurnameAuthor = null;
                            NameAuthor = null;
                            DateBirth = null;
                            DateDeath = null;
                        }
                    }
                    else { MessageBox.Show("Неверный формат данных."); }
                }
                else
                {
                    if (IsValidDate(DateBirth))
                    {
                        using (var context = new ArtSpaceContext())
                        {
                            var newAuthor = new Author
                            {
                                IdAuthor = context.Authors.Any() ? context.Authors.Max(a => a.IdAuthor) + 1 : 1,
                                SurnameAuthor = SurnameAuthor,
                                NameAuthor = NameAuthor,
                                DateBirth = DateOnly.Parse(DateBirth),
                                DateDeath = null
                            };
                            context.Authors.Add(newAuthor);
                            context.SaveChanges();

                            MessageBox.Show("Новый автор добавлен.");

                            Authors.Add(newAuthor.NameAuthor + " " + newAuthor.SurnameAuthor);
                            NotifyPropertyChanged(nameof(Authors));
                            SurnameAuthor = null;
                            NameAuthor = null;
                            DateBirth = null;
                            DateDeath = null;
                        }
                    }
                    else { MessageBox.Show("Неверный формат данных."); }
                }
            }
            else { MessageBox.Show("Неверный формат данных."); }
        }

        //// Добавление экспоната.
        private string _nameExhibit;
        public string NameExhibit
        {
            get { return _nameExhibit; }
            set
            {
                _nameExhibit = value;
                NotifyPropertyChanged(nameof(NameExhibit));
            }
        }
        private string _descriptionExhibit;
        public string DescriptionExhibit
        {
            get { return _descriptionExhibit; }
            set
            {
                _descriptionExhibit = value;
                NotifyPropertyChanged(nameof(DescriptionExhibit));
            }
        }
        private string _yearCreation;
        public string YearCreation
        {
            get { return _yearCreation; }
            set
            {
                _yearCreation = value;
                NotifyPropertyChanged(nameof(YearCreation));
            }
        }
        private List<string> _countries;
        public List<string> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                NotifyPropertyChanged(nameof(Countries));
            }
        }
        private string _selectedCountry;
        public string SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                _selectedCountry = value;
                NotifyPropertyChanged(nameof(SelectedCountry));
            }
        }
        private List<string> _epochs;
        public List<string> Epochs
        {
            get { return _epochs; }
            set
            {
                _epochs = value;
                NotifyPropertyChanged(nameof(Epochs));
            }
        }
        private string _selectedEpoch;
        public string SelectedEpoch
        {
            get { return _selectedEpoch; }
            set
            {
                _selectedEpoch = value;
                NotifyPropertyChanged(nameof(SelectedEpoch));
            }
        }
        private List<string> _artForms;
        public List<string> ArtForms
        {
            get { return _artForms; }
            set
            {
                _artForms = value;
                NotifyPropertyChanged(nameof(ArtForms));
            }
        }
        private string _selectedArtForm;
        public string SelectedArtForm
        {
            get { return _selectedArtForm; }
            set
            {
                _selectedArtForm = value;
                NotifyPropertyChanged(nameof(SelectedArtForm));
            }
        }
        private List<string> _genres;
        public List<string> Genres
        {
            get { return _genres; }
            set
            {
                _genres = value;
                NotifyPropertyChanged(nameof(Genres));
            }
        }
        private string _selectedGenre;
        public string SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                _selectedGenre = value;
                NotifyPropertyChanged(nameof(SelectedGenre));
            }
        }
        private List<string> _storageLocations;
        public List<string> StorageLocations
        {
            get { return _storageLocations; }
            set
            {
                _storageLocations = value;
                NotifyPropertyChanged(nameof(StorageLocations));
            }
        }
        private string _selectedStorageLocation;
        public string SelectedStorageLocation
        {
            get { return _selectedStorageLocation; }
            set
            {
                _selectedStorageLocation = value;
                NotifyPropertyChanged(nameof(SelectedStorageLocation));
            }
        }
        private List<string> _authors;
        public List<string> Authors
        {
            get { return _authors; }
            set
            {
                _authors = value;
                NotifyPropertyChanged(nameof(Authors));
            }
        }
        private List<string> _selectedAuthors;
        public List<string> SelectedAuthors
        {
            get { return _selectedAuthors; }
            set
            {
                _selectedAuthors = value;
                NotifyPropertyChanged(nameof(SelectedAuthors));
            }
        }
        private List<string> _techniquesOfExecution;
        public List<string> TechniquesOfExecution
        {
            get { return _techniquesOfExecution; }
            set
            {
                _techniquesOfExecution = value;
                NotifyPropertyChanged(nameof(TechniquesOfExecution));
            }
        }
        private List<string> _selectedTechniquesOfExecution;
        public List<string> SelectedTechniquesOfExecution
        {
            get { return _selectedTechniquesOfExecution; }
            set
            {
                _selectedTechniquesOfExecution = value;
                NotifyPropertyChanged(nameof(SelectedTechniquesOfExecution));
            }
        }
        private string _image1;
        public string Image1
        {
            get { return _image1; }
            set
            {
                _image1 = value;
                NotifyPropertyChanged(nameof(Image1));
            }
        }
        private string _image2;
        public string Image2
        {
            get { return _image2; }
            set
            {
                _image2 = value;
                NotifyPropertyChanged(nameof(Image2));
            }
        }
        private string _image3;
        public string Image3
        {
            get { return _image3; }
            set
            {
                _image3 = value;
                NotifyPropertyChanged(nameof(Image3));
            }
        }
        private string _image4;
        public string Image4
        {
            get { return _image4; }
            set
            {
                _image4 = value;
                NotifyPropertyChanged(nameof(Image4));
            }
        }
        private string _image5;
        public string Image5
        {
            get { return _image5; }
            set
            {
                _image5 = value;
                NotifyPropertyChanged(nameof(Image5));
            }
        }
        private RelayCommand _addExhibitWnd;
        public RelayCommand AddExhibitWnd
        {
            get
            {
                return _addExhibitWnd ?? new RelayCommand(obj =>
                {
                    AddExhibitWndMethod();
                });
            }
        }
        private bool IsNameExhibitExists(string name)
        {
            using (var context = new ArtSpaceContext())
            {
                return context.Exhibits.Any(e => e.NameExhibit == name);
            }
        }
        private bool IsNameExhibitValidAndUnique(string name)
        {
            if (IsNameExhibitExists(name))
                return false;
            if (string.IsNullOrEmpty(name))
                return false;
            if (name.Any(char.IsDigit))
                return false;
            var regex = new Regex(@"^[А-ЯЁ][а-яё]*(\s[а-яё]+)*$");
            return regex.IsMatch(name);
        }
        private bool IsYearCreationValid(string year)
        {
            if (!int.TryParse(year, out int yearValue))
                return false;
            return true;
        }
        private bool IsImagePathValid(string path)
        {
            if (!File.Exists(path))
                return false;
            string[] validExtensions = [".jpg", ".jpeg", ".png"];
            string fileExtension = Path.GetExtension(path).ToLower();
            return validExtensions.Contains(fileExtension);
        }
        public void AddExhibitWndMethod()
        {
            if (NameExhibit != null && DescriptionExhibit != null && YearCreation != null && SelectedCountry != null && SelectedEpoch != null && SelectedArtForm != null && SelectedGenre != null && SelectedStorageLocation != null && Image1 != null && SelectedAuthors.Count > 0 && SelectedTechniquesOfExecution.Count > 0)
            {
                if (IsNameExhibitValidAndUnique(NameExhibit) && IsYearCreationValid(YearCreation))
                {
                    using (var context = new ArtSpaceContext())
                    {
                        // Экспонат.
                        int idEpoch = context.Epoches.FirstOrDefault(e => e.NameEra == SelectedEpoch).IdEra;
                        int idArtForm = context.ArtForms.FirstOrDefault(a => a.NameAF == SelectedArtForm).IdArtForm;
                        int idGenre = context.Genres.FirstOrDefault(g => g.NameGenre == SelectedGenre).IdGenre;
                        int idStorageLocation = context.StorageLocations.FirstOrDefault(s => s.NameSL == SelectedStorageLocation).IdStorageLocation;

                        var newExhibit = new Exhibit
                        {
                            IdExhibit = context.Exhibits.Any() ? context.Exhibits.Max(e => e.IdExhibit) + 1 : 1,
                            NameExhibit = NameExhibit,
                            DescriptionExhibit = DescriptionExhibit,
                            YearCreation = int.Parse(YearCreation),
                            CountryCreation = SelectedCountry,
                            IdEra = idEpoch,
                            IdArtForm = idArtForm,
                            IdGenre = idGenre,
                            IdStorageLocation = idStorageLocation
                        };
                        context.Exhibits.Add(newExhibit);
                        context.SaveChanges();

                        // Изображение(я).
                        if (IsImagePathValid(Image1))
                        {
                            string exhibitPhoto = Path.GetFileName(Image1);
                            string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                            File.Copy(Image1, pathTo, true);

                            var newImage = new Image
                            {
                                IdImage = context.Images.Any() ? context.Images.Max(i => i.IdImage) + 1 : 1,
                                IdExhibit = newExhibit.IdExhibit,
                                Image1 = exhibitPhoto
                            };
                            context.Images.Add(newImage);
                            context.SaveChanges();
                        }
                        else { MessageBox.Show("Неверный путь к файлу изображения."); }
                        if (Image2 != null)
                        {
                            if (IsImagePathValid(Image2))
                            {
                                string exhibitPhoto = Path.GetFileName(Image2);
                                string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                File.Copy(Image2, pathTo, true);

                                var newImage = new Image
                                {
                                    IdImage = context.Images.Any() ? context.Images.Max(i => i.IdImage) + 1 : 1,
                                    IdExhibit = newExhibit.IdExhibit,
                                    Image1 = exhibitPhoto
                                };
                                context.Images.Add(newImage);
                                context.SaveChanges();
                            }
                            else { MessageBox.Show("Неверный путь к файлу изображения."); }
                        }
                        if (Image3 != null)
                        {
                            if (IsImagePathValid(Image3))
                            {
                                string exhibitPhoto = Path.GetFileName(Image3);
                                string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                File.Copy(Image3, pathTo, true);

                                var newImage = new Image
                                {
                                    IdImage = context.Images.Any() ? context.Images.Max(i => i.IdImage) + 1 : 1,
                                    IdExhibit = newExhibit.IdExhibit,
                                    Image1 = exhibitPhoto
                                };
                                context.Images.Add(newImage);
                                context.SaveChanges();
                            }
                            else { MessageBox.Show("Неверный путь к файлу изображения."); }
                        }
                        if (Image4 != null)
                        {
                            if (IsImagePathValid(Image4))
                            {
                                string exhibitPhoto = Path.GetFileName(Image4);
                                string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                File.Copy(Image4, pathTo, true);

                                var newImage = new Image
                                {
                                    IdImage = context.Images.Any() ? context.Images.Max(i => i.IdImage) + 1 : 1,
                                    IdExhibit = newExhibit.IdExhibit,
                                    Image1 = exhibitPhoto
                                };
                                context.Images.Add(newImage);
                                context.SaveChanges();
                            }
                            else { MessageBox.Show("Неверный путь к файлу изображения."); }
                        }
                        if (Image5 != null)
                        {
                            if (IsImagePathValid(Image5))
                            {
                                string exhibitPhoto = Path.GetFileName(Image5);
                                string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                File.Copy(Image5, pathTo, true);

                                var newImage = new Image
                                {
                                    IdImage = context.Images.Any() ? context.Images.Max(i => i.IdImage) + 1 : 1,
                                    IdExhibit = newExhibit.IdExhibit,
                                    Image1 = exhibitPhoto
                                };
                                context.Images.Add(newImage);
                                context.SaveChanges();
                            }
                            else { MessageBox.Show("Неверный путь к файлу изображения."); }
                        }

                        // Автор(ы).
                        foreach (var authorName in SelectedAuthors)
                        {
                            var author = context.Authors.FirstOrDefault(a => (a.NameAuthor + " " + a.SurnameAuthor) == authorName);
                            if (author != null)
                            {
                                newExhibit.IdAuthors.Add(author);
                                context.SaveChanges();
                            }
                        }

                        // Техники исполнения.
                        foreach (var techniqueName in SelectedTechniquesOfExecution)
                        {
                            var technique = context.TechniqueOfExecutions.FirstOrDefault(t => t.NameET == techniqueName);
                            if (technique != null)
                            {
                                newExhibit.IdETs.Add(technique);
                                context.SaveChanges();
                            }
                        }

                        MessageBox.Show("Новый экспонат добавлен.");

                        Exhibits.Add(newExhibit);
                        NotifyPropertyChanged(nameof(Exhibits));

                        AdminWindow.adminWindow.frameForEveryone.NavigationService.Navigate(new AllExhibits(), Visibility.Visible);
                    }
                }
                else { MessageBox.Show("Неверный формат данных."); }
            }
            else { MessageBox.Show("Не все поля заполнены."); }
        }
        //// Редактирование экспоната.
        private Exhibit _selectedExhibit;
        public Exhibit SelectedExhibit
        {
            get { return _selectedExhibit; }
            set
            {
                _selectedExhibit = value;
                NotifyPropertyChanged(nameof(SelectedExhibit));
            }
        }
        private RelayCommand _openEditExhibitWnd;
        public RelayCommand OpenEditExhibitWnd
        {
            get
            {
                return _openEditExhibitWnd ?? new RelayCommand(obj =>
                {
                    OpenEditExhibitWndMethod();
                });
            }
        }
        public void OpenEditExhibitWndMethod()
        {
            if (SelectedExhibit == null)
                return;
            AdminWindow.adminWindow.frameForEveryone.Visibility = Visibility.Visible;
            AdminWindow.adminWindow.frameForEveryone.NavigationService.Navigate(new EditExhibit(SelectedExhibit));
        }

        public string FirstImage
        {
            get
            {
                var firstImage = SelectedExhibit.Images.FirstOrDefault();
                return firstImage != null ? firstImage.Image1 : string.Empty;
            }
            set
            {
                var firstImage = SelectedExhibit.Images.FirstOrDefault();
                if (firstImage != null)
                {
                    firstImage.Image1 = value;
                    NotifyPropertyChanged(nameof(FirstImage));
                }
            }
        }
        public string SecondImage
        {
            get
            {
                var secondImage = SelectedExhibit.Images.Skip(1).FirstOrDefault();
                return secondImage != null ? secondImage.Image1 : string.Empty;
            }
            set
            {
                var secondImage = SelectedExhibit.Images.Skip(1).FirstOrDefault();
                if (secondImage != null)
                {
                    secondImage.Image1 = value;
                    NotifyPropertyChanged(nameof(SecondImage));
                }
            }
        }
        public string ThirdImage
        {
            get
            {
                var thirdImage = SelectedExhibit.Images.Skip(2).FirstOrDefault();
                return thirdImage != null ? thirdImage.Image1 : string.Empty;
            }
            set
            {
                var thirdImage = SelectedExhibit.Images.Skip(2).FirstOrDefault();
                if (thirdImage != null)
                {
                    thirdImage.Image1 = value;
                    NotifyPropertyChanged(nameof(ThirdImage));
                }
            }
        }
        public string FourthImage
        {
            get
            {
                var fourthImage = SelectedExhibit.Images.Skip(3).FirstOrDefault();
                return fourthImage != null ? fourthImage.Image1 : string.Empty;
            }
            set
            {
                var fourthImage = SelectedExhibit.Images.Skip(3).FirstOrDefault();
                if (fourthImage != null)
                {
                    fourthImage.Image1 = value;
                    NotifyPropertyChanged(nameof(FourthImage));
                }
            }
        }
        public string FifthImage
        {
            get
            {
                var fifthImage = SelectedExhibit.Images.Skip(4).FirstOrDefault();
                return fifthImage != null ? fifthImage.Image1 : string.Empty;
            }
            set
            {
                var fifthImage = SelectedExhibit.Images.Skip(4).FirstOrDefault();
                if (fifthImage != null)
                {
                    fifthImage.Image1 = value;
                    NotifyPropertyChanged(nameof(FifthImage));
                }
            }
        }
        // Изменение экспоната.
        private RelayCommand _editExhibitWnd;
        public RelayCommand EditExhibitWnd
        {
            get
            {
                return _editExhibitWnd ?? new RelayCommand(obj =>
                {
                    EditExhibitWndMethod();
                });
            }
        }
        public void EditExhibitWndMethod()
        {
            using (var context = new ArtSpaceContext())
            {
                var exhibitForEdit = context.Exhibits
                    .Include(e => e.IdAuthors)
                    .Include(e => e.IdETs)
                    .Include(e => e.Images)
                    .FirstOrDefault(e => e.IdExhibit == SelectedExhibit.IdExhibit);

                if (exhibitForEdit != null)
                {
                    int idEpoch = context.Epoches.FirstOrDefault(e => e.NameEra == SelectedExhibit.IdEraNavigation.NameEra).IdEra;
                    int idArtForm = context.ArtForms.FirstOrDefault(a => a.NameAF == SelectedExhibit.IdArtFormNavigation.NameAF).IdArtForm;
                    int idGenre = context.Genres.FirstOrDefault(g => g.NameGenre == SelectedExhibit.IdGenreNavigation.NameGenre).IdGenre;
                    int idStorageLocation = context.StorageLocations.FirstOrDefault(s => s.NameSL == SelectedExhibit.IdStorageLocationNavigation.NameSL).IdStorageLocation;

                    if (SelectedExhibit.NameExhibit != exhibitForEdit.NameExhibit)
                    {
                        if (IsNameExhibitValidAndUnique(SelectedExhibit.NameExhibit) && IsYearCreationValid(SelectedExhibit.YearCreation.ToString()))
                        {
                            // Экспонат.
                            exhibitForEdit.NameExhibit = SelectedExhibit.NameExhibit;
                            exhibitForEdit.DescriptionExhibit = SelectedExhibit.DescriptionExhibit;
                            exhibitForEdit.YearCreation = SelectedExhibit.YearCreation;
                            exhibitForEdit.CountryCreation = SelectedExhibit.CountryCreation;
                            exhibitForEdit.IdEra = idEpoch;
                            exhibitForEdit.IdGenre = idGenre;
                            exhibitForEdit.IdStorageLocation = idStorageLocation;
                            //context.SaveChanges();

                            // Изображение(я).
                            var imagesExhibit = exhibitForEdit.Images.ToList();
                            // 1.
                            if (FirstImage != string.Empty)
                            {
                                if (Path.GetFileName(FirstImage) != imagesExhibit[0].Image1)
                                {
                                    if (IsImagePathValid(FirstImage))
                                    {
                                        string exhibitPhoto = Path.GetFileName(FirstImage);
                                        string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                        File.Copy(FirstImage, pathTo, true);

                                        var image = context.Images.FirstOrDefault(i => i.Image1 == imagesExhibit[0].Image1);
                                        if (image != null)
                                        {
                                            image.Image1 = exhibitPhoto;
                                            context.SaveChanges();
                                        }
                                    }
                                    else { MessageBox.Show("Неверный путь к файлу изображения."); }
                                }
                            }
                            else { MessageBox.Show("У экспоната должно быть хоть одно изображение."); }
                            // 2.
                            if (SecondImage != string.Empty && imagesExhibit.ElementAtOrDefault(1)?.Image1 != null)
                            {
                                if (Path.GetFileName(SecondImage) != imagesExhibit[1].Image1)
                                {
                                    if (IsImagePathValid(SecondImage))
                                    {
                                        string exhibitPhoto = Path.GetFileName(SecondImage);
                                        string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                        File.Copy(SecondImage, pathTo, true);

                                        var image = context.Images.FirstOrDefault(i => i.Image1 == imagesExhibit[1].Image1);
                                        if (image != null)
                                        {
                                            image.Image1 = exhibitPhoto;
                                            context.SaveChanges();
                                        }
                                    }
                                    else { MessageBox.Show("Неверный путь к файлу изображения."); }
                                }
                            }
                            else
                            {
                                var imageToDelete = imagesExhibit.ElementAtOrDefault(1);
                                if (imageToDelete != null)
                                {
                                    context.Images.Remove(imageToDelete);
                                    context.SaveChanges();
                                }
                            }
                            // 3.
                            if (ThirdImage != string.Empty && imagesExhibit.ElementAtOrDefault(2)?.Image1 != null)
                            {
                                if (Path.GetFileName(ThirdImage) != imagesExhibit[2].Image1)
                                {
                                    if (IsImagePathValid(ThirdImage))
                                    {
                                        string exhibitPhoto = Path.GetFileName(ThirdImage);
                                        string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                        File.Copy(ThirdImage, pathTo, true);

                                        var image = context.Images.FirstOrDefault(i => i.Image1 == imagesExhibit[2].Image1);
                                        if (image != null)
                                        {
                                            image.Image1 = exhibitPhoto;
                                            context.SaveChanges();
                                        }
                                    }
                                    else { MessageBox.Show("Неверный путь к файлу изображения."); }
                                }
                            }
                            else
                            {
                                var imageToDelete = imagesExhibit.ElementAtOrDefault(2);
                                if (imageToDelete != null)
                                {
                                    context.Images.Remove(imageToDelete);
                                    context.SaveChanges();
                                }
                            }
                            // 4.
                            if (FourthImage != string.Empty && imagesExhibit.ElementAtOrDefault(3)?.Image1 != null)
                            {
                                if (Path.GetFileName(FourthImage) != imagesExhibit[3].Image1)
                                {
                                    if (IsImagePathValid(FourthImage))
                                    {
                                        string exhibitPhoto = Path.GetFileName(FourthImage);
                                        string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                        File.Copy(FourthImage, pathTo, true);

                                        var image = context.Images.FirstOrDefault(i => i.Image1 == imagesExhibit[3].Image1);
                                        if (image != null)
                                        {
                                            image.Image1 = exhibitPhoto;
                                            context.SaveChanges();
                                        }
                                    }
                                    else { MessageBox.Show("Неверный путь к файлу изображения."); }
                                }
                            }
                            else
                            {
                                var imageToDelete = imagesExhibit.ElementAtOrDefault(3);
                                if (imageToDelete != null)
                                {
                                    context.Images.Remove(imageToDelete);
                                    context.SaveChanges();
                                }
                            }
                            // 5.
                            if (FifthImage != string.Empty && imagesExhibit.ElementAtOrDefault(4)?.Image1 != null)
                            {
                                if (Path.GetFileName(FifthImage) != imagesExhibit[4].Image1)
                                {
                                    if (IsImagePathValid(FifthImage))
                                    {
                                        string exhibitPhoto = Path.GetFileName(FifthImage);
                                        string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                        File.Copy(FifthImage, pathTo, true);

                                        var image = context.Images.FirstOrDefault(i => i.Image1 == imagesExhibit[4].Image1);
                                        if (image != null)
                                        {
                                            image.Image1 = exhibitPhoto;
                                            context.SaveChanges();
                                        }
                                    }
                                    else { MessageBox.Show("Неверный путь к файлу изображения."); }
                                }
                            }
                            else
                            {
                                var imageToDelete = imagesExhibit.ElementAtOrDefault(4);
                                if (imageToDelete != null)
                                {
                                    context.Images.Remove(imageToDelete);
                                    context.SaveChanges();
                                }
                            }

                            // Автор(ы).
                            exhibitForEdit.IdAuthors.Clear();
                            context.SaveChanges();
                            foreach (var authorName in SelectedAuthors)
                            {
                                var author = context.Authors.FirstOrDefault(a => (a.NameAuthor + " " + a.SurnameAuthor) == authorName);
                                if (author != null)
                                {
                                    exhibitForEdit.IdAuthors.Add(author);
                                    context.SaveChanges();
                                }
                            }

                            // Техники исполнения.
                            exhibitForEdit.IdETs.Clear();
                            context.SaveChanges();
                            foreach (var techniqueName in SelectedTechniquesOfExecution)
                            {
                                var technique = context.TechniqueOfExecutions.FirstOrDefault(t => t.NameET == techniqueName);
                                if (technique != null)
                                {
                                    exhibitForEdit.IdETs.Add(technique);
                                    context.SaveChanges();
                                }
                            }

                            MessageBox.Show("Информация об экспонате изменена.");
                            AdminWindow.adminWindow.frameForEveryone.NavigationService.Navigate(new AllExhibits(), Visibility.Visible);
                        }
                        else { MessageBox.Show("Неверный формат данных"); }
                    }
                    else
                    {
                        if (IsYearCreationValid(SelectedExhibit.YearCreation.ToString()))
                        {
                            // Изображение(я).
                            var imagesExhibit = exhibitForEdit.Images.ToList();
                            // 1.
                            if (FirstImage != string.Empty)
                            {
                                if (Path.GetFileName(FirstImage) != imagesExhibit[0].Image1)
                                {
                                    if (IsImagePathValid(FirstImage))
                                    {
                                        string exhibitPhoto = Path.GetFileName(FirstImage);
                                        string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                        File.Copy(FirstImage, pathTo, true);

                                        var image = context.Images.FirstOrDefault(i => i.Image1 == imagesExhibit[0].Image1);
                                        if (image != null)
                                        {
                                            image.Image1 = exhibitPhoto;
                                            context.SaveChanges();
                                        }
                                    }
                                    else { MessageBox.Show("Неверный путь к файлу изображения."); }
                                }
                            }
                            else { MessageBox.Show("У экспоната должно быть хоть одно изображение."); }
                            // 2.
                            if (SecondImage != string.Empty && imagesExhibit.ElementAtOrDefault(1)?.Image1 != null)
                            {
                                if (Path.GetFileName(SecondImage) != imagesExhibit[1].Image1)
                                {
                                    if (IsImagePathValid(SecondImage))
                                    {
                                        string exhibitPhoto = Path.GetFileName(SecondImage);
                                        string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                        File.Copy(SecondImage, pathTo, true);

                                        var image = context.Images.FirstOrDefault(i => i.Image1 == imagesExhibit[1].Image1);
                                        if (image != null)
                                        {
                                            image.Image1 = exhibitPhoto;
                                            context.SaveChanges();
                                        }
                                    }
                                    else { MessageBox.Show("Неверный путь к файлу изображения."); }
                                }
                            }
                            else
                            {
                                var imageToDelete = imagesExhibit.ElementAtOrDefault(1);
                                if (imageToDelete != null)
                                {
                                    context.Images.Remove(imageToDelete);
                                    context.SaveChanges();
                                }
                            }
                            // 3.
                            if (ThirdImage != string.Empty && imagesExhibit.ElementAtOrDefault(2)?.Image1 != null)
                            {
                                if (Path.GetFileName(ThirdImage) != imagesExhibit[2].Image1)
                                {
                                    if (IsImagePathValid(ThirdImage))
                                    {
                                        string exhibitPhoto = Path.GetFileName(ThirdImage);
                                        string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                        File.Copy(ThirdImage, pathTo, true);

                                        var image = context.Images.FirstOrDefault(i => i.Image1 == imagesExhibit[2].Image1);
                                        if (image != null)
                                        {
                                            image.Image1 = exhibitPhoto;
                                            context.SaveChanges();
                                        }
                                    }
                                    else { MessageBox.Show("Неверный путь к файлу изображения."); }
                                }
                            }
                            else
                            {
                                var imageToDelete = imagesExhibit.ElementAtOrDefault(2);
                                if (imageToDelete != null)
                                {
                                    context.Images.Remove(imageToDelete);
                                    context.SaveChanges();
                                }
                            }
                            // 4.
                            if (FourthImage != string.Empty && imagesExhibit.ElementAtOrDefault(3)?.Image1 != null)
                            {
                                if (Path.GetFileName(FourthImage) != imagesExhibit[3].Image1)
                                {
                                    if (IsImagePathValid(FourthImage))
                                    {
                                        string exhibitPhoto = Path.GetFileName(FourthImage);
                                        string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                        File.Copy(FourthImage, pathTo, true);

                                        var image = context.Images.FirstOrDefault(i => i.Image1 == imagesExhibit[3].Image1);
                                        if (image != null)
                                        {
                                            image.Image1 = exhibitPhoto;
                                            context.SaveChanges();
                                        }
                                    }
                                    else { MessageBox.Show("Неверный путь к файлу изображения."); }
                                }
                            }
                            else
                            {
                                var imageToDelete = imagesExhibit.ElementAtOrDefault(3);
                                if (imageToDelete != null)
                                {
                                    context.Images.Remove(imageToDelete);
                                    context.SaveChanges();
                                }
                            }
                            // 5.
                            if (FifthImage != string.Empty && imagesExhibit.ElementAtOrDefault(4)?.Image1 != null)
                            {
                                if (Path.GetFileName(FifthImage) != imagesExhibit[4].Image1)
                                {
                                    if (IsImagePathValid(FifthImage))
                                    {
                                        string exhibitPhoto = Path.GetFileName(FifthImage);
                                        string pathTo = @"C:\Users\Я\source\repos\Art_space\Art_space\Resources\" + exhibitPhoto;
                                        File.Copy(FifthImage, pathTo, true);

                                        var image = context.Images.FirstOrDefault(i => i.Image1 == imagesExhibit[4].Image1);
                                        if (image != null)
                                        {
                                            image.Image1 = exhibitPhoto;
                                            context.SaveChanges();
                                        }
                                    }
                                    else { MessageBox.Show("Неверный путь к файлу изображения."); }
                                }
                            }
                            else
                            {
                                var imageToDelete = imagesExhibit.ElementAtOrDefault(4);
                                if (imageToDelete != null)
                                {
                                    context.Images.Remove(imageToDelete);
                                    context.SaveChanges();
                                }
                            }

                            // Автор(ы).
                            exhibitForEdit.IdAuthors.Clear();
                            context.SaveChanges();
                            foreach (var authorName in SelectedAuthors)
                            {
                                var author = context.Authors.FirstOrDefault(a => (a.NameAuthor + " " + a.SurnameAuthor) == authorName);
                                if (author != null)
                                {
                                    exhibitForEdit.IdAuthors.Add(author);
                                    context.SaveChanges();
                                }
                            }

                            // Техники исполнения.
                            exhibitForEdit.IdETs.Clear();
                            context.SaveChanges();
                            foreach (var techniqueName in SelectedTechniquesOfExecution)
                            {
                                var technique = context.TechniqueOfExecutions.FirstOrDefault(t => t.NameET == techniqueName);
                                if (technique != null)
                                {
                                    exhibitForEdit.IdETs.Add(technique);
                                    context.SaveChanges();
                                }
                            }

                            MessageBox.Show("Информация об экспонате изменена.");
                            AdminWindow.adminWindow.frameForEveryone.NavigationService.Navigate(new AllExhibits(), Visibility.Visible);
                        }
                        else { MessageBox.Show("Неверный формат данных"); }
                    }
                }
            }
        }
        // Удаление экспоната.
        private RelayCommand _deleteExhibitWnd;
        public RelayCommand DeleteExhibitWnd
        {
            get
            {
                return _deleteExhibitWnd ?? new RelayCommand(obj =>
                {
                    DeleteExhibitWndMethod();
                });
            }
        }
        public void DeleteExhibitWndMethod()
        {
            using (var context = new ArtSpaceContext())
            {
                var exhibitForDelete = context.Exhibits
                    .Include(e => e.IdAuthors)
                    .Include(e => e.IdETs)
                    .Include(e => e.Images)
                    .Include(e => e.Evaluations)
                    .Include(e => e.FavoriteExhibits)
                    .Include(e => e.Reviews)
                    .FirstOrDefault(e => e.IdExhibit == SelectedExhibit.IdExhibit);

                if (exhibitForDelete != null)
                {
                    // Очищаем связанные записи в таблицах
                    exhibitForDelete.IdAuthors.Clear();
                    exhibitForDelete.IdETs.Clear();
                    context.Images.RemoveRange(exhibitForDelete.Images);
                    exhibitForDelete.Evaluations.Clear();
                    exhibitForDelete.FavoriteExhibits.Clear();
                    exhibitForDelete.Reviews.Clear();
                    context.Exhibits.Remove(exhibitForDelete);
                    context.SaveChanges();

                    MessageBox.Show("Экспонат удален.");
                    AdminWindow.adminWindow.frameForEveryone.NavigationService.Navigate(new AllExhibits(), Visibility.Visible);
                }
            }
        }

        //// Комментарии.
        private RelayCommand _viewReviewsWnd;
        public RelayCommand ViewReviewsWnd
        {
            get
            {
                return _viewReviewsWnd ?? new RelayCommand(obj =>
                {
                    ViewReviewsWndMethod();
                });
            }
        }
        public void ViewReviewsWndMethod()
        {
            AdminWindow.adminWindow.frameForEveryone.Visibility = Visibility.Visible;
            AdminWindow.adminWindow.frameForEveryone.NavigationService.Navigate(new AllReviews());
        }

        private List<Review> _reviews;
        public List<Review> Reviews
        {
            get { return _reviews; }
            set
            {
                _reviews = value;
                NotifyPropertyChanged(nameof(Reviews));
            }
        }

        private void LoadReviews()
        {
            _reviews = UserService.GetReviews();
        }

        private Review _selectedReview;
        public Review SelectedReview
        {
            get { return _selectedReview; }
            set
            {
                _selectedReview = value;
                NotifyPropertyChanged(nameof(SelectedReview));
            }
        }

        // Удаление жалобы.
        private RelayCommand _returnReviewWnd;
        public RelayCommand ReturnReviewWnd
        {
            get
            {
                return _returnReviewWnd ?? new RelayCommand(obj =>
                {
                    ReturnReviewWndMethod();
                });
            }
        }
        public void ReturnReviewWndMethod()
        {
            if (SelectedReview == null)
                return;
            using (var context = new ArtSpaceContext())
            {
                var review = context.Reviews.FirstOrDefault(r => r.IdReview == SelectedReview.IdReview);
                if (review != null)
                {
                    review.Complaint = 0;
                    context.SaveChanges();

                    LoadReviews();
                    NotifyPropertyChanged(nameof(Reviews));

                    MessageBox.Show("Жалоба с отзыва убрана.");
                }
            }
        }

        // Удаление отзыва.
        private RelayCommand _deleteReviewWnd;
        public RelayCommand DeleteReviewWnd
        {
            get
            {
                return _deleteReviewWnd ?? new RelayCommand(obj =>
                {
                    DeleteReviewWndMethod();
                });
            }
        }
        public void DeleteReviewWndMethod()
        {
            if (SelectedReview == null)
                return;
            using (var context = new ArtSpaceContext())
            {
                var review = context.Reviews.FirstOrDefault(r => r.IdReview == SelectedReview.IdReview);
                if (review != null)
                {
                    context.Reviews.Remove(review);
                    context.SaveChanges();

                    Reviews.Remove(review);
                    LoadReviews();
                    NotifyPropertyChanged(nameof(Reviews));

                    MessageBox.Show("Отзыв удален.");
                }
            }
        }

        //// Выход.
        private RelayCommand _logoutWnd;
        public RelayCommand LogoutWnd
        {
            get
            {
                return _logoutWnd ?? new RelayCommand(obj =>
                {
                    LogoutWndMethod();
                });
            }
        }
        public void LogoutWndMethod()
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            AdminWindow.adminWindow.Close();
        }
    }
}
