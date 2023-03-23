using AutoMapper;
using EventBusRabbitMQ.Events;
using TrackingAPI.Models.Entities;
using TrackingAPI.Models.Request;
using TrackingAPI.Models.DTOs;

namespace TrackingAPI.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<VehiclePing, VehiclePingDto>().ReverseMap();
            CreateMap<VehiclePing, CreateVehiclePingDto>().ReverseMap();
            CreateMap<VehiclePing, GetVehiclePingDto>().ReverseMap(); 
            CreateMap<VehiclePing, RequestVehiclePing>().ReverseMap(); 

            CreateMap<VehiclePingEvent, RequestVehiclePing>().ReverseMap();
        }
    }
}
