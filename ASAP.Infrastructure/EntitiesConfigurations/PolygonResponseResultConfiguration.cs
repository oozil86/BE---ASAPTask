using ASAP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASAP.Infrastructure.EntitiesConfigurations
{
    public class PolygonResponseResultConfiguration : IEntityTypeConfiguration<PolygonResponseResult>
    {
        public void Configure(EntityTypeBuilder<PolygonResponseResult> builder)
        {
            builder.ToTable(nameof(PolygonResponseResult)).HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();         
            builder.HasIndex(c=>c.Reference).IsUnique();
            builder.Property(c => c.Reference).HasDefaultValueSql("newid()").ValueGeneratedOnAdd();

            builder.HasOne(c => c.PolygonResponse).WithMany(c => c.Results).HasForeignKey(c => c.PolygonResponseId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
