using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Legacy911DataConverter.Core.Entities;

namespace Legacy911DataConverter.Infrastructure.Data.Configuration;

public class ConversionBatchConfiguration : IEntityTypeConfiguration<ConversionBatch>
{
    public void Configure(EntityTypeBuilder<ConversionBatch> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("ConversionBatches");
        builder.Property(x => x.ImportedAtUtc).IsRequired();
        builder.Property(x => x.SourceType).IsRequired().HasMaxLength(20);
        builder.Property(x => x.TotalRecords).IsRequired();
        builder.Property(x => x.SuccessfulRecords).IsRequired();
        builder.Property(x => x.FailedRecords).IsRequired();
    }
}
