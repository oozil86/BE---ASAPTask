using ASAP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASAP.Infrastructure.EntitiesConfigurations
{
    public class PolygonResponseConfiguration : IEntityTypeConfiguration<PolygonResponse>
    {
        public void Configure(EntityTypeBuilder<PolygonResponse> builder)
        {
            builder.ToTable(nameof(PolygonResponse)).HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
           
            builder.HasIndex(c=>c.Reference).IsUnique();
            builder.Property(c => c.Reference).HasDefaultValueSql("newid()").ValueGeneratedOnAdd();
        }
    }
}
