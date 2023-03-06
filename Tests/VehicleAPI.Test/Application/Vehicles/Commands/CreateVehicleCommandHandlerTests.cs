using AutoMapper;
using Core.DataSeed;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using VehicleAPI.Application.CommandHandlers;
using VehicleAPI.Application.DTOs;
using VehicleAPI.Application.Test.Mocks;
using VehicleAPI.Application.Validator;
using VehicleAPI.Core.Commands;
using VehicleAPI.Mappers;
using Xunit;

namespace VehicleAPI.Test.Application.Vehicle.Commands
{
    public class CreateVehicleCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly VehicleCreateDTO _vehicleCreateDTO;
        private readonly CreateVehicleCommandHandler _handler;

        public CreateVehicleCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            var mockVehiclesRepo = MockVehiclesRepository.GetVehiclesRepository<Guid>();
            _handler = new CreateVehicleCommandHandler(mockVehiclesRepo.Object,new VehicleCreateValidator());

            _vehicleCreateDTO = new VehicleCreateDTO
            {
                VIN = "VIN",
                RegNr = "RegNr",
                CustomerId = CustomersSeed.Customers[0].CustomerId,
                CustomerName = CustomersSeed.Customers[0].CustomerName,
            };
        }

        [Fact]
        public async Task CreateVehicle_Should_NotAdded()
        { 
            _vehicleCreateDTO.VIN = String.Empty;
            var result = await _handler.Handle(new CreateVehicleCommand(_vehicleCreateDTO) { }, CancellationToken.None);
            var mockVehiclesRepo = MockVehiclesRepository.GetVehiclesRepository<Guid>();
            var vehicles = await mockVehiclesRepo.Object.GetAllAsync(CancellationToken.None);

            result.ShouldBeNull();
            vehicles.Count.ShouldBe(VehiclesSeed.Vehicles.Count);

        }
        [Fact]
        public async Task CreateVehicle_Should_Added()
        {
            var mockVehiclesRepo = MockVehiclesRepository.GetVehiclesRepository<Guid>();
            var vehicles = await mockVehiclesRepo.Object.GetAllAsync(CancellationToken.None);

            var result = await _handler.Handle(new CreateVehicleCommand(_vehicleCreateDTO) { }, CancellationToken.None);

            result.ShouldBeOfType<Core.Domain.Entities.Vehicle>();
            Assert.Equal(_vehicleCreateDTO.VIN, result.VIN);
            vehicles.Count.ShouldBe(VehiclesSeed.Vehicles.Count + 1);
        }


    }
}
