namespace Art_space.Models;

public partial class Exhibit
{
    public int IdExhibit { get; set; }

    public string NameExhibit { get; set; } = null!;

    public string DescriptionExhibit { get; set; } = null!;

    public int YearCreation { get; set; }

    public string CountryCreation { get; set; } = null!;

    public int IdEra { get; set; }

    public int IdArtForm { get; set; }

    public int IdGenre { get; set; }

    public int IdStorageLocation { get; set; }

    public int NumberViews { get; set; }

    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    public virtual ICollection<FavoriteExhibit> FavoriteExhibits { get; set; } = new List<FavoriteExhibit>();

    public virtual ArtForm IdArtFormNavigation { get; set; } = null!;

    public virtual Epoch IdEraNavigation { get; set; } = null!;

    public virtual Genre IdGenreNavigation { get; set; } = null!;

    public virtual StorageLocation IdStorageLocationNavigation { get; set; } = null!;

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Author> IdAuthors { get; set; } = new List<Author>();

    public virtual ICollection<TechniqueOfExecution> IdETs { get; set; } = new List<TechniqueOfExecution>();
}
