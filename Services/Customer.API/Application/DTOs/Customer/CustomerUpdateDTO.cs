

namespace CustomerAPI.Core.Application.DTOs
{
    public class CustomerUpdateDTO
    {
        public Guid? CustomerId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; } 
    }
}
