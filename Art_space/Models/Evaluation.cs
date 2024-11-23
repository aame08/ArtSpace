namespace Art_space.Models;

public partial class Evaluation
{
    public int IdExhibit { get; set; }

    public int IdUser { get; set; }

    public int Score { get; set; }

    public virtual Exhibit IdExhibitNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
