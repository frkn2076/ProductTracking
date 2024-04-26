using ProductTracking.API.Data.Entities;
using ProductTracking.API.Models;

namespace ProductTracking.API.Services.Contracts;

public interface IElasticSearchService
{
    Task InsertProductAsync(Product product, CancellationToken cancellationToken = default);

    Task UpdateProductAsync(Product product, CancellationToken cancellationToken = default);

    Task DeleteProductAsync(int id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Product>> SearchProductsAsync(QueryProductRequest filter, CancellationToken cancellationToken = default);
}
