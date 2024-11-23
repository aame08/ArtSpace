using Art_space.Models;
using Art_space.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Art_space.Services
{
    public class UserService
    {
        // Получение всех пользователей.
        public static List<User> GetUsers()
        {
            using (var context = new ArtSpaceContext())
            {
                var users = context.Users.ToList();

                return users;
            }
        }

        // Получение пользователя по логину и паролю.
        public static User GetUserByLoginAndPassword(string login, string password)
        {
            using (var context = new ArtSpaceContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login && u.PasswordUser == password);
                if (user != null)
                    return user;
                else
                    return null;
            }
        }

        // Получение роли пользователя по идентификатору.
        public static string GetRoleNameById(int idUser)
        {
            using (var context = new ArtSpaceContext())
            {
                var user = context.Users.FirstOrDefault(u => u.IdUser == idUser);
                return user.NameRole;
            }
        }

        // Получение избранных экспонатов по идентификатору пользователя.
        public static List<FavoriteExhibit> GetFavoritesById(int idUser)
        {
            using (var context = new ArtSpaceContext())
            {
                var favorites = context.FavoriteExhibits
                    .Where(f => f.IdUser == idUser)
                    .Include(f => f.IdExhibitNavigation)
                        .ThenInclude(e => e.Images)
                    .ToList();

                return favorites;
            }
        }

        // Получение отзывов по идентификатору пользователя.
        public static List<Review> GetReviewsById(int idUser)
        {
            using (var context = new ArtSpaceContext())
            {
                var reviews = context.Reviews
                    .Where(r => r.IdUser == idUser)
                    .Include(r => r.IdExhibitNavigation)
                        .ThenInclude(e => e.Images)
                    .ToList();

                return reviews;
            }
        }

        // Получение оценок по идентификатору пользователя.
        public static List<Evaluation> GetEvaluationById(int idUser)
        {
            using (var context = new ArtSpaceContext())
            {
                var evaluations = context.Evaluations
                    .Where(e => e.IdUser == idUser)
                    .Include(r => r.IdExhibitNavigation)
                        .ThenInclude(e => e.Images)
                    .ToList();

                return evaluations;
            }
        }

        // Получение отзывов, на которые есть жалобы.
        public static List<Review> GetReviews()
        {
            using (var context = new ArtSpaceContext())
            {
                var reviews = context.Reviews.Where(r => r.Complaint == 1)
                    .Include(r => r.IdUserNavigation)
                    .Include(r => r.IdExhibitNavigation)
                    .ToList();

                return reviews;
            }
        }
    }
}
