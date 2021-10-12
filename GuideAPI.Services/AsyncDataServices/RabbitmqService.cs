
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Services.AsyncDataServices
{
    public class RabbitmqService : IRabbitmqService
    {
        private readonly IConfiguration _configuration;

        public RabbitmqService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ConnectionFactory CreateConnectionFactory()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = _configuration["HostName"]
            };
            return connectionFactory;
        }

        public void DeclareQueue(IModel channel, string data, string routingKey,
                    string queueName, bool durable = false, bool exlusive = false, bool autoDelete = false)
        {
            // Declare Queue
            channel.QueueDeclare(queueName, durable, exlusive, autoDelete, null);
            // Message Body
            var body = Encoding.UTF8.GetBytes(data);
            // Publish Message
            channel.BasicPublish(exchange: "",
                                 routingKey: routingKey,
                                 basicProperties: null,
                                 body: body);
        }

        public IModel GetChannel(ConnectionFactory connectionFactory)
        {
            var channel = connectionFactory.CreateConnection();
            return channel.CreateModel();
        }
    }
}
