namespace Art_space.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string SurnameUser { get; set; } = null!;

    public string NameUser { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public string NameRole { get; set; } = null!;

    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    public virtual ICollection<FavoriteExhibit> FavoriteExhibits { get; set; } = new List<FavoriteExhibit>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
