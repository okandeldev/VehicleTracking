using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleAPI.Controllers;
using VehicleAPI.Core.Queries;
using X.PagedList; 
using VehicleAPI.Core.Models;
using Xunit;
using VehicleAPI.Core.Domain.Entities;
using AutoMapper;
using VehicleAPI.Mappers;
using VehicleAPI.Application.Test.Mocks;
using Microsoft.Extensions.DependencyInjection;
using VehicleAPI.Core.Repositories;
using FluentValidation;
using VehicleAPI.Application.DTOs;
using VehicleAPI.Application.Validator;
using Shouldly;
using Core.DataSeed;
using Core.Shared;

namespace VehicleAPI.Controllers.Test
{
    public class VehiclesControllerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMediator> mediator;
        private readonly VehiclesController _controller;
        public VehiclesControllerTests()
        {
              mediator = new Mock<IMediator>();

            //Arrange
            //mediator.Setup(m => m.Send(It.IsAny<GetVehiclesQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(MockVehiclesRepository.Vehicles.ToPagedListAsync(1, 10, CancellationToken.None).Result);
            mediator.Setup(m => m.Send(It.IsAny<GetVehiclesQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetVehiclesQuery query, CancellationToken cancellationToken) =>
            {
                return MockVehiclesRepository.Vehicles.ToPagedListAsync(query.queryParams.PageNumber, query.queryParams.PageSize, CancellationToken.None).Result;
            });


            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            var mockVehiclesRepo = MockVehiclesRepository.GetVehiclesRepository<Guid>();

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
             
            serviceProvider
                .Setup(x => x.GetService(typeof(IVehiclesRepository)))
                .Returns(mockVehiclesRepo.Object);

            serviceProvider
                .Setup(x => x.GetService(typeof(IValidator<VehicleCreateDTO>)))
                .Returns(new VehicleCreateValidator());
             
            serviceProvider
                .Setup(x => x.GetService(typeof(IValidator<VehicleUpdateDTO>)))
                .Returns(new VehicleUpdateValidator());
             
            _controller = new VehiclesController(mediator.Object, _mapper, new VehicleCreateValidator(),
                new VehicleUpdateValidator());

            
        } 
        [Fact]
        public async Task Test_Get_Vehicles_ItShouldReturnPagedResponse_VehicleDTO()
        {
            //Act
            var result = await _controller.GetAsync(new VehiclesQueryParams());

            //Assert
            result.ShouldBeOfType<PagedResponse<VehicleDTO>>();
            result.pageInformation.TotalItemCount.ShouldBe(VehiclesSeed.Vehicles.Count); 
        }

        [Fact]
        public async Task Test_Get_Vehicles_ItShouldCallGetVehiclesQueryMediator()
        {  
            //Act
            await mediator.Object.Send(new GetVehiclesQuery(new VehiclesQueryParams()));

            //Assert
            mediator.Verify(x => x.Send(It.IsAny<GetVehiclesQuery>(), It.IsAny<CancellationToken>()));
        }
    }
}
