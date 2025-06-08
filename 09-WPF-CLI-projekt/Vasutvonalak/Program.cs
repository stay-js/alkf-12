using VasutvonalakLib;

DataStore.Initialize();
if (DataStore.Instance is null) return;

Console.WriteLine($"Magyarországon {DataStore.Instance.Lines.Count()} " +
    $"vasútvonal található.");

var lightRailwayLines = DataStore.Instance.Lines.Where(x => x.LightRailway);
Console.WriteLine($"\t- {lightRailwayLines.Count()} kisvasút " +
    $"({lightRailwayLines.Count(x => x.Active)} aktív)");

var railwayLines = DataStore.Instance.Lines.Where(x => !x.LightRailway);
Console.WriteLine($"\t- {railwayLines.Count()} vasútvonal " +
    $"({railwayLines.Count(x => x.Active)} aktív)");

var maxDistanceLocation = DataStore.Instance.Locations.MaxBy(x => x.Distance);
Console.WriteLine($"A leghoszzabb vasútvonal: {maxDistanceLocation?.LineId} " +
    $"({maxDistanceLocation?.Distance} km)");

int totalDistance = DataStore
    .Instance
    .Locations
    .GroupBy(x => x.LineId)
    .Select(g => g.Max(x => x.Distance))
    .Sum();

Console.WriteLine($"A teljes vasúthálózat hossza: {totalDistance:N0} km");

Console.Write("Adja meg egy állomás nevét: ");
string stationName = Console.ReadLine() ?? string.Empty;

var station = DataStore
    .Instance
    .Stations
    .FirstOrDefault(x => x.Name.Equals(stationName, StringComparison.CurrentCultureIgnoreCase));

if (station is null)
{
    Console.WriteLine("\tA megadott állomás nem található.");
}
else
{
    var lineIds = DataStore
        .Instance
        .Locations
        .Where(x => x.StationId == station.Id)
        .Select(x => x.LineId);

    Console.WriteLine($"\tAz alábbi vasútvonalak érintik a megadott állomást:\n\t\t- " +
        string.Join("\n\t\t- ", lineIds));
}

Console.Write("Adja meg egy vasútvonal azonosítóját: ");
string lineId = Console.ReadLine() ?? string.Empty;

var line = DataStore
    .Instance
    .Lines
    .FirstOrDefault(x => x.Id.Equals(lineId, StringComparison.CurrentCultureIgnoreCase));

if (line is null)
{
    Console.WriteLine("\tA megadott vasútvonal nem található.");
}
else
{
    Console.WriteLine($"\tA megadott vasútvonal: {line}" +
        $"\n\tHossza: {line.GetLength()} km" +
        $"\n\tVan külföldi állomása: " +
        (line.ContactsForeignStations ? "Igen" : "Nem"));
}
