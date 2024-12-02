using Jatekgyar_Lib;

await File.WriteAllTextAsync("hibalista.txt", string.Empty);

var gyartasAdatok = new GyartasAdatok(File.ReadLines("gyartas.txt").Skip(1));

Console.WriteLine("Elérhető gyártás azonosítók: " +
    string.Join("; ", gyartasAdatok.ElerhetoGyartasAzonositok));

var jatekok = new Jatekok(File.ReadLines("ajandekok.txt").Skip(1), gyartasAdatok);

Console.WriteLine("\nA gyártott játékok: " +
    string.Join(", ", jatekok.JatekTipusok.Select(x => x.Megnevezes)));

var feladatok = new Feladatok();

foreach (string line in File.ReadLines("feladatok.txt").Skip(1))
{
    string[] parts = line.Split(';');

    string azonosito = parts[0];
    int darab = int.Parse(parts[1]);

    Jatek? jatek = null;

    try
    {
        jatek = jatekok[azonosito];
        feladatok += new Feladat(jatek, darab);
    }
    catch (Exception e)
    {
        using var output = new StreamWriter("hibalista.txt", true);

        await output.WriteLineAsync(jatek is null
            ? $"{azonosito}: {e.Message}"
            : $"{e.Message} - {darab} db {jatek.Megnevezes}: {jatek.ElkeszitesiIdo * darab} perc");
    }
}

Console.WriteLine("\nAz elvégzendő feladatok:");
Console.WriteLine(feladatok);

Console.WriteLine("\nJátékonként a készítendő darabszámok");
Console.WriteLine($"\t{string.Join("\n\t",
    feladatok.DarabSzamok.Select(x => $"{x.Key}: {x.Value} db"))}");
