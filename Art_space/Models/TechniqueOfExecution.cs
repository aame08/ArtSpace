namespace Art_space.Models;

public partial class TechniqueOfExecution
{
    public int IdET { get; set; }

    public string NameET { get; set; } = null!;

    public virtual ICollection<Exhibit> IdExhibits { get; set; } = new List<Exhibit>();
}
