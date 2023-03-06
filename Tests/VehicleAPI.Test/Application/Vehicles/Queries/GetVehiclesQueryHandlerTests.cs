using Core.DataSeed;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using VehicleAPI.Application.QueryHandlers;
using VehicleAPI.Application.Test.Mocks;
using VehicleAPI.Core.Models;
using VehicleAPI.Core.Queries;
using X.PagedList;
using Xunit;

namespace VehicleAPI.Test.Application.VehicleStatus.Commands
{
    public class GetVehiclesQueryHandlerTests
    {
        private readonly GetVehicleQueryHandler _handler;

        public GetVehiclesQueryHandlerTests()
        {
            var mockVehiclesRepo = MockVehiclesRepository.GetVehiclesRepository<Guid>();
            _handler = new GetVehicleQueryHandler(mockVehiclesRepo.Object);
        }

        [Fact]
        public async Task Valid_GetVehicles_list()
        {
            IPagedList<Core.Domain.Entities.Vehicle> result = await _handler.Handle(new GetVehiclesQuery(new VehiclesQueryParams()
            {
                PageNumber = 1,
                PageSize = 10,
            }), CancellationToken.None);

            result.ShouldBeOfType<StaticPagedList<Core.Domain.Entities.Vehicle>>(); 
            result.GetMetaData().TotalItemCount.ShouldBe(VehiclesSeed.Vehicles.Count);
        }
    }
}