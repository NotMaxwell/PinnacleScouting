using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PinnacleScouting.Core.Models;
using PinnacleScouting.Core.Repositories;
using PinnacleScouting.Core.Services.Scraping;

namespace PinnacleScouting.Core.Services;

public sealed class ScoutingService
{
    private readonly IScoutingScraper _scraper;
    private readonly ITeamRepository _teams;

    public ScoutingService(IScoutingScraper scraper, ITeamRepository teams)
    {
        _scraper = scraper;
        _teams = teams;
    }

    public Task<IReadOnlyList<Team>> GetTeamsAsync(string eventCode, CancellationToken cancellationToken = default)
    {
        return _teams.GetTeamsAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Team>> RefreshTeamsAsync(string eventCode, CancellationToken cancellationToken = default)
    {
        var scraped = await _scraper.ScrapeEventAsync(eventCode, cancellationToken);
        await _teams.UpsertTeamsAsync(scraped, cancellationToken);
        return scraped;
    }
}
