using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VehicleAPI.Application.QueryHandlers;
using VehicleAPI.Application.Test.Mocks;
using VehicleAPI.Core.Queries;
using Xunit;

namespace VehicleAPI.Test.Application.VehicleStatus.Commands
{
    public class GetVehicleStatusQueryHandlerTests
    { 
        private readonly GetVehicleStatusQueryHandler _handler;

        public GetVehicleStatusQueryHandlerTests()
        {
            var mockVehicleStatusRepo = MockVehicleStatusRepository.GetVehicleStatusRepository(); 
            _handler = new GetVehicleStatusQueryHandler(mockVehicleStatusRepo.Object); 
        }

        [Fact]
        public async Task Valid_GetVehicleStatues_list()
        {   
            var result = await _handler.Handle(new GetVehicleStatusQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<Core.Domain.Entities.VehicleStatus>>();

            result.Count.ShouldBe(2); 
        } 
    }
}