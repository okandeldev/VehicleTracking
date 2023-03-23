using MediatR;

namespace CustomerAPI.Core.Commands
{
    #region Customer

    public record CreateCustomerCommand(CustomerCreateDTO Customer) : IRequest<Customer?>;
    public record UpdateCustomerCommand(CustomerUpdateDTO Customer) : IRequest<Customer?>;
     
    #endregion

}
