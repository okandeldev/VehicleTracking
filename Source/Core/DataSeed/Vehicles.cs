namespace Core.DataSeed
{
    public static class VehiclesSeed
    {
        public static List<(Guid Id, string VIN, string RegNr, Guid CustomerId, string CustomerName)> Vehicles = new List<(Guid Id, string VIN, string RegNr, Guid CustomerId, string CustomerName)>()
        {
            #region Kalles Grustransporter AB
             new (
                 Guid.Parse("5c5057b0-90cf-4439-a30d-de6929c2faf3"),
                 "YS2R4X20005399401",
                 "ABC123",
                 CustomersSeed.Customers[0].CustomerId,
                 CustomersSeed.Customers[0].CustomerName),
              new (
                 Guid.Parse("8c7f4d32-8bd5-4914-ada2-56c393061e64"),
                 "VLUR4X20009093588",
                 "DEF456",
                 CustomersSeed.Customers[0].CustomerId,
                 CustomersSeed.Customers[0].CustomerName),
               new (
                 Guid.Parse("0c5bb5c0-516f-4c3f-8961-74171d433c0c"),
                 "VLUR4X20009048066",
                 "GHI789",
                 CustomersSeed.Customers[0].CustomerId,
                 CustomersSeed.Customers[0].CustomerName), 
            #endregion

            #region Johans Bulk AB
             new (
                 Guid.Parse("469b6da0-d0f2-4f74-9598-a365fe965608"),
                 "YS2R4X20005388011",
                 "JKL012",
                 CustomersSeed.Customers[1].CustomerId,
                 CustomersSeed.Customers[1].CustomerName),
              new (
                 Guid.Parse("a39e1011-d40d-4b20-840e-4a4a10432694"),
                 "YS2R4X20005387949",
                 "MNO345",
                 CustomersSeed.Customers[1].CustomerId,
                 CustomersSeed.Customers[1].CustomerName), 
            #endregion

            #region Haralds Värdetransporter AB
             new (
                 Guid.Parse("6a6d5811-5e19-4789-ad5f-c15065c0e359"),
                 "VLUR4X20009048066",
                 "PQR678",
                 CustomersSeed.Customers[2].CustomerId,
                 CustomersSeed.Customers[2].CustomerName),
              new (
                 Guid.Parse("8c181bc6-56f5-4801-a37d-1ad6299a6576"),
                 "YS2R4X20005387055",
                 "STU901",
                 CustomersSeed.Customers[2].CustomerId,
                 CustomersSeed.Customers[2].CustomerName),
               
            #endregion
        };

    }
}
