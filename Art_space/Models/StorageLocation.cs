namespace Art_space.Models;

public partial class StorageLocation
{
    public int IdStorageLocation { get; set; }

    public string NameSL { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Exhibit> Exhibits { get; set; } = new List<Exhibit>();
}
