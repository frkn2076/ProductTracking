using ProductTracking.API.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProductTracking.API.Models;

public class QueryProductRequest
{
    public string Name { get; set; }

    [EnumDataType(typeof(Color))]
    public Color? Color { get; set; }

    [Range(10, 100)]
    public int? Size { get; set; }

    [MaxLength(100)]
    public string Barcode { get; set; }

    [MaxLength(100)]
    public string Brand { get; set; }
}
