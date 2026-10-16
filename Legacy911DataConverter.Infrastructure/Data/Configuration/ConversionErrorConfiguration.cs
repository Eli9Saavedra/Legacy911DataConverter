using Legacy911DataConverter.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Legacy911DataConverter.Infrastructure.Data.Configuration
{
    public class ConversionErrorConfiguration : IEntityTypeConfiguration<ConversionError>
    {
        public void Configure(EntityTypeBuilder<ConversionError> builder)
        {
            builder.ToTable("ConversionErrors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BatchId)
                   .IsRequired();

            builder.Property(x => x.RowNumber)
                   .IsRequired();

            builder.Property(x => x.IncidentNumber)
                   .HasMaxLength(50);

            builder.Property(x => x.Field)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Message)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.HasIndex(x => x.BatchId);

            builder.HasOne<ConversionBatch>()
                   .WithMany()
                   .HasForeignKey(x => x.BatchId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
