namespace Core.DataSeed
{
    public static class CustomersSeed
    {
        public static List<(Guid CustomerId, string CustomerName, string Address)> Customers = new List<(Guid CustomerId, string CustomerName, string Address)>()
        {
             new ( Guid.Parse("51c672c4-a292-4e5b-babd-6534a34e6853"),"Kalles Grustransporter AB","Cementvägen 8, 111 11 Södertälje"),
             new ( Guid.Parse("b906b176-c75b-4a7d-92df-743f626d4fa1"),"Johans Bulk AB","Cementvägen 8, 111 11 Södertälje"),
             new ( Guid.Parse("d0055766-624e-44a8-b3f9-286429716226"),"Haralds Värdetransporter AB","Balkvägen 12, 222 22 Stockholm"), 
        };
    }
}
