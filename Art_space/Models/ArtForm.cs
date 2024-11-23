namespace Art_space.Models;

public partial class ArtForm
{
    public int IdArtForm { get; set; }

    public string NameAF { get; set; } = null!;

    public virtual ICollection<Exhibit> Exhibits { get; set; } = new List<Exhibit>();
}
