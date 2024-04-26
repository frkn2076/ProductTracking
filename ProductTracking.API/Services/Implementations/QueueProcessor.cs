using ProductTracking.API.Extensions;
using ProductTracking.API.Services.Contracts;
using ProductTracking.API.Utils;
using ProductTracking.API.Utils.Enums;

namespace ProductTracking.API.Services.Implementations;

public class QueueProcessor(ILogger<ElasticSearchService> logger,
    IElasticSearchService elasticSearchService) : IQueueProcessor
{
    public async Task PerformOperationAsync(ProductPayload payload, CancellationToken cancellationToken)
    {
        var product = payload.MapTo();

        switch (payload.OperationType)
        {
            case OperationType.Insert:
                await elasticSearchService.InsertProductAsync(product, cancellationToken);
                break;
            case OperationType.Update:
                await elasticSearchService.UpdateProductAsync(product, cancellationToken);
                break;
            case OperationType.Delete:
                await elasticSearchService.DeleteProductAsync(product.Id, cancellationToken);
                break;
            default:
                logger.LogError("No valid operation type is specified!");
                break;
        }
    }
}
