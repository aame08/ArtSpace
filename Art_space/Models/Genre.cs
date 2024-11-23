namespace Art_space.Models;

public partial class Genre
{
    public int IdGenre { get; set; }

    public string NameGenre { get; set; } = null!;

    public virtual ICollection<Exhibit> Exhibits { get; set; } = new List<Exhibit>();
}
