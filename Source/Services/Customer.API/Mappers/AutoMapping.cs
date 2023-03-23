using AutoMapper;

namespace CustomerAPI.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
