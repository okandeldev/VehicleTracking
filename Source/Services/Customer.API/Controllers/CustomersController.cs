using AutoMapper;
using Core.Shared;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CustomerAPI.Core.Commands;
using CustomerAPI.Core.Models;
using CustomerAPI.Core.Queries;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerCreateDTO> _requestCreateValidator;
        private readonly IValidator<CustomerUpdateDTO> _requestUpdateValidator;

        public CustomersController(IMediator mediatR, IHttpContextAccessor httpContext, IMapper mapper,
            IValidator<CustomerCreateDTO> requestCreateValidator, IValidator<CustomerUpdateDTO> requestUpdateValidator)
        {
            _mediatR = mediatR;
            _mapper = mapper;
            _requestCreateValidator = requestCreateValidator;
            _requestUpdateValidator = requestUpdateValidator;
        }

        #region Customers 

        [HttpGet]
        public async Task<PagedResponse<CustomerDTO>> GetAsync([FromQuery] CustomersQueryParams queryParams)
        {
            var result = await _mediatR.Send(new GetCustomersQuery(queryParams));
            var mappedResult = _mapper.Map<List<CustomerDTO>>(result.ToList());
            return new PagedResponse<CustomerDTO>(mappedResult, new PageInformation(result.PageCount, result.TotalItemCount, result.PageNumber, result.PageSize));
        }
         
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsync(Guid customerId)
        {
            var request = await _mediatR.Send(new GetCustomerByIDQuery(customerId));
            if (request == null)
            {
                return NotFound("Customer does not exist.");
            }
            return Ok(request);
        }
         
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CustomerCreateDTO model)
        {
            var validationResult = await _requestCreateValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var request = await _mediatR.Send(new CreateCustomerCommand(model));

            return Ok(_mapper.Map<CustomerDTO>(request));
        }
         
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid CustomerId, [FromForm] CustomerUpdateDTO model)
        {
            model.CustomerId = CustomerId;
            var validationResult = await _requestUpdateValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var res = await _mediatR.Send(new UpdateCustomerCommand(model));
            if (res == null)
            {
                return NotFound("Customer does not exist.");
            }
            return Ok(_mapper.Map<CustomerDTO>(res));
        }
        #endregion
    }
}
