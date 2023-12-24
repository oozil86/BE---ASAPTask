using ASAP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASAP.Infrastructure.EntitiesConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(nameof(Client)).HasKey(c => c.Id);

            builder.Property(c => c.Id).UseIdentityColumn();

            builder.HasIndex(c=>c.Reference).IsUnique();
            builder.Property(c => c.Reference).HasDefaultValueSql("newid()").ValueGeneratedOnAdd();
        }
    }
}
