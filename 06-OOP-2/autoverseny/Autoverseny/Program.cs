using Autoverseny_Lib;

Race? race = null;

while (race is null)
{
    Console.Clear();
    Console.Write("Enter a file name: ");
    string fileName = Console.ReadLine() ?? "";

    try
    {
        race = new Race(await File.ReadAllTextAsync(fileName));
    }
    catch
    {
        Console.WriteLine("Invalid file.");
    }
}

while (race.CurrentLap < race.Laps)
{
    Console.Clear();
    Console.WriteLine(race);
    Console.ReadKey();
    race.Next();
}

Console.Clear();
Console.WriteLine(race.Result);
