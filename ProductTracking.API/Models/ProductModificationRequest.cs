using ProductTracking.API.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProductTracking.API.Models;

public class ProductModificationRequest
{
    [Range(1,int.MaxValue)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required, DeniedValues(Color.None)]
    [EnumDataType(typeof(Color))]
    public Color Color { get; set; }

    [Range(10, 100)]
    public int Size { get; set; }

    [MaxLength(100)]
    public string Barcode { get; set; }

    [MaxLength(100)]
    public string Brand { get; set; }
}
