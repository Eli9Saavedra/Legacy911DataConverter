using Microsoft.EntityFrameworkCore;
using Legacy911DataConverter.Core.Entities;
using Legacy911DataConverter.Infrastructure.Data.Configuration;

namespace Legacy911DataConverter.Infrastructure.Data;

public class Legacy911DataConverterDbContext : DbContext
{
    public Legacy911DataConverterDbContext(DbContextOptions<Legacy911DataConverterDbContext> options) : base(options)
    {
        
    }

    public DbSet<ConversionBatch> ConversionBatches { get; set; }
    public DbSet<ConversionError> ConversionErrors  { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<RespondingUnit> RespondingUnits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ConversionBatchConfiguration());
        modelBuilder.ApplyConfiguration(new IncidentConfiguration());
        modelBuilder.ApplyConfiguration(new RespondingUnitConfiguration());
        modelBuilder.ApplyConfiguration(new ConversionErrorConfiguration());
    }
}
