using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideAPI.Services.AsyncDataServices
{
    public interface IRabbitmqService
    {
        /// <summary>
        ///  Create Rabbit Mq Connection
        /// </summary>
        /// <returns></returns>
        ConnectionFactory CreateConnectionFactory();


        /// <summary>
        ///  Get Connection Channel
        /// </summary>
        /// <returns></returns>
        IModel GetChannel(ConnectionFactory connectionFactory);


        /// <summary>
        ///  Declare Queue
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="queueName"></param>
        /// <param name="durable"></param>
        /// <param name="exlusive"></param>
        /// <param name="autoDelete"></param>
        void DeclareQueue(IModel channel, string data, string routingKey,
                   string queueName, bool durable = false, bool exlusive = false, bool autoDelete = false);
    }
}
