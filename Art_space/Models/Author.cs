namespace Art_space.Models;

public partial class Author
{
    public int IdAuthor { get; set; }

    public string SurnameAuthor { get; set; } = null!;

    public string NameAuthor { get; set; } = null!;

    public DateOnly DateBirth { get; set; }

    public DateOnly? DateDeath { get; set; }

    public virtual ICollection<Exhibit> IdExhibits { get; set; } = new List<Exhibit>();
}
