using AutoMapper;
using EventBusRabbitMQ.Events;
using TrackingAPI.Models.Entities;
using TrackingAPI.Models.Request;
using TrackingAPI.Models.Response;

namespace TrackingAPI.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<VehiclePing, ResponseVehicleHistoryStatus>().ReverseMap();
            CreateMap<VehiclePing, ResponseCreateVehicleHistoryStatus>().ReverseMap();
            CreateMap<VehiclePing, ResponseGetVehicleHistoryStatus>().ReverseMap(); 
            CreateMap<VehiclePing, RequestVehiclePing>().ReverseMap();



            CreateMap<VehiclePingEvent, RequestVehiclePing>().ReverseMap();
        }
    }
}
