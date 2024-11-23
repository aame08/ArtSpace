using Art_space.Models;
using Art_space.Models.Data;
using Art_space.Services;
using Art_space.Views;
using DevExpress.Mvvm;
using System.ComponentModel;
using System.Windows;

namespace Art_space.ViewModels
{
    public class BrowseAccount : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BrowseAccount()
        {
            LoadFavorites();
            LoadReviews();
            LoadEvaluations();
        }

        public int idUser = int.Parse(AccountUser.accountUser.tId.Text);

        public List<string> Sorts { get; set; } = ["Сортировка", "От старых к новым", "От новых к старым"];

        //// Избранные экспонаты.
        private List<FavoriteExhibit> _favorites;
        private List<FavoriteExhibit> _originalFavorites;

        public List<FavoriteExhibit> Favorites
        {
            get { return _favorites; }
            set
            {
                _favorites = value;
                NotifyPropertyChanged(nameof(Favorites));
            }
        }

        private void LoadFavorites()
        {
            _originalFavorites = UserService.GetFavoritesById(idUser);
            _favorites = _originalFavorites;
        }

        // Фильтрация по дате.
        public string SelectedSortForFavorite
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: UpdateFavorites); }
        }
        private void UpdateFavorites()
        {
            switch (SelectedSortForFavorite)
            {
                case "От старых к новым":
                    Favorites = _originalFavorites.OrderBy(f => f.DateAddition).ToList();
                    break;
                case "От новых к старым":
                    Favorites = _originalFavorites.OrderByDescending(f => f.DateAddition).ToList();
                    break;
                default:
                    Favorites = _originalFavorites;
                    break;
            }
        }

        private FavoriteExhibit _selectedFavorite;
        public FavoriteExhibit SelectedFavorite
        {
            get { return _selectedFavorite; }
            set
            {
                _selectedFavorite = value;
                NotifyPropertyChanged(nameof(SelectedFavorite));
            }
        }

        // Удаление из Избранного.
        private RelayCommand _removeFavoriteWnd;
        public RelayCommand RemoveFavoriteWnd
        {
            get
            {
                return _removeFavoriteWnd ?? new RelayCommand(obj =>
                {
                    RemoveFavoriteWndMethod();
                });
            }
        }
        public void RemoveFavoriteWndMethod()
        {
            if (SelectedFavorite == null)
                return;
            using (var context = new ArtSpaceContext())
            {
                var favorite = context.FavoriteExhibits.FirstOrDefault(f => f.IdUser == idUser && f.IdExhibit == SelectedFavorite.IdExhibit);
                if (favorite != null)
                {
                    context.FavoriteExhibits.Remove(favorite);
                    context.SaveChanges();
                    MessageBox.Show("Экспонат удален из Избранных.");

                    Favorites.Remove(favorite);
                    LoadFavorites();
                    NotifyPropertyChanged(nameof(Favorites));
                }
            }
        }

        //// Отзывы.
        private List<Review> _reviews;
        private List<Review> _originalReviews;
        private void LoadReviews()
        {
            _originalReviews = UserService.GetReviewsById(idUser);
            _reviews = _originalReviews;
        }

        public List<Review> Reviews
        {
            get { return _reviews; }
            set
            {
                _reviews = value;
                NotifyPropertyChanged(nameof(Reviews));
            }
        }

        // Фильтрация по дате.
        public string SelectedSortForReviews
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: UpdateReviews); }
        }
        private void UpdateReviews()
        {
            switch (SelectedSortForReviews)
            {
                case "От старых к новым":
                    Reviews = _originalReviews.OrderBy(r => r.DateReview).ToList();
                    break;
                case "От новых к старым":
                    Reviews = _originalReviews.OrderByDescending(r => r.DateReview).ToList();
                    break;
                default:
                    Reviews = _originalReviews;
                    break;
            }
        }

        private Review _selectedReview;
        public Review SelectedReview
        {
            get { return _selectedReview; }
            set
            {
                _selectedReview = value;
                NotifyPropertyChanged(nameof(SelectedReview));
                NotifyPropertyChanged(nameof(TextReview));
            }
        }
        public string TextReview
        {
            get { return SelectedReview.TextReview; }
            set
            {
                if (SelectedReview != null && SelectedReview.TextReview != value)
                {
                    SelectedReview.TextReview = value;
                    NotifyPropertyChanged(nameof(TextReview));
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
                    MessageBox.Show("Отзыв удален.");

                    Reviews.Remove(review);
                    LoadReviews();
                    NotifyPropertyChanged(nameof(Reviews));
                }
            }
        }

        // Изменение отзыва.
        private RelayCommand _editReviewWnd;
        public RelayCommand EditReviewWnd
        {
            get
            {
                return _editReviewWnd ?? new RelayCommand(obj =>
                {
                    EditReviewWndMethod();
                });
            }
        }
        public void EditReviewWndMethod()
        {
            if (SelectedReview == null)
                return;
            using (var context = new ArtSpaceContext())
            {
                var review = context.Reviews.FirstOrDefault(r => r.IdReview == SelectedReview.IdReview);
                if (review != null)
                {
                    review.TextReview = SelectedReview.TextReview;
                    context.SaveChanges();

                    MessageBox.Show("Отзыв изменен.");
                }
            }
        }

        //// Оценки.
        private List<Evaluation> _evaluations;
        private List<Evaluation> _originalEvaluations;

        private void LoadEvaluations()
        {
            _originalEvaluations = UserService.GetEvaluationById(idUser);
            _evaluations = _originalEvaluations;
        }

        public List<Evaluation> Evaluations
        {
            get { return _evaluations; }
            set
            {
                _evaluations = value;
                NotifyPropertyChanged(nameof(Evaluations));
            }
        }

        public List<string> ScoreEvaluations { get; set; } = ["Без оценки", "1 - Ужасно", "2 - Плохо", "3 - Средне", "4 - Хорошо", "5 - Отлично"];

        private Evaluation _evaluationForEdit;
        public Evaluation EvaluationForEdit
        {
            get { return _evaluationForEdit; }
            set
            {
                _evaluationForEdit = value;
                NotifyPropertyChanged(nameof(EvaluationForEdit));
                NotifyPropertyChanged(nameof(Score));
            }
        }
        public int Score
        {
            get { return EvaluationForEdit.Score; }
            set
            {
                if (EvaluationForEdit != null && EvaluationForEdit.Score != value)
                {
                    EvaluationForEdit.Score = value;
                    NotifyPropertyChanged(nameof(Score));
                }
            }
        }

        // Изменение оценки.
        private RelayCommand _editEvalutionWnd;
        public RelayCommand EditEvalutionWnd
        {
            get
            {
                return _editEvalutionWnd ?? new RelayCommand(obj =>
                {
                    EditEvalutionWndMethod();
                });
            }
        }
        public void EditEvalutionWndMethod()
        {
            if (EvaluationForEdit == null)
                return;
            using (var context = new ArtSpaceContext())
            {
                var evaluation = context.Evaluations.FirstOrDefault(
                    e => e.IdExhibit == EvaluationForEdit.IdExhibit && e.IdUser == idUser);
                if (evaluation != null && Score == 0)
                {
                    context.Evaluations.Remove(evaluation);
                }
                else if (evaluation != null && Score != 0)
                {
                    evaluation.Score = Score;
                }
                context.SaveChanges();

                MessageBox.Show("Оценка изменена.");

                LoadEvaluations();
                NotifyPropertyChanged(nameof(Evaluations));
            }
        }
    }
}
