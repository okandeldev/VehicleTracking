using AutoMapper;
using Core.Shared;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Core.Commands;
using VehicleAPI.Core.Models;
using VehicleAPI.Core.Queries;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IMapper _mapper;
        private readonly IValidator<VehicleCreateDTO> _requestCreateValidator;
        private readonly IValidator<VehicleUpdateDTO> _requestUpdateValidator;

        public VehiclesController(IMediator mediatR, IMapper mapper,
            IValidator<VehicleCreateDTO> requestCreateValidator, IValidator<VehicleUpdateDTO> requestUpdateValidator)
        {
            _mediatR = mediatR;
            _mapper = mapper;
            _requestCreateValidator = requestCreateValidator;
            _requestUpdateValidator = requestUpdateValidator;
        }

        #region Vehicles 

        [HttpGet]
        public async Task<PagedResponse<VehicleDTO>> GetAsync([FromQuery] VehiclesQueryParams queryParams)
        {
            var result = await _mediatR.Send(new GetVehiclesQuery(queryParams));
            var mappedResult = _mapper.Map<List<VehicleDTO>>(result.ToList());
            return new PagedResponse<VehicleDTO>(mappedResult, new PageInformation(result.PageCount, result.TotalItemCount, result.PageNumber, result.PageSize));
        }
         
        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetAsync(Guid vehicleId)
        {
            var request = await _mediatR.Send(new GetVehicleByIDQuery(vehicleId));
            if (request == null)
            {
                return NotFound("Vehicle does not exist.");
            }
            return Ok(request);
        }
         
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] VehicleCreateDTO model)
        {
            var validationResult = await _requestCreateValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var request = await _mediatR.Send(new CreateVehicleCommand(model)); 
            return Ok(_mapper.Map<VehicleDTO>(request));
        }
         
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid VehicleId, [FromForm] VehicleUpdateDTO model)
        {
            model.VehicleId = VehicleId;
            var validationResult = await _requestUpdateValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var res = await _mediatR.Send(new UpdateVehicleCommand(model));
            if (res == null)
            {
                return NotFound("Vehicle does not exist.");
            }
            return Ok(_mapper.Map<VehicleDTO>(res));
        }
        #endregion
    }
}
