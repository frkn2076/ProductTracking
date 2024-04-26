using Microsoft.Extensions.Options;
using ProductTracking.API.Services.Contracts;
using ProductTracking.API.Utils;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProductTracking.API.Services.Implementations;

public class QueueConfigurationManager : IQueueConfigurationManager
{
    public IModel Channel {  get; private set; }
    public EventingBasicConsumer Consumer { get; private set; }

    public QueueConfigurationManager(IOptions<ProductQueueSettings> productQueueSettings)
    {
        var factory = new ConnectionFactory()
        {
            HostName = productQueueSettings.Value.HostName
        };

        var connection = factory.CreateConnection();
        Channel = connection.CreateModel();
        Channel.QueueDeclare(queue: Constants.Queue.ProductQueue);
        Consumer = new EventingBasicConsumer(Channel);
    }
}
