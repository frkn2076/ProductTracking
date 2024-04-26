using System.ComponentModel.DataAnnotations;

namespace ProductTracking.API.Utils;

public record ElasticSearchSettings
{
    [Url]
    public string Url { get; init; }
}
