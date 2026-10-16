using Legacy911DataConverter.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Legacy911DataConverter.Infrastructure.Data.Configuration
{
    public class RespondingUnitConfiguration : IEntityTypeConfiguration<RespondingUnit>
    {
        public void Configure(EntityTypeBuilder<RespondingUnit> builder)
        {
            builder.ToTable("RespondingUnits");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UnitCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(x => x.UnitCode)
                   .IsUnique();

            builder.Property(x => x.UnitType)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Agency)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.IsActive)
                   .IsRequired();

            builder.HasOne<ConversionBatch>()
                    .WithMany()
                    .HasForeignKey(x => x.BatchId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
