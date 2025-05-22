using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

public class EventBus
{
    private readonly RabbitMqSettings _settings;
    private IConnection _connection;
    private IModel _channel;

    public EventBus(IOptions<RabbitMqSettings> settings)
    {
        _settings = settings.Value;
        Connect();
    }

    private void Connect()
    {
        if (_connection != null) return;

        var factory = new ConnectionFactory
        {
            HostName = _settings.HostName,
            UserName = _settings.UserName,
            Password = _settings.Password
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        Console.WriteLine("Connected to RabbitMQ");
    }

    public void Publish<T>(T message)
    {
        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        _channel.QueueDeclare(queue: _settings.QueueName, durable: true, exclusive: false, autoDelete: false);
        _channel.BasicPublish(
            exchange: "",
            routingKey: _settings.QueueName,
            basicProperties: null,
            body: body
        );

        Console.WriteLine($"Published to {_settings.QueueName}: {json}");
    }

    public void Subscribe<T>(Func<T, Task> handler)
    {
        _channel.QueueDeclare(queue: _settings.QueueName, durable: true, exclusive: false, autoDelete: false);

        var consumer = new RabbitMQ.Client.Events.EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);
            var message = JsonSerializer.Deserialize<T>(json);
            Console.WriteLine($"Received from {_settings.QueueName}: {json}");

            if (message != null)
            {
                await handler(message);
            }

            _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        };

        _channel.BasicConsume(queue: _settings.QueueName, autoAck: false, consumer: consumer);
    }
}
