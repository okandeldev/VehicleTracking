using EventBusRabbitMQ.Events;
using MediatR;

namespace VehicleAPI.Core.Commands
{
    #region Vehicle

    public record CreateVehicleCommand(VehicleCreateDTO Vehicle) : IRequest<Vehicle?>;
    public record UpdateVehicleCommand(VehicleUpdateDTO Vehicle) : IRequest<Vehicle?>;
     
    public record VehiclePingCommand(VehiclePingEvent ping) : IRequest<Vehicle?>; 

    #endregion

}
