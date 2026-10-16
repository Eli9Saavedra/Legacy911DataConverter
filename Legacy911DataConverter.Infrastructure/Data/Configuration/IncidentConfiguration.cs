using Legacy911DataConverter.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Legacy911DataConverter.Infrastructure.Data.Configuration
{
    /// <summary>
    /// EF Core mapping for the Incident entity.
    /// This class translates C# entity rules into SQL schema constraints.
    /// </summary>
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            // Map this entity to the exact SQL table name from database-design.md.
            builder.ToTable("Incidents");

            // Primary key (surrogate identity key in SQL Server).
            builder.HasKey(x => x.Id);

            // IncidentNumber = business identifier:
            // - required (NOT NULL)
            // - max length 50 (nvarchar(50))
            builder.Property(x => x.IncidentNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            // Unique index prevents duplicate incident numbers across rows.
            builder.HasIndex(x => x.IncidentNumber)
                   .IsUnique();

            // CallType:
            // - required
            // - max length 100 (nvarchar(100))
            builder.Property(x => x.CallType)
                   .IsRequired()
                   .HasMaxLength(100);

            // OccurredAtUtc:
            // - required normalized UTC timestamp (datetime2)
            builder.Property(x => x.OccurredAtUtc)
                   .IsRequired();

            // Status:
            // - required
            // - max length 20 (nvarchar(20))
            builder.Property(x => x.Status)
                   .IsRequired()
                   .HasMaxLength(20);

            // Location:
            // - required
            // - max length 200 (nvarchar(200))
            // - database default used when source value is missing
            builder.Property(x => x.Location)
                   .IsRequired()
                   .HasMaxLength(200)
                   .HasDefaultValue("Unknown");

            // Priority:
            // - required
            // - max length 30 (nvarchar(30))
            // - database default used when source value is missing
            builder.Property(x => x.Priority)
                   .IsRequired()
                   .HasMaxLength(30)
                   .HasDefaultValue("Unspecified");

            // BatchId foreign key:
            // - required so every incident is traceable to an import batch
            builder.Property(x => x.BatchId)
                   .IsRequired();

            // Non-unique index improves performance for batch-based lookups/reports.
            builder.HasIndex(x => x.BatchId);

            // Relationship:
            // Incident (many) -> ConversionBatch (one), linked by BatchId.
            // Restrict delete preserves auditability: batch cannot be deleted
            // if incidents still reference it.
            builder.HasOne<ConversionBatch>()
                   .WithMany()
                   .HasForeignKey(x => x.BatchId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
