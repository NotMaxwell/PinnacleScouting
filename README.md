# FRC_Team_Scouting_Software
This program will let you scan websites like blue alliance to quickly gather scoring information about teams in your qualifier. It should select teams based off of reginal and be able to filter to selected teams, compile their data and rank the teams based off of different available metrics.

## Project layout (work here)
- Solution: `PinnacleScouting.sln`
- UI: `src/PinnacleScouting.App/` (Avalonia desktop app; views/viewmodels go here)
- Core logic: `src/PinnacleScouting.Core/`
	- Models: `Models/` (e.g., `Team` data shape)
	- Services: `Services/` (non-UI logic)
	- Scraping: `Services/Scraping/` (`IScoutingScraper` interface; implement site-specific scrapers here)

## Where to add things
- Web scraping (e.g., Blue Alliance): add an implementation of `IScoutingScraper` under `src/PinnacleScouting.Core/Services/Scraping/` and keep HTTP/parsing code there.
- Team/domain models: add or extend classes under `src/PinnacleScouting.Core/Models/`.
- Aggregation/business logic: add services in `src/PinnacleScouting.Core/Services/` (e.g., ranking, filtering, caching).
- UI interactions: in the Avalonia app (`src/PinnacleScouting.App`), consume `ScoutingService` and bind results to viewmodels/views.

## Getting started
```
dotnet restore
dotnet run --project src/PinnacleScouting.App
```
