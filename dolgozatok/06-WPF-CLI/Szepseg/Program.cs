using SzepsegLib;

DataStore.Initialize();
if (DataStore.Instance is null) return;

Console.WriteLine("5. feladat: " +
    DataStore.Instance.Procedures.Count(x => x.Time < new TimeOnly(12, 00)) +
    " kezelés esett délelőttre");

Console.Write("6. feladat: A vendég neve: ");

string name = Console.ReadLine() ?? "";
var guest = DataStore.Instance.Guests.FirstOrDefault(x => x.Name == name);

if (guest is null)
    Console.WriteLine("\tIlyen néven nem található vendég");
else
    Console.WriteLine($"\tCím: {guest.Address}\n\tTelefon: {guest.PhoneNumber}");

var topThreeEarners = DataStore
    .Instance
    .Workers
    .OrderByDescending(x => x.Earnings)
    .ThenBy(x => x.Name)
    .Take(3);
Console.WriteLine("7. feladat: A 3 legmagasabb bevételű alkalmazott:\n\t" +
    string.Join("\n\t", topThreeEarners));
