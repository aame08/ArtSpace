namespace Art_space.Models;

public partial class FavoriteExhibit
{
    public int IdExhibit { get; set; }

    public int IdUser { get; set; }

    public DateOnly DateAddition { get; set; }

    public virtual Exhibit IdExhibitNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
