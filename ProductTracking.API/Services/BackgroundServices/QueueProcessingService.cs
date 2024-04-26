using Newtonsoft.Json;
using ProductTracking.API.Services.Contracts;
using ProductTracking.API.Utils;
using RabbitMQ.Client;
using System.Text;

namespace ProductTracking.API.Services.BackgroundServices;

public class QueueProcessingService(ILogger<QueueProcessingService> logger,
    IQueueProcessor queueProcessor,
    IQueueConfigurationManager queueConfigurationManager) : BackgroundService
{

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("BackgroundService is starting.");

        queueConfigurationManager.Consumer.Received += async (model, eventArgs) =>
        {

            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var productPayload = JsonConvert.DeserializeObject<ProductPayload>(message);

            logger.LogInformation("Consumed the queue message: {0}", message);

            await queueProcessor.PerformOperationAsync(productPayload, cancellationToken);
        };

        queueConfigurationManager.Channel.BasicConsume(queue: Constants.Queue.ProductQueue, autoAck: true, consumer: queueConfigurationManager.Consumer);

        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(1000, cancellationToken);
        }

        logger.LogInformation("BackgroundService is stopping.");
    }
}
