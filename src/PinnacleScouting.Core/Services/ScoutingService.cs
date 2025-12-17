using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PinnacleScouting.Core.Models;
using PinnacleScouting.Core.Services.Scraping;

namespace PinnacleScouting.Core.Services;

public sealed class ScoutingService
{
    private readonly IScoutingScraper _scraper;

    public ScoutingService(IScoutingScraper scraper)
    {
        _scraper = scraper;
    }

    public Task<IReadOnlyList<Team>> GetTeamsAsync(string eventCode, CancellationToken cancellationToken = default)
    {
        return _scraper.ScrapeEventAsync(eventCode, cancellationToken);
    }
}
