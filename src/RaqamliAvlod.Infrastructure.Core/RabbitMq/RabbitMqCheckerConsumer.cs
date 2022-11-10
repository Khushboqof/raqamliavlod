using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RaqamliAvlod.Infrastructure.Core.RabbitMQ
{
    public class RabbitMqCheckerConsumer : BackgroundService
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _conn;
        private readonly IModel _channel;
        private readonly string _queueName = "LastRabbitQueue";
        private readonly IServiceProvider _serviceProvider;

        public RabbitMqCheckerConsumer(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var subconfiguration = configuration.GetSection("RabbitMq");
            _factory = new ConnectionFactory()
            {
                //HostName = subconfiguration.GetSection("Host").Value,
                //Port = int.Parse(subconfiguration.GetSection("Port").Value),
                //UserName = subconfiguration.GetSection("Username").Value,
                //Password = subconfiguration.GetSection("Password").Value,
                Uri = new Uri("amqps://vqgptogg:qF7mWZC7FfPEhvrcOQtfxKvaKkG4PPZW@armadillo.rmq.cloudamqp.com/vqgptogg")
            };
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: _queueName,
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Receive_Handle;
            _channel.BasicConsume(_queueName, false, consumer);
        }

        private void Receive_Handle(object sender, BasicDeliverEventArgs model)
        {

        }
    }
}
