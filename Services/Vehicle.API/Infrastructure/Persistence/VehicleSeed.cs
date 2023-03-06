using Core.Enum;
using Core.DataSeed;
namespace VehicleAPI.Infrastructure.Persistence
{
    public static class VehicleSeed
    {
        public static Vehicle[] Vehicles = VehiclesSeed.Vehicles.Select(c => new Vehicle()
        {
            Id = c.Id,
            VIN = c.VIN,
            RegNr = c.RegNr,
            CustomerId = c.CustomerId,
            CustomerName = c.CustomerName,
        }).ToArray();

        public static VehicleStatus[] VehicleStatuses = new VehicleStatus[]
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
    }
}
