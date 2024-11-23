using Art_space.Models;
using Art_space.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Art_space.Services
{
    public class ExhibitsService
    {
        // Фильтрация по видам искусств.
        public static List<string> GetAllArtForm()
        {
            using (var context = new ArtSpaceContext())
            {
                var artForms = context.ArtForms.Select(a => a.NameAF).ToList();
                artForms.Insert(0, "Все виды искусств");
                return artForms;
            }
        }

        // Получение всех экспонатов.
        public static List<Exhibit> GetAllExhibits()
        {
            using (var context = new ArtSpaceContext())
            {
                var exhibitQuery = context.Exhibits
                    .Include(e => e.Images)
                    .Include(e => e.IdArtFormNavigation)
                    .Include(e => e.IdEraNavigation)
                    .Include(e => e.IdGenreNavigation)
                    .Include(e => e.IdStorageLocationNavigation)
                    .Include(e => e.Evaluations)
                    .Include(e => e.FavoriteExhibits)
                    .Include(e => e.Reviews)
                    .Include(e => e.IdAuthors)
                    .Include(e => e.IdETs);
                var exhibitList = exhibitQuery.ToList();

                return exhibitList;
            }
        }

        // Получение трех просматриваемых экспонатов.
        public static List<Exhibit> GetTopViewedExhibits()
        {
            using (var context = new ArtSpaceContext())
            {
                var topExhibits = context.Exhibits
                    .Include(e => e.Images)
                    .Include(e => e.IdArtFormNavigation)
                    .Include(e => e.IdEraNavigation)
                    .Include(e => e.IdGenreNavigation)
                    .Include(e => e.IdStorageLocationNavigation)
                    .Include(e => e.Evaluations)
                    .Include(e => e.FavoriteExhibits)
                    .Include(e => e.Reviews)
                    .Include(e => e.IdAuthors)
                    .Include(e => e.IdETs)
                    .OrderByDescending(e => e.NumberViews)
                    .Take(3)
                    .ToList();

                return topExhibits;
            }
        }

        // Получение всех эпох.
        public static List<string> GetEpochs()
        {
            using (var context = new ArtSpaceContext())
            {
                var epochs = context.Epoches.Select(e => e.NameEra).ToList();

                return epochs;
            }
        }

        // Получение всех видов искусств.
        public static List<string> GetArtForms()
        {
            using (var context = new ArtSpaceContext())
            {
                var artForms = context.ArtForms.Select(a => a.NameAF).ToList();

                return artForms;
            }
        }

        // Получение всех жанров.
        public static List<string> GetGenres()
        {
            using (var context = new ArtSpaceContext())
            {
                var genres = context.Genres.Select(g => g.NameGenre).ToList();

                return genres;
            }
        }

        // Получение всех мест хранения.
        public static List<string> GetStorageLocations()
        {
            using (var context = new ArtSpaceContext())
            {
                var storageLocations = context.StorageLocations.Select(s => s.NameSL).ToList();

                return storageLocations;
            }
        }

        // Получение всех имен и фамилий авторов.
        public static List<string> GetAuthors()
        {
            using (var context = new ArtSpaceContext())
            {
                var authors = context.Authors.Select(a => a.NameAuthor + " " + a.SurnameAuthor).ToList();

                return authors;
            }
        }

        // Получение всех техник исполнения.
        public static List<string> GetTechniquesOfExecution()
        {
            using (var context = new ArtSpaceContext())
            {
                var techniques = context.TechniqueOfExecutions.Select(t => t.NameET).ToList();

                return techniques;
            }
        }

        // Получение авторов по идентификатору экспоната.
        public static List<string> GetAuthorsByIdExhibit(int idExhibit)
        {
            using (var context = new ArtSpaceContext())
            {
                var authors = context.Exhibits.Where(e => e.IdExhibit == idExhibit).SelectMany(e => e.IdAuthors).Select(a => a.NameAuthor + " " + a.SurnameAuthor).ToList();

                return authors;
            }
        }

        // Получение техник исполнения по идентификатору экспоната.
        public static List<string> GetTechniquesByIdExhibit(int idExhibit)
        {
            using (var context = new ArtSpaceContext())
            {
                var techniques = context.Exhibits.Where(e => e.IdExhibit == idExhibit).SelectMany(e => e.IdETs).Select(t => t.NameET).ToList();

                return techniques;
            }
        }
    }
}
