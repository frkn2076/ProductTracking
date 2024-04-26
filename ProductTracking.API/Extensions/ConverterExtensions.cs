using ProductTracking.API.Data.Entities;
using ProductTracking.API.Models;
using ProductTracking.API.Utils;
using ProductTracking.API.Utils.Enums;

namespace ProductTracking.API.Extensions;

public static class ConverterExtensions
{
    public static Product MapTo(this ProductCreationRequest value)
    {
        if (value is null)
        {
            return null;
        }

        return new Product()
        {
            Name = value.Name,
            Color = value.Color,
            Barcode = value.Barcode,
            Brand = value.Brand,
            Size = value.Size
        };
    }

    public static ProductPayload MapTo(this Product value, OperationType operationType)
    {
        if (value is null)
        {
            return null;
        }

        return new ProductPayload()
        {
            Id = value.Id,
            Name = value.Name,
            Color = value.Color,
            Barcode = value.Barcode,
            Brand = value.Brand,
            Size = value.Size,
            OperationType = operationType
        };
    }

    public static Product MapTo(this ProductPayload value)
    {
        if (value is null)
        {
            return null;
        }

        return new Product()
        {
            Id = value.Id,
            Name = value.Name,
            Color = value.Color,
            Barcode = value.Barcode,
            Brand = value.Brand,
            Size = value.Size
        };
    }
}
