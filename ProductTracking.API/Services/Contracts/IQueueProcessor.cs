using ProductTracking.API.Utils;

namespace ProductTracking.API.Services.Contracts;

public interface IQueueProcessor
{
    Task PerformOperationAsync(ProductPayload payload, CancellationToken cancellationToken);
}
