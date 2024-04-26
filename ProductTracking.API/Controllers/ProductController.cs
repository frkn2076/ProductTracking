using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductTracking.API.Data;
using ProductTracking.API.Data.Entities;
using ProductTracking.API.Extensions;
using ProductTracking.API.Models;
using ProductTracking.API.Services.Contracts;
using ProductTracking.API.Utils.Enums;

namespace ProductTracking.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(ProductDbContext dbContext,
    IQueuePublisher queuePublisher,
    IElasticSearchService elasticSearchService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    public async Task<IActionResult> Get(int id)
    {
        var product = await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        
        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Product))]
    public async Task<IActionResult> Create(ProductCreationRequest request)
    {
        var product = request.MapTo();
        dbContext.Products.Add(product);

        await dbContext.SaveChangesAsync();
        
        var payload = product.MapTo(OperationType.Insert);

        await queuePublisher.PublishMessageAsync(payload);

        return Created(new Uri($"{HttpContext.Request.Path.Value}/{product.Id}", UriKind.Relative), product);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    public async Task<IActionResult> Update(int id, ProductModificationRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest(new ProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "BadRequest",
                Detail = "Product Id mismatch"
            });
        }

        var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        
        if (product is null)
        {
            return NotFound();
        }

        product.Name = request.Name;
        product.Color = request.Color;
        product.Size = request.Size;
        product.Barcode = request.Barcode;
        product.Brand = request.Brand;

        var payload = product.MapTo(OperationType.Update);

        var dbTask = dbContext.SaveChangesAsync();
        var queueTask = queuePublisher.PublishMessageAsync(payload);

        await Task.WhenAll(dbTask, queueTask);

        return Ok(product);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        var product = dbContext.Products.FirstOrDefault(x => x.Id == id);

        if (product is not null)
        {
            dbContext.Products.Remove(product);

            var payload = product.MapTo(OperationType.Delete);

            var dbTask = dbContext.SaveChangesAsync();
            var queueTask = queuePublisher.PublishMessageAsync(payload);

            await Task.WhenAll(dbTask, queueTask);
        }

        return NoContent();
    }

    [HttpGet("query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product[]))]
    public async Task<IActionResult> Query([FromQuery] QueryProductRequest request, CancellationToken cancellationToken)
    {
        var products = await elasticSearchService.SearchProductsAsync(request, cancellationToken);
        return Ok(products);
    }
}
