using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PinnacleScouting.Core.Models;

namespace PinnacleScouting.Core.Services.Scraping;

public interface IScoutingScraper
{
    Task<IReadOnlyList<Team>> ScrapeEventAsync(string eventCode, CancellationToken cancellationToken = default);
}
