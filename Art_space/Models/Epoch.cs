namespace Art_space.Models;

public partial class Epoch
{
    public int IdEra { get; set; }

    public string NameEra { get; set; } = null!;

    public virtual ICollection<Exhibit> Exhibits { get; set; } = new List<Exhibit>();
}
