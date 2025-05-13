using ForditoIrodaLib;

DataStore.Initialize();
if (DataStore.Instance is null) return;

Console.WriteLine($"5. feladat: {DataStore
    .Instance
    .Orders
    .Count(x => x.Date >= new DateOnly(2015, 03, 01) && x.Date <= new DateOnly(2015, 03, 31))} " +
    $"fordítási feladatot rendeltek 2015. márciusában.");

Console.Write("6. feladat: A fordító neve: ");

string name = Console.ReadLine() ?? string.Empty;
var translator = DataStore
    .Instance
    .Translators
    .FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

if (translator is null)
    Console.WriteLine("\tIlyen néven nem található fordító.");
else
    Console.WriteLine($"\tTelefon: {translator.PhoneNumber}\n\tEmail: {translator.Email}");

Console.WriteLine("7. feladat: A 3 legtöbb megrendelést kapó fordító:");
var topThreeTranslators = DataStore
    .Instance
    .Translators
    .OrderByDescending(x => x.OrderCount)
    .Take(3)
    .Select(x => $"\t{x}: {x.OrderCount} alkalom");
Console.WriteLine(string.Join('\n', topThreeTranslators));

Console.WriteLine("8. feladat: A 3 legtöbb pénzt kereső fordító:");
var topThreeEarningTranslators = DataStore
    .Instance
    .Translators
    .OrderByDescending(x => x.Earnings)
    .Take(3)
    .Select(x => $"\t{x}: {x.Earnings:C0}");
Console.WriteLine(string.Join('\n', topThreeEarningTranslators));
