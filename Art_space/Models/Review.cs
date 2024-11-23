namespace Art_space.Models;

public partial class Review
{
    public int IdReview { get; set; }

    public int IdExhibit { get; set; }

    public int IdUser { get; set; }

    public string TextReview { get; set; } = null!;

    public DateOnly DateReview { get; set; }

    public sbyte Complaint { get; set; }

    public virtual Exhibit IdExhibitNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
