using TesztKiertekeles_Lib;

#region 1.feladat
Console.WriteLine("1. feladat");
Console.Write("Adja meg a csoport azonosítóját: ");
string id = Console.ReadLine() ?? "";

Group? group = null;

try
{
    group = new Group(File.ReadLines($"csoport{id}.csv"));

    if (!group.HasWrittenTest)
    {
        Console.WriteLine("A megadott csoport még nem írta meg a tesztet.");
        return;
    }

    Console.WriteLine($"A csoportból {group.TookTheTest} tanuló írta meg a tesztet és" +
        $" {group.Absent} tanuló hiányzott.");
}
catch (FileNotFoundException)
{
    Console.WriteLine("A megadott csoport nem található.");
}

if (group is null) return;
#endregion

#region 2.feladat
Console.WriteLine("\n2. feladat");
Console.Write("Adja meg a tanuló nevét: ");
string name = Console.ReadLine() ?? "";

var result = group.GetResultByName(name);
Console.WriteLine(result is null ? "A megadott tanuló nem írta meg a tesztet." : result);
#endregion

#region 3. feladat
Console.WriteLine("\n3. feladat");
int i = 1;
foreach (var item in group.ScoresPerTask())
{
    Console.WriteLine($"{i++}. feladat: {item.Solutions} megoldás," +
        $" átlagos pontszám: {item.Avg:F2}, üresen beadva: {item.SubmittedEmpty}");
}
#endregion

#region 4. feladat
if (group.Results is not null) await File.WriteAllLinesAsync($"szazalek{id}.csv", group.Results);
#endregion
