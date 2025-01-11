using Autoverseny_Lib;

Console.Write("Adja meg a fájl nevét: ");
string fileName = Console.ReadLine() ?? "";

var race = new Race(await File.ReadAllTextAsync(fileName));

while (race.CurrentLap < race.Laps)
{
    Console.Clear();
    Console.WriteLine(race);
    Console.ReadLine();
    race.Next();
}

Console.Clear();
Console.WriteLine(race);
Console.WriteLine($"\n\nPodium:\n\t- {string.Join("\n\t- ", race.Drivers.Take(3))}");
