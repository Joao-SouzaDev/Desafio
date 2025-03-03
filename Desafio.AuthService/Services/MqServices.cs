using RabbitMQ.Client;
using System.Text;

namespace Desafio.AuthService.Services
{
    public class MqServices
    {
        private readonly IConfiguration _configuration;
        public MqServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMessageAsync(string message)
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
                await channel.QueueDeclareAsync(queue: "create_productOwner",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                var body = Encoding.UTF8.GetBytes(message);
                await channel.BasicPublishAsync(exchange: "",
                                     routingKey: "create_productOwner",
                                     body: body);
            }
        }
    }
}
