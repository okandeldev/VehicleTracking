using AutoMapper;
using Core.DataSeed;
using EventBusRabbitMQ.Events;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using VehicleAPI.Application.CommandHandlers;
using VehicleAPI.Application.Test.Mocks;
using VehicleAPI.Core.Commands;
using VehicleAPI.Core.Repositories;
using VehicleAPI.Mappers;
using Xunit;

namespace VehicleAPI.Test.Application.Vehicle.Commands
{
    public class VehiclePingCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly VehiclePingEvent _VehiclePingEvent;
        private readonly VehiclePingCommandHandler _handler;

        public VehiclePingCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }); 
            _mapper = mapperConfig.CreateMapper();
             
            var serviceProvider = new Mock<IServiceProvider>();  
            var serviceScope = new Mock<IServiceScope>();
            serviceScope.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);

            var serviceScopeFactory = new Mock<IServiceScopeFactory>();
            serviceScopeFactory
                .Setup(x => x.CreateScope())
                .Returns(serviceScope.Object);

            serviceProvider
                .Setup(x => x.GetService(typeof(IServiceScopeFactory)))
                .Returns(serviceScopeFactory.Object);

            var mockVehiclesRepo = MockVehiclesRepository.GetVehiclesRepository<Guid>();
            serviceProvider
                .Setup(x => x.GetService(typeof(IVehiclesRepository)))
                .Returns(mockVehiclesRepo.Object); 

           
            _handler = new VehiclePingCommandHandler(serviceScopeFactory.Object);

            _VehiclePingEvent = new VehiclePingEvent
            {
                VehicleId = VehiclesSeed.Vehicles[0].Id.ToString(),
                Message = "new message",
                date = DateTime.UtcNow, 
            };
        }

        [Fact]
        public async Task Valid_Vehicle_Ping()
        {
            var mockVehiclesRepo = MockVehiclesRepository.GetVehiclesRepository<Guid>();
            var vehicles = await mockVehiclesRepo.Object.GetAllAsync(CancellationToken.None);

            var result = await _handler.Handle(new VehiclePingCommand(_VehiclePingEvent) { }, CancellationToken.None);
            Assert.Equal(_VehiclePingEvent.date.ToShortTimeString(), result.LastPing.Value.ToShortTimeString());
            vehicles.Count.ShouldBe(VehiclesSeed.Vehicles.Count);
        }

        [Fact]
        public async Task InValid_Vehicle_Ping()
        {
            _VehiclePingEvent.VehicleId = String.Empty;
            var result = await _handler.Handle(new VehiclePingCommand(_VehiclePingEvent) { }, CancellationToken.None);
            var mockVehiclesRepo = MockVehiclesRepository.GetVehiclesRepository<Guid>();
            var vehicles = await mockVehiclesRepo.Object.GetAllAsync(CancellationToken.None);

            result.ShouldBeNull();
            vehicles.Count.ShouldBe(VehiclesSeed.Vehicles.Count);

        }
    }
}
