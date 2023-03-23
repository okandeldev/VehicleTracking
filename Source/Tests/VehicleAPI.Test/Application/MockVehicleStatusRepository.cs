using Core.Enum;
using Moq;
using System.Collections.Generic;
using System.Threading;
using VehicleAPI.Core.Domain.Entities;
using VehicleAPI.Core.Repositories;

namespace VehicleAPI.Application.Test.Mocks
{
    public static class MockVehicleStatusRepository
    {
        public static Mock<IVehicleStatusRepository> GetVehicleStatusRepository()
        {
            var vehicleStatues = new List<VehicleStatus>
            {
                new VehicleStatus()
                {
                    Id = (short)VehicleStatusEnum.Connected,
                        Name =  VehicleStatusEnum.Connected.ToString(),
                },
                 new VehicleStatus()
                {
                    Id = (short)VehicleStatusEnum.Disconnected,
                        Name =  VehicleStatusEnum.Disconnected.ToString(),
                }  
            };

            var mockRepo = new Mock<IVehicleStatusRepository>(); 
            mockRepo.Setup(r => r.GetAllAsync(CancellationToken.None)).ReturnsAsync(vehicleStatues); 
            return mockRepo; 
        }
    }
}
