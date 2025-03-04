using Desafio.FeedbackService.Models;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Desafio.FeedbackService.Services
{
    public class MqServices
    {
        private readonly IConfiguration _configuration;
        public MqServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMessageAsync(NotificationMessage message)
        {
            var hostName = _configuration["RabbitMq:HostName"];
            if(string.IsNullOrEmpty(hostName))
            {
                throw new ArgumentNullException("RabbitMq:HostName");
            }
            var factory = new ConnectionFactory() { HostName = hostName };
            using (var connection =  await factory.CreateConnectionAsync())
            using (var channel = await connection.CreateChannelAsync())
            {
                await channel.QueueDeclareAsync(queue: "send_message",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
                await channel.BasicPublishAsync(exchange: "",
                                     routingKey: "send_message",
                                     body: body);
            }
        }
    }
}
