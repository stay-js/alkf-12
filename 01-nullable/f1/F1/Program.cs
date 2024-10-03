using F1_Lib;

#region 1. feladat
var results = new Results(File.ReadLines("eredmenyek.csv"));
#endregion

#region 2. feladat
Console.WriteLine("2. feladat: Hill vezetéknevűek: ");
foreach (var result in results.FilterByLastName("Hill"))
{
    Console.WriteLine($"\t{result.Name} ({result.Nationality}) {result.Birth}");
}
#endregion

#region 3. feladat
Console.WriteLine("3. feladat: futamgyőztesek:\n\t" +
    string.Join("\n\t", results.Winners));
#endregion

#region 4. feladat
Console.WriteLine("4. feladat: Juan-Manuel Fangio " +
    $"{results.AgeAtFirstRace("Juan-Manuel Fangio")} éves volt az első versenyén");
#endregion

#region 5. feladat
Console.WriteLine("5. feladat: Ferrariknál a 3 leggyakoribb hiba:");
foreach (var (error, count) in results.TopErrorsByCarType(3, "Ferrari"))
{
    Console.WriteLine($"\t{error}: {count} eset");
}
#endregion

#region 6. feladat
Console.WriteLine($"6. feladat: {results.CountDriversWithoutATeam} olyan versenyző volt," +
    " akinek valamelyik versenyén nem volt csapata");
#endregion

#region 7. feladat
// Nincs magyarországi futam az adatokban...
Console.WriteLine($"7. feladat: Magyarország után rendezték az első nagydíjukat: " +
    string.Join(", ", results.DebuedAfter("Magyarország")));
#endregion

#region 8. feladat
var toWrite = new List<string>();

foreach (var (year, res) in results.TopDrivers(6, "Monaco"))
{
    toWrite.Add(year.ToString());

    foreach (var result in res)
    {
        toWrite.Add($"{result.Place}. {result.Name}" +
            (result.Team is not null ? $" ({result.Team})" : ""));
    }

    toWrite.Add("");
}

await File.WriteAllLinesAsync("monaco.txt", toWrite);
#endregion
