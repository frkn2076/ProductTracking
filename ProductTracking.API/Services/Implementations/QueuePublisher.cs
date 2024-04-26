using Newtonsoft.Json;
using ProductTracking.API.Services.Contracts;
using ProductTracking.API.Utils;
using RabbitMQ.Client;
using System.Text;

namespace ProductTracking.API.Services.Implementations;

public class QueuePublisher(ILogger<QueuePublisher> logger, 
    IQueueConfigurationManager queueConfigurationManager) : IQueuePublisher
{
    public async Task PublishMessageAsync(ProductPayload payload)
    {
        var message = JsonConvert.SerializeObject(payload);
        var body = Encoding.UTF8.GetBytes(message);

        await Task.Run(() =>
        {

            queueConfigurationManager.Channel.BasicPublish(exchange: string.Empty, routingKey: Constants.Queue.ProductQueue, basicProperties: null, body: body);
            logger.LogInformation("Published the queue message: {0}", message);

        });
    }
}
