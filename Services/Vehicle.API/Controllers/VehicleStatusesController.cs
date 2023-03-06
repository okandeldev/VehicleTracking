using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Core.Queries;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleStatusesController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public VehicleStatusesController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        #region Vehicle Statuses 

        [HttpGet]
        public async Task<IEnumerable<VehicleStatus>> GetAsync()
        {
            return await _mediatR.Send(new GetVehicleStatusQuery());
        }
        #endregion
    }
}
