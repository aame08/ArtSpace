using Art_space.Models;
using Art_space.Models.Data;
using Art_space.Services;
using Art_space.Views;
using DevExpress.Mvvm;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace Art_space.ViewModels
{
    public class BrowseUsers : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<User> _users = UserService.GetUsers();
        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                NotifyPropertyChanged(nameof(Users));
            }
        }

        public static string nameUser;

        private string _surnameUser;
        public string SurnameUser
        {
            get => _surnameUser;
            set
            {
                _surnameUser = value;
                NotifyPropertyChanged(nameof(SurnameUser));
            }
        }
        private string _nameUser;
        public string NameUser
        {
            get => _nameUser;
            set
            {
                _nameUser = value;
                NotifyPropertyChanged(nameof(NameUser));
            }
        }
        private string _loginUser;
        public string LoginUser
        {
            get => _loginUser;
            set
            {
                _loginUser = value;
                NotifyPropertyChanged(nameof(LoginUser));
            }
        }
        private string _passwordUser;
        public string PasswordUser
        {
            get => _passwordUser;
            set
            {
                _passwordUser = value;
                NotifyPropertyChanged(nameof(PasswordUser));
            }
        }

        // Авторизация.
        private RelayCommand _authorizationWnd;
        public RelayCommand AuthorizationWnd
        {
            get
            {
                return _authorizationWnd ?? new RelayCommand(obj =>
                {
                    AuthorizationWndMethod();
                });
            }
        }
        public void AuthorizationWndMethod()
        {
            var user = UserService.GetUserByLoginAndPassword(LoginUser, PasswordUser);
            if (user != null)
            {
                nameUser = user.NameUser + " " + user.SurnameUser;
                var role = UserService.GetRoleNameById(user.IdUser);
                switch (role)
                {
                    case "Администратор":
                        Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
                        if (currentWindow != null)
                        {
                            currentWindow.Hide();
                            AdminWindow adminWindow = new()
                            {
                                Owner = System.Windows.Application.Current.MainWindow,
                                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                            };
                            adminWindow.ShowDialog();
                            currentWindow.Close();
                        }
                        break;
                    case "Пользователь":
                        MainWindow.mainWindow.frameToAuthorizationOrRegistration.Visibility = Visibility.Hidden;
                        MainWindow.mainWindow.frameForAccount.NavigationService.Navigate(new AccountUser(), Visibility.Visible);
                        AccountUser.accountUser.tId.Text = user.IdUser.ToString();
                        AccountUser.accountUser.tName.Text = nameUser;
                        break;
                }
            }
            else { MessageBox.Show("Логин или пароль введен неверно."); }
        }

        //// Регистрация.
        private RelayCommand _registrationWnd;
        public RelayCommand RegistrationWnd
        {
            get
            {
                return _registrationWnd ?? new RelayCommand(obj =>
                {
                    RegistrationWndMethod();
                });
            }
        }
        // Проверка данных на валидность.
        private bool IsValidSurnameOrName(string str)
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
        private bool IsEmailValid(string email)
        {
            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);
        }
        private bool IsEmailExists(string email)
        {
            using (var context = new ArtSpaceContext())
            {
                return context.Users.Any(u => u.Login == email);
            }
        }
        public bool IsEmailValidAndUnique(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            if (email.Length > 30)
                return false;
            if (!IsEmailValid(email))
                return false;
            if (IsEmailExists(email))
                return false;

            return true;
        }
        public bool IsPasswordValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;
            if (password.Length > 30)
                return false;

            return true;
        }
        public void RegistrationWndMethod()
        {
            if (IsValidSurnameOrName(SurnameUser) && IsValidSurnameOrName(NameUser) && IsEmailValidAndUnique(LoginUser) && IsPasswordValid(PasswordUser))
            {
                using (var context = new ArtSpaceContext())
                {
                    var newUser = new User
                    {
                        IdUser = context.Users.Any() ? context.Users.Max(u => u.IdUser) + 1 : 1,
                        SurnameUser = SurnameUser,
                        NameUser = NameUser,
                        Login = LoginUser,
                        PasswordUser = PasswordUser,
                        NameRole = "Пользователь"
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();

                    MessageBox.Show("Вы зарегистрированы.");

                    Registration.registration.Visibility = Visibility.Hidden;
                }
            }
            else { MessageBox.Show("Неверный формат данных."); }
        }

        //// Возврат в галерею.
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
            MainWindow.mainWindow.frameForEveryone.Visibility = Visibility.Hidden;
        }

        //// Избранные экспонаты.
        private RelayCommand _viewFavoritesWnd;
        public RelayCommand ViewFavoritesWnd
        {
            get
            {
                return _viewFavoritesWnd ?? new RelayCommand(obj =>
                {
                    ViewFavoritesWndMethod();
                });
            }
        }
        public void ViewFavoritesWndMethod()
        {
            MainWindow.mainWindow.frameForEveryone.Visibility = Visibility.Visible;
            MainWindow.mainWindow.frameForEveryone.NavigationService.Navigate(new ManagingFavorites());
        }

        //// Оставленные отзывы.
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
            if (AccountUser.accountUser == null && nameUser == null)
                return;

            MainWindow.mainWindow.frameForEveryone.Visibility = Visibility.Visible;
            MainWindow.mainWindow.frameForEveryone.NavigationService.Navigate(new ManagingReviews());
        }

        //// Оставленные оценки.
        private RelayCommand _viewEvaluationsWnd;
        public RelayCommand ViewEvaluationsWnd
        {
            get
            {
                return _viewEvaluationsWnd ?? new RelayCommand(obj =>
                {
                    ViewEvaluationsWndMethod();
                });
            }
        }
        public void ViewEvaluationsWndMethod()
        {
            if (AccountUser.accountUser == null && nameUser == null)
                return;

            MainWindow.mainWindow.frameForEveryone.Visibility = Visibility.Visible;
            MainWindow.mainWindow.frameForEveryone.NavigationService.Navigate(new ManagingEvaluations());
        }

        //// Выход из аккаунта.
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
            nameUser = null;
            AccountUser.accountUser = null;

            MainWindow.mainWindow.frameForAccount.Visibility = Visibility.Hidden;
            MainWindow.mainWindow.frameForEveryone.Visibility = Visibility.Hidden;
        }
    }
}
