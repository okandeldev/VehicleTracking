using AutoMapper;
using EventBusRabbitMQ;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using VehicleAPI.Common.HubConfig;
using VehicleAPI.Core.Commands;

namespace VehicleAPI.Infrastructure.RabbitMQ
{
    public class EventBusRabbitMQConsumer
    {
        private readonly IRabbitMQConnection _connection;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IHubContext<NotificationsHub> _hubContext;
        private readonly NotificationsHub _hub;

        public EventBusRabbitMQConsumer(IRabbitMQConnection connection, IMediator mediator, IMapper mapper, IHubContext<NotificationsHub> hubContext, NotificationsHub hub)
        {
            _hub = hub;
            _hubContext = hubContext;
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Consume()
        {
            var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: EventBusConstants.VehiclePingQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += PresistVehicleStateEventHandler;
            consumer.Received += SendSignalRNotificationEventHandler;

            channel.BasicConsume(queue: EventBusConstants.VehiclePingQueue, autoAck: true, consumer: consumer);
        }

        private async void PresistVehicleStateEventHandler(object sender, BasicDeliverEventArgs e)
        {
            if (e.RoutingKey == EventBusConstants.VehiclePingQueue)
            {
                var message = Encoding.UTF8.GetString(e.Body.Span);
                var vehiclePingEvent = JsonConvert.DeserializeObject<VehiclePingEvent>(message);

                var command = _mapper.Map<VehiclePingCommand>(vehiclePingEvent);
                var result = await _mediator.Send(command);
            }
        }
        private async void SendSignalRNotificationEventHandler(object sender, BasicDeliverEventArgs e)
        {
            if (e.RoutingKey == EventBusConstants.VehiclePingQueue)
            {
                var message = Encoding.UTF8.GetString(e.Body.Span);
                var vehiclePingEvent = JsonConvert.DeserializeObject<VehiclePingEvent>(message);
                await _hub.SendAsyncToCaller(_hubContext, "VehiclePingNotificationData", vehiclePingEvent); 
            }
        }
        public void Disconnect()
        {
            _connection.Dispose();
        }
    }
}
