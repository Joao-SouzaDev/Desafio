
using Desafio.NotificacaoService.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using System.Text;

namespace Desafio.NotificacaoService.Services
{
    public class MqReceiverService : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private string username = string.Empty;
        private string password = string.Empty;
        public MqReceiverService(IConfiguration configuration)
        {
            _configuration = configuration;
            username = _configuration["Email:username"];
            password = _configuration["Email:password"];
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration["RabbitMq:HostName"]
            };
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(queue: "send_message");
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += Consumer_ReceivedAsync;
            await channel.BasicConsumeAsync(queue: "send_message", autoAck: true, consumer: consumer);
        }

        private Task Consumer_ReceivedAsync(object sender, BasicDeliverEventArgs @event)
        {
            var body = @event.Body.ToArray();
            var notificationMessage = JsonSerializer.Deserialize<NotificationMessage>(Encoding.UTF8.GetString(body));
            EmailServices.SendEmail(notificationMessage,username,password);
            return Task.CompletedTask;
        }
    }
}
