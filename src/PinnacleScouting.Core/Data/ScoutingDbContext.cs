using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PinnacleScouting.Core.Models;

namespace PinnacleScouting.Core.Data;

public sealed class ScoutingDbContext : DbContext
{
    public DbSet<Team> Teams => Set<Team>();

    public ScoutingDbContext(DbContextOptions<ScoutingDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var metricsConverter = new ValueConverter<Dictionary<string, double>, string>(
            value => JsonSerializer.Serialize(value, (JsonSerializerOptions?)null),
            value => JsonSerializer.Deserialize<Dictionary<string, double>>(value, (JsonSerializerOptions?)null) ?? new Dictionary<string, double>());

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(t => t.TeamNumber);
            entity.Property(t => t.Name).HasMaxLength(200);
            entity.Property(t => t.Region).HasMaxLength(100);
            entity.Property(t => t.Metrics)
                  .HasConversion(metricsConverter)
                  .HasColumnType("TEXT");
        });
    }
}
