using System.ComponentModel.DataAnnotations;

namespace ProductTracking.API.Utils;

public record ProductQueueSettings
{
    [Required]
    public string HostName { get; init; }
}
