using ProductTracking.API.Utils.Enums;

namespace ProductTracking.API.Utils;

public class ProductPayload
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Color Color { get; set; }

    public int Size { get; set; }

    public string Barcode { get; set; }

    public string Brand { get; set; }

    public OperationType OperationType { get; set; }
}
