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
    public class UpdateVehicleCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly VehicleUpdateDTO _vehicleUpdateDTO;
        private readonly UpdateVehicleCommandHandler _handler;

        public UpdateVehicleCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            var mockVehiclesRepo = MockVehiclesRepository.GetVehiclesRepository<Guid>();
            _handler = new UpdateVehicleCommandHandler(mockVehiclesRepo.Object, new VehicleUpdateValidator());

            _vehicleUpdateDTO = new VehicleUpdateDTO
            {
                VehicleId = VehiclesSeed.Vehicles[0].Id,
                VIN = "VIN",
                RegNr = VehiclesSeed.Vehicles[0].RegNr,
                CustomerId = VehiclesSeed.Vehicles[0].CustomerId,
                CustomerName = VehiclesSeed.Vehicles[0].CustomerName,
            };
        }

        [Fact]
        public async Task UpdateVehicle_Should_NotUpdated()
        {
            _vehicleUpdateDTO.VIN = String.Empty;
            var result = await _handler.Handle(new UpdateVehicleCommand(_vehicleUpdateDTO) { }, CancellationToken.None);
            var mockVehiclesRepo = MockVehiclesRepository.GetVehiclesRepository<Guid>();
            var vehicles = await mockVehiclesRepo.Object.GetAllAsync(CancellationToken.None);

            result.ShouldBeNull();
        }
        [Fact]
        public async Task UpdateVehicle_Should_BeUpdated()
        { 
            var mockVehiclesRepo = MockVehiclesRepository.GetVehiclesRepository<Guid>();
            var vehicles = await mockVehiclesRepo.Object.GetAllAsync(CancellationToken.None);

            var result = await _handler.Handle(new UpdateVehicleCommand(_vehicleUpdateDTO) { }, CancellationToken.None);
            Assert.Equal(_vehicleUpdateDTO.VIN, result.VIN);
        } 
    }
}
