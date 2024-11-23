using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.Imaging;

namespace Art_space.Models;

public partial class Image
{
    public int IdImage { get; set; }

    public int IdExhibit { get; set; }

    public string Image1 { get; set; } = null!;

    [NotMapped]
    public BitmapImage DisplayedImage
    {
        get
        {
            var uri = new Uri($@"C:\Users\Я\source\repos\Art_space\Art_space\Resources\{Image1}");
            return new BitmapImage(uri);
        }
    }

    public virtual Exhibit IdExhibitNavigation { get; set; } = null!;
}
