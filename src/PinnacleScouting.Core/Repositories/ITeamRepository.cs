using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PinnacleScouting.Core.Models;

namespace PinnacleScouting.Core.Repositories;

public interface ITeamRepository
{
    Task<IReadOnlyList<Team>> GetTeamsAsync(CancellationToken cancellationToken = default);
    Task UpsertTeamsAsync(IEnumerable<Team> teams, CancellationToken cancellationToken = default);
}
