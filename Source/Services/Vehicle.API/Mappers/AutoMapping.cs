using AutoMapper;

namespace VehicleAPI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
        }
    }
}
