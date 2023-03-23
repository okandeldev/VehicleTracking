
using Core.DataSeed;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VehicleAPI.Core.Domain.Entities;
using VehicleAPI.Core.Models;
using VehicleAPI.Core.Repositories;
using X.PagedList;

namespace VehicleAPI.Application.Test.Mocks
{
    public static class MockVehiclesRepository
    {
        private static List<Vehicle> _vehicles = VehiclesSeed.Vehicles.Select(c => new Vehicle()
        {
            Id = c.Id,
            VIN = c.VIN,
            RegNr = c.RegNr,
            CustomerId = c.CustomerId,
            CustomerName = c.CustomerName,
        }).ToList();

        public static List<Vehicle> Vehicles
        {
            get
            {
                return _vehicles;
            }
            set { _vehicles = value; }
        }

        public static Mock<IVehiclesRepository> GetVehiclesRepository<T>()
        {

            var mockRepo = new Mock<IVehiclesRepository>();

            mockRepo.Setup(r => r.GetAllAsync(CancellationToken.None)).ReturnsAsync(Vehicles);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Vehicle>())).ReturnsAsync((Vehicle vehicle) =>
            {
                Vehicles.Add(vehicle);
                return vehicle;
            });

            mockRepo.Setup(r => r.GetPagedListAsync(It.IsAny<VehiclesQueryParams>(), CancellationToken.None))
                .ReturnsAsync((VehiclesQueryParams queryParams, CancellationToken cancellationToken) =>
             {
                 return Vehicles.ToPagedListAsync(queryParams.PageNumber, queryParams.PageSize, CancellationToken.None).Result;
             }); 

            mockRepo.Setup(p => p.GetByIdAsync(It.IsAny<It.IsAnyType>()))
                .ReturnsAsync((Guid id) =>
                {

                    return Vehicles.FirstOrDefault(x => x.Id == id);
                });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Vehicle>())).Callback((Vehicle vehicle) =>
            {
                Vehicles = Vehicles.Select(x =>
               {
                   if (x.Id == vehicle.Id)
                   {
                       x.VIN = vehicle.VIN;
                       x.RegNr = vehicle.RegNr;
                       x.CustomerId = vehicle.CustomerId;
                       x.CustomerName = vehicle.CustomerName;
                   };
                   return x;
               }).ToList();
            });

            return mockRepo;
        }
    }
}
