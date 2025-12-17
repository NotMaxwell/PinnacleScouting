using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PinnacleScouting.Core.Data;
using PinnacleScouting.Core.Models;

namespace PinnacleScouting.Core.Repositories;

public sealed class EfTeamRepository : ITeamRepository
{
    private readonly ScoutingDbContext _db;

    public EfTeamRepository(ScoutingDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<Team>> GetTeamsAsync(CancellationToken cancellationToken = default)
    {
        return await _db.Teams.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task UpsertTeamsAsync(IEnumerable<Team> teams, CancellationToken cancellationToken = default)
    {
        foreach (var team in teams)
        {
            var existing = await _db.Teams.FindAsync(new object[] { team.TeamNumber }, cancellationToken);
            if (existing is null)
            {
                _db.Teams.Add(team);
                continue;
            }

            _db.Entry(existing).CurrentValues.SetValues(team);

            // Replace metrics with incoming values.
            existing.Metrics.Clear();
            foreach (var kvp in team.Metrics)
            {
                existing.Metrics[kvp.Key] = kvp.Value;
            }
        }

        await _db.SaveChangesAsync(cancellationToken);
    }
}
