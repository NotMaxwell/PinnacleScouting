using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PinnacleScouting.Core.Data;

// Design-time factory used by `dotnet ef` tooling.
public sealed class SqliteDbContextFactory : IDesignTimeDbContextFactory<ScoutingDbContext>
{
    public ScoutingDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ScoutingDbContext>();
        builder.UseSqlite("Data Source=scouting.db");
        return new ScoutingDbContext(builder.Options);
    }
}
