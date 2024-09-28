#region 1.feladat
string[] lines = await File.ReadAllLinesAsync("terkep.txt");
string[] size = lines[0].Split();
int[,] values = new int[int.Parse(size[0]), int.Parse(size[1])];

for (int i = 1; i < lines.Length; i++)
{
    string[] line = lines[i].Split('\t');

    for (int j = 0; j < line.Length; j++)
    {
        values[i - 1, j] = int.Parse(line[j]);
    }
}
#endregion

#region 2.feladat
Console.WriteLine("2. feladat");

Console.Write("A mérés sorának azonosítója: ");
int y = int.Parse(Console.ReadLine() ?? "");

Console.Write("A mérés oszlopának azonosítója: ");
int x = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine($"Az adott helyen {values[y - 1, x - 1]} a mért fényesség értéke.");
#endregion

#region 3.feladat
Console.WriteLine("3. feladat");

double zeroCount = 0;
foreach (int item in values)
{
    if (item == 0) zeroCount++;
}

Console.WriteLine($"A terület {zeroCount / values.Length:P1}-a teljesen sötét.");
#endregion

#region 4.feladat
Console.WriteLine("4. feladat");

int max = 0;
foreach (int item in values)
{
    if (item > max) max = item;
}

Console.WriteLine($"A legnagyobb fényességérték: {max}");

Console.WriteLine("A legfényesebb helyek koordinátái:");

for (int i = 0; i < values.GetLength(0); i++)
{
    for (int j = 0; j < values.GetLength(1); j++)
    {
        if (values[i, j] == max) Console.Write($"({i + 1}, {j + 1}) ");
    }
}
#endregion

#region 5.feladat
Console.WriteLine("\n5. feladat");

List<(int X, int Y)> bright = [];

for (int i = 0; i < values.GetLength(0); i++)
{
    for (int j = 0; j < values.GetLength(1); j++)
    {
        int value = values[i, j];
        if (value == 0) continue;

        if ((i > 0 && values[i - 1, j] < value)
            && (j > 0 && values[i, j - 1] < value)
            && (j < values.GetLength(1) - 1 && values[i, j + 1] < value)
            && (i < values.GetLength(0) - 1 && values[i + 1, j] < value))
        {
            bright.Add((j, i));
        }
    }
}

Console.WriteLine($"A fényes területek száma: {bright.Count}");
#endregion

#region 6.feladat
Console.WriteLine("6. feladat");

Console.WriteLine("A legkisebb téglalap, amely az összes fényes pontot tartalmazza:");
Console.WriteLine($"bal-felső: ({bright.Min(x => x.Y) + 1}, {bright.Min(x => x.X) + 1}), " +
    $"jobb-alsó: ({bright.Max(x => x.Y) + 1}, {bright.Max(x => x.X) + 1})");
#endregion

#region 7.feladat
Console.WriteLine("7. feladat");

Console.Write("A vizsgált oszlop száma: ");
int column = int.Parse(Console.ReadLine() ?? "");

List<string> toWrite = [];

for (int i = 0; i < values.GetLength(0); i++)
{
    toWrite.Add(new string('*', (int)Math.Round(values[i, column - 1] / 10.0)));
}

await File.WriteAllLinesAsync("diagram.txt", toWrite);
#endregion
