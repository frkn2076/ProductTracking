using ProductTracking.API.Utils.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductTracking.API.Data.Entities;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required, DeniedValues(Color.None)]
    public Color Color { get; set; }

    [Range(10,100)]
    public int Size { get; set; }

    [Required, MaxLength(100)]
    public string Barcode { get; set; }

    [Required, MaxLength(100)]
    public string Brand { get; set; }
}
