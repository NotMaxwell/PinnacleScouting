using System.Collections.Generic;

namespace PinnacleScouting.Core.Models;

public sealed class Team
{
    public int TeamNumber { get; set; }
    public string? Name { get; set; }
    public string? Region { get; set; }

    // Use this to store per-metric scores (e.g., autonomous points, endgame points).
    public Dictionary<string, double> Metrics { get; } = new();
}
