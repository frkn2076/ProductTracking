using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProductTracking.API.Services.Contracts;

public interface IQueueConfigurationManager
{
    IModel Channel { get; }

    EventingBasicConsumer Consumer { get; }
}
