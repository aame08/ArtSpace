using Art_space.Models;
using Art_space.Models.Data;
using Art_space.Views;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Art_space.ViewModels
{
    public class BrowseExhibitInfo : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BrowseExhibitInfo(Exhibit exhibit)
        {
            LoadExhibit(exhibit);
        }

        private Exhibit _exhibit;
        public Exhibit Exhibit
        {
            get => _exhibit;
            set
            {
                _exhibit = value;
                NotifyPropertyChanged(nameof(Exhibit));
                NotifyPropertyChanged(nameof(AverageRating));
            }
        }
        public ObservableCollection<Author> Authors { get; set; }
        public string EpochName { get; set; }
        public string GenreName { get; set; }
        public ObservableCollection<TechniqueOfExecution> TechniqueOfExecutions { get; set; }
        public StorageLocation StorageLocation { get; set; }
        private int _currentImageIndex = 0;
        private List<Art_space.Models.Image> _imagesList;
        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                NotifyPropertyChanged(nameof(ImageSource));
            }
        }
        public ObservableCollection<Review> Reviews { get; set; }
        // Вычисление рейтинга экспоната.
        private double _totalRating;
        public double TotalRating
        {
            get => _totalRating;
            set
            {
                _totalRating = value;
                NotifyPropertyChanged(nameof(TotalRating));
                NotifyPropertyChanged(nameof(AverageRating));
            }
        }

        private int _ratingCount;
        public int RatingCount
        {
            get => _ratingCount;
            set
            {
                _ratingCount = value;
                NotifyPropertyChanged(nameof(RatingCount));
                NotifyPropertyChanged(nameof(AverageRating));
            }
        }

        public double AverageRating
        {
            get
            {
                if (RatingCount == 0)
                {
                    return 0;
                }
                else
                {
                    return TotalRating / RatingCount;
                }
            }
        }

        public void LoadExhibit(Exhibit exhibit)
        {
            using (var context = new ArtSpaceContext())
            {
                Exhibit = context.Exhibits
                    .Include(e => e.Evaluations)
                    .Include(e => e.Images)
                    .Include(e => e.Reviews).ThenInclude(r => r.IdUserNavigation)
                    .Include(e => e.IdEraNavigation)
                    .Include(e => e.IdStorageLocationNavigation)
                    .Include(e => e.IdAuthors)
                    .Include(e => e.IdETs)
                    .Include(e => e.IdGenreNavigation)
                    .FirstOrDefault(e => e.IdExhibit == exhibit.IdExhibit);

                Authors = new ObservableCollection<Author>(Exhibit.IdAuthors);
                EpochName = Exhibit.IdEraNavigation.NameEra;
                GenreName = Exhibit.IdGenreNavigation.NameGenre;
                TechniqueOfExecutions = new ObservableCollection<TechniqueOfExecution>(Exhibit.IdETs);
                StorageLocation = Exhibit.IdStorageLocationNavigation;
                Reviews = new ObservableCollection<Review>(Exhibit.Reviews.Where(r => r.Complaint == 0));

                var evaluations = Exhibit.Evaluations.ToList();
                TotalRating = evaluations.Sum(e => e.Score);
                RatingCount = evaluations.Count;

                _imagesList = Exhibit.Images.ToList();

                DisplayCurrentImage();
                Exhibit.NumberViews++;
                context.SaveChanges();
            }
        }

        // Переключение изображений.
        public void DisplayCurrentImage()
        {
            if (_imagesList != null && _imagesList.Count > 0)
            {
                ImageSource = _imagesList[_currentImageIndex].DisplayedImage;
            }
        }
        private RelayCommand _prevImageWnd;
        public RelayCommand PrevImageWnd
        {
            get
            {
                return _prevImageWnd ?? new RelayCommand(obj =>
                {
                    PrevImageWndMethod();
                });
            }
        }
        public void PrevImageWndMethod()
        {
            if (_imagesList != null && _imagesList.Count > 0)
            {
                _currentImageIndex = (_currentImageIndex - 1 + _imagesList.Count) % _imagesList.Count;
                DisplayCurrentImage();
            }
        }
        private RelayCommand _nextImageWnd;
        public RelayCommand NextImageWnd
        {
            get
            {
                return _nextImageWnd ?? new RelayCommand(obj =>
                {
                    NextImageWndMethod();
                });
            }
        }
        public void NextImageWndMethod()
        {
            if (_imagesList != null && _imagesList.Count > 0)
            {
                _currentImageIndex = (_currentImageIndex + 1) % _imagesList.Count;
                DisplayCurrentImage();
            }
        }

        // Оставление отзыва или(и) оценки.
        public List<string> Evaluations { get; set; } = ["Без оценки", "1 - Ужасно", "2 - Плохо", "3 - Средне", "4 - Хорошо", "5 - Отлично"];
        private string _selectedEvaluation;
        public string SelectedEvaluation
        {
            get => _selectedEvaluation;
            set
            {
                _selectedEvaluation = value;
                NotifyPropertyChanged(nameof(SelectedEvaluation));
            }
        }
        private string _textReview;
        public string TextReview
        {
            get => _textReview;
            set
            {
                _textReview = value;
                NotifyPropertyChanged(nameof(TextReview));
            }
        }
        private RelayCommand _sendEvaluationReviewWnd;
        public RelayCommand SendEvaluationReviewWnd
        {
            get
            {
                return _sendEvaluationReviewWnd ?? new RelayCommand(obj =>
                {
                    SendEvaluationReviewWndMethod();
                });
            }
        }
        private void SendEvaluationReviewWndMethod()
        {
            if (AccountUser.accountUser != null)
            {
                int userID = int.Parse(AccountUser.accountUser.tId.Text);

                using (var context = new ArtSpaceContext())
                {
                    bool hasEvaluation = context.Evaluations.Any(e => e.IdUser == userID && e.IdExhibit == Exhibit.IdExhibit);

                    if (hasEvaluation)
                    {
                        MessageBox.Show("Вы уже оставляли оценку для этого экспоната. \nЕсли хотите, можете поменять ее в личном кабинете.");
                        return;
                    }
                }

                // Если только оценка.
                if (!string.IsNullOrWhiteSpace(SelectedEvaluation) && string.IsNullOrWhiteSpace(TextReview) && SelectedEvaluation != "Без оценки")
                {
                    int evaluationValue = int.Parse(SelectedEvaluation.Split(' ')[0]);
                    using (var context = new ArtSpaceContext())
                    {
                        var newEvaluation = new Evaluation
                        {
                            IdExhibit = Exhibit.IdExhibit,
                            IdUser = userID,
                            Score = evaluationValue
                        };
                        context.Evaluations.Add(newEvaluation);
                        context.SaveChanges();

                        TotalRating += evaluationValue;
                        RatingCount++;
                    }
                    SelectedEvaluation = null;
                }
                // Если только отзыв.
                else if (string.IsNullOrWhiteSpace(SelectedEvaluation) && !string.IsNullOrWhiteSpace(TextReview))
                {
                    using (var context = new ArtSpaceContext())
                    {
                        var newReview = new Review
                        {
                            IdReview = context.Reviews.Any() ? context.Reviews.Max(r => r.IdReview) + 1 : 1,
                            IdExhibit = Exhibit.IdExhibit,
                            IdUser = userID,
                            TextReview = TextReview,
                            DateReview = DateOnly.FromDateTime(DateTime.Now),
                            Complaint = 0
                        };
                        context.Reviews.Add(newReview);
                        context.SaveChanges();
                        Reviews.Add(newReview);

                        context.Entry(newReview).Reference(r => r.IdUserNavigation).Load();
                    }
                    TextReview = null;
                }
                // Если оценки и отзыв.
                else if (!string.IsNullOrWhiteSpace(SelectedEvaluation) && !string.IsNullOrWhiteSpace(TextReview) && SelectedEvaluation != "Без оценки")
                {
                    int evaluationValue = int.Parse(SelectedEvaluation.Split(' ')[0]);
                    using (var context = new ArtSpaceContext())
                    {
                        var newEvaluation = new Evaluation
                        {
                            IdExhibit = Exhibit.IdExhibit,
                            IdUser = userID,
                            Score = evaluationValue
                        };
                        var newReview = new Review
                        {
                            IdReview = context.Reviews.Any() ? context.Reviews.Max(r => r.IdReview) + 1 : 1,
                            IdExhibit = Exhibit.IdExhibit,
                            IdUser = userID,
                            TextReview = TextReview,
                            DateReview = DateOnly.FromDateTime(DateTime.Now),
                            Complaint = 0
                        };

                        context.Evaluations.Add(newEvaluation);
                        context.Reviews.Add(newReview);
                        context.SaveChanges();

                        Reviews.Add(newReview);
                        context.Entry(newReview).Reference(r => r.IdUserNavigation).Load();
                        TotalRating += evaluationValue;
                        RatingCount++;
                    }
                    SelectedEvaluation = null;
                    TextReview = null;
                }
                else { MessageBox.Show("Ничего не указано."); }
            }
            else { MessageBox.Show("Для оставления отзыва или оценки требуется авторизация."); }
        }

        // Жалоба на комментарий.
        private RelayCommand _complainWnd;
        public RelayCommand ComplainWnd
        {
            get
            {
                return _complainWnd ?? new RelayCommand(obj =>
                {
                    if (obj is Review review)
                    {
                        ComplainWndMethod(review);
                    }
                });
            }
        }
        public void ComplainWndMethod(Review selectedReview)
        {
            if (selectedReview == null)
                return;

            using (var context = new ArtSpaceContext())
            {
                var review = context.Reviews.Find(selectedReview.IdReview);
                if (review != null)
                {
                    review.Complaint = 1;
                    context.SaveChanges();

                    MessageBox.Show("Жалоба на комментарий отправлена.");
                }
            }
        }

        // Добавление в Избранное.
        private RelayCommand _addToFavoriteWnd;
        public RelayCommand AddToFavoriteWnd
        {
            get
            {
                return _addToFavoriteWnd ?? new RelayCommand(obj =>
                {
                    AddToFavoriteWndMethod();
                });
            }
        }
        public void AddToFavoriteWndMethod()
        {
            if (AccountUser.accountUser != null)
            {
                int userID = int.Parse(AccountUser.accountUser.tId.Text);

                using (var context = new ArtSpaceContext())
                {
                    if (!context.FavoriteExhibits.Any(fe => fe.IdExhibit == Exhibit.IdExhibit && fe.IdUser == userID))
                    {
                        var addToFavorite = new FavoriteExhibit
                        {
                            IdExhibit = Exhibit.IdExhibit,
                            IdUser = userID,
                            DateAddition = DateOnly.FromDateTime(DateTime.Now)
                        };

                        context.FavoriteExhibits.Add(addToFavorite);
                        context.SaveChanges();
                        MessageBox.Show("Экспонат добавлен в Избранное.");
                    }
                    else { MessageBox.Show("Данный экспонат уже добавлен в Избранное."); }
                }
            }
            else { MessageBox.Show("Для добавления экспоната в Избранное требуется авторизация."); }
        }
    }
}
