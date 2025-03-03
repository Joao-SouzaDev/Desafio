using Desafio.ProductService.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Desafio.ProductService.Services
{
    public class MqReceiverServices : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _service;
        public MqReceiverServices(IConfiguration configuration, IServiceProvider service)
        {
            _configuration = configuration;
            _service = service;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration["RabbitMq:HostName"],
            };
            var connection = await  factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(queue: "create_productOwner",false,false,false, null);
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += Consumer_ReceivedAsync;
            await channel.BasicConsumeAsync(queue: "create_productOwner", autoAck: true, consumer: consumer);
        }

        private Task Consumer_ReceivedAsync(object sender, BasicDeliverEventArgs @event)
        {
            var body = @event.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var userId = Guid.Parse(message);
            var productOwner = new ProductOwner(userId);
            using(var scope = _service.CreateScope())
            {
                var productOwnerService = scope.ServiceProvider.GetRequiredService<ProductOwnerService>();
                productOwnerService.AddProductOwner(productOwner);
            }
            return Task.CompletedTask;
        }
    }
}
