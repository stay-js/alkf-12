using Sikolcsonzo_Lib;
using System.Globalization;

await File.WriteAllTextAsync("hibalista.txt", string.Empty);

var kolcsonzesek = new Kolcsonzesek(File.ReadLines("sporteszkozok.txt").Skip(1));

Console.WriteLine("A kölcsönözhető sporteszközök:");
Console.WriteLine($"\t{string.Join("\n\t", kolcsonzesek.KolcsonozhetoEszkozok)}");

var errorList = new List<string>();
var berlesek = ReadBerlesek();
var kolcsonzesekErrorList = kolcsonzesek.SporteszkozBerles(berlesek);

errorList.AddRange(kolcsonzesekErrorList);

await File.WriteAllLinesAsync("hibalista.txt", errorList);

Console.WriteLine("\nA sporteszközök sikeres foglalasai:");
Console.WriteLine(kolcsonzesek);

Console.Write("\nAdd meg egy kölcsönzés első napját! (pl: 2025.01.13) ");
var kezdoDatum = DateOnly.Parse(Console.ReadLine() ?? "", new CultureInfo("hu-HU"));

Console.Write("Add meg, hány napig kölcsönöznél sílécet vagy snowboardot! ");
int napokSzama = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine("\nA megadott időszakban kölcsönözhető sporteszközök:");
Console.WriteLine($"\t{string.Join("\n\t",
    kolcsonzesek.SzabadSporteszkozok(kezdoDatum, napokSzama)
    .Select(x => $"{x.Azonosito} {x.Leiras}, {x.Meret} cm"))}");

IEnumerable<Berles> ReadBerlesek()
{
    var berlesek = new List<Berles>();

    foreach (string line in File.ReadLines("foglalasok.txt").Skip(1))
    {
        string[] parts = line.Split(';');

        try
        {
            berlesek.Add(new Berles(
                parts[2],
                DateOnly.Parse(parts[0], new CultureInfo("hu-HU")),
                int.Parse(parts[1]),
                parts[3])
                );
        }
        catch (HibasDatumException e)
        {
            errorList.Add($"{e.Message} - {line}");
        }
    }

    return berlesek;
}
