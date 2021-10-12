using GuideAPI.Mapper;
using GuideAPI.Services.AsyncDataServices;
using GuideAPI.Services.ReportServices;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuideAPI.Services.EventBusServices
{
    public class EventBusService : BackgroundService
    {
        private readonly IRabbitmqService _rabbitmqService;
        private readonly IReportService _reportService;
        private readonly IAutoMapper _autoMapper;

        public EventBusService(IReportService reportService,
            IRabbitmqService rabbitmqService,IAutoMapper autoMapper)
        {
            _rabbitmqService = rabbitmqService;
            _reportService = reportService;
            _autoMapper = autoMapper;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Event Bus Listening
                var factory = _rabbitmqService.CreateConnectionFactory();
                // Create Connection 
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = _rabbitmqService.GetChannel(factory))
                    {
                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);
                            _reportService.AddReportRequest();
                        };
                        channel.BasicConsume("createreport", true, consumer);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
