using Autoverseny_Lib;

Console.Write("Enter the file name: ");
string fileName = Console.ReadLine() ?? "";

var race = new Race(await File.ReadAllTextAsync(fileName));

while (race.CurrentLap < race.Laps)
{
    Console.Clear();
    Console.WriteLine(race);
    Console.ReadKey();
    race.Next();
}

Console.Clear();
Console.WriteLine(race.Result);
