using MagyarKiralyok_Lib;

#region 1. feladat
var kings = new Kings(File.ReadLines("uralkodo.csv"));
#endregion

#region 2. feladat
Console.WriteLine("2. feladat: A 14. században megkoronázott uralkodók:");
foreach (var king in kings.CrownedBetween(1301, 1400))
{
    Console.WriteLine($"\t{king.Name,-15}{king.BeginningOfReign}\t{king.EndOfReign}");
}
#endregion

#region 3. feladat
Console.WriteLine("3. feladat: Magyar királyok:");
foreach (var king in kings.DistinctKings)
{
    Console.WriteLine($"\t{king.FormattedName}\t{king.Birth}");
}
#endregion

#region 4. feladat
Console.WriteLine("4. feladat: Fiatal uralkodók:");
foreach (var king in kings.YoungKings)
{
    Console.WriteLine($"\t{king.Name,-15} " +
        (king.AgeAtBeginningOfReign == 0 ? "újszülött" : $"{king.AgeAtBeginningOfReign} éves"));
}
#endregion

#region 5. feladat
Console.WriteLine("5. feladat: Hosszú uralkodás:");
foreach (var king in kings.LongestReign(10))
{
    Console.WriteLine($"\t{king.FormattedName} {king.ReignTime} év");
}
#endregion

#region 6. feladat
Console.WriteLine("6. feladat: Uralkodó házak:");
foreach (var (name, count) in kings.Families)
{
    Console.WriteLine($"\t{name}\t{count} király");
}
#endregion

#region 7. feladat
Console.Write("7. feladat: Koronázás előtt már uralkodó:\n\t");
Console.Write(string.Join("\n\t", kings.RuledBeforeCrowning));
#endregion

#region 8. feladat
var toWrite = new List<string>();

foreach (var king in kings.HasNickname)
{
    toWrite.Add($"{king.FormattedName} {(king.CrownedAt is null ? "-" : king.CrownedAt)}");
}

await File.WriteAllLinesAsync("melleknev.txt", toWrite);
#endregion
