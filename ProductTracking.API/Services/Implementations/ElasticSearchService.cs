using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using ProductTracking.API.Data.Entities;
using ProductTracking.API.Models;
using ProductTracking.API.Services.Contracts;

namespace ProductTracking.API.Services.Implementations;

public class ElasticSearchService : IElasticSearchService
{
    private readonly ILogger<ElasticSearchService> _logger;
    private readonly ElasticsearchClient _client;

    public ElasticSearchService(ILogger<ElasticSearchService> logger)
    {
        _logger = logger;
        var settings = new ElasticsearchClientSettings()
            .DefaultIndex(Constants.ElasticSearch.ProductIndexName);
        _client = new ElasticsearchClient(settings);
    }

    public async Task InsertProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        var response = await _client.IndexAsync(product, cancellationToken);

        if (!response.IsValidResponse)
        {
            _logger.LogError("Failed to index product: {product}", product);
        }
    }

    public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        var response = await _client.UpdateByQueryAsync<Product>(d => d
            .Query(q => q
                .Match(mt => mt
                    .Field(f => f.Id)
                    .Query(product.Id)
                )
            )
            .Script(
                new Script(new InlineScript()
                    {
                        Source = $"ctx._source.{nameof(product.Name).ToLower()} = params.{nameof(product.Name)};" +
                            $"ctx._source.{nameof(product.Color).ToLower()} = params.{nameof(product.Color)};" +
                            $"ctx._source.{nameof(product.Size).ToLower()} = params.{nameof(product.Size)};" +
                            $"ctx._source.{nameof(product.Barcode).ToLower()} = params.{nameof(product.Barcode)};" +
                            $"ctx._source.{nameof(product.Brand).ToLower()} = params.{nameof(product.Brand)};",
                        Params = new Dictionary<string, object>()
                        {
                            { nameof(product.Name), product.Name },
                            { nameof(product.Color), product.Color },
                            { nameof(product.Size), product.Size },
                            { nameof(product.Barcode), product.Barcode },
                            { nameof(product.Brand), product.Brand },
                        }
                    }
                )
            ),
            cancellationToken
        );

        if (!response.IsValidResponse)
        {
            _logger.LogError("Failed to update product: {product}", product);
        }
    }

    public async Task DeleteProductAsync(int id, CancellationToken cancellationToken = default)
    {
        var response = await _client.DeleteByQueryAsync<Product>(d => d
            .Query(q => q
                .Bool(b => b
                    .Must(sh => sh
                        .Match(mt => mt
                            .Field(f => f.Id)
                            .Query(id)
                        )
                    )
                )
            ), cancellationToken
        );

        if (!response.IsValidResponse)
        {
            _logger.LogError("Failed to delete productId: {productId}", id);
        }
    }

    public async Task<IEnumerable<Product>> SearchProductsAsync(QueryProductRequest filter, CancellationToken cancellationToken = default)
    {
        var response = await _client.SearchAsync<Product>(s => s
            .Size(1000)
            .Query(q => q
                .Bool(b => b
                    .Must(sh =>
                        PrepareQueryDescriptor(filter, sh)
                    )
                )
            ), cancellationToken
        );

        if (!response.IsValidResponse)
        {
            _logger.LogError("Failed to fetch products by filter: {filter}", filter);
            return Enumerable.Empty<Product>();
        }

        return response.Documents;
    }

    #region Helper

    private QueryDescriptor<Product> PrepareQueryDescriptor(QueryProductRequest filter, QueryDescriptor<Product> queryDescriptor)
    {
        if (filter.Name != null)
        {
            queryDescriptor
                .Wildcard(mt => mt
                    .Field(f => f.Name)
                    .Value(filter.Name)
                );
        }

        if (filter.Color != null)
        {
            queryDescriptor
                .Match(mt => mt
                    .Field(f => f.Color)
                    .Query(filter.Color.ToString())
                );
        }

        if (filter.Size != null)
        {
            queryDescriptor
                .Match(mt => mt
                    .Field(f => f.Size)
                    .Query(filter.Size)
                );
        }

        if (filter.Barcode != null)
        {
            queryDescriptor
                .Match(mt => mt
                    .Field(f => f.Barcode)
                    .Query(filter.Barcode)
                );
        }

        if (filter.Brand != null)
        {
            queryDescriptor
                .Match(mt => mt
                    .Field(f => f.Brand)
                    .Query(filter.Brand)
                );
        }

        return queryDescriptor;
    }

    #endregion

}

