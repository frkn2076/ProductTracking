using ProductTracking.API.Utils;

namespace ProductTracking.API.Services.Contracts;

public interface IQueuePublisher
{
    Task PublishMessageAsync(ProductPayload payload);
}
