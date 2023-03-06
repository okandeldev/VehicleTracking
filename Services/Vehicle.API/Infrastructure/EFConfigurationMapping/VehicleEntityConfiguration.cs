using Core.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VehicleAPI.Infrastructure.EFConfigurationMapping
{
    public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(nameof(Vehicle).ToSnakeCase());
            builder.HasKey(t => t.Id); 
           
            builder.Property(p => p.Id)
            .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()");
            builder.HasOne(c => c.VehicleStatus)
          .WithMany()
          .HasForeignKey(c => c.VehicleStatusId);


            builder.Property(p => p.LastPing)
            .HasColumnType("timestamp without time zone") 
            .ValueGeneratedOnAdd();
        }
    }
}
