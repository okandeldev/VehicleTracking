using Core.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerAPI.Infrastructure.EFConfigurationMapping
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer).ToSnakeCase());
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id)
            .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()");
        }
    }
}
