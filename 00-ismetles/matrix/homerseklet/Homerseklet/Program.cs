#region 1.feladat
string[] lines = await File.ReadAllLinesAsync("homerseklet.txt");
string[] size = lines[0].Split();
int[,] values = new int[int.Parse(size[0]), int.Parse(size[1])];

Console.WriteLine("1. feladat:");

Console.WriteLine($"{"",10}"
    + string.Concat(Enumerable.Range(1, values.GetLength(1)).Select(x => $"{$"{x}. mérés",15}")));

for (int i = 1; i < lines.Length; i++)
{
    Console.Write($"{$"{i}. nap:",-17}");

    string[] line = lines[i].Split();

    for (int j = 0; j < line.Length; j++)
    {
        values[i - 1, j] = int.Parse(line[j]);

        Console.Write($"{line[j],-15}");
    }

    Console.WriteLine();
}
#endregion

#region 1.feladat
double sum = 0;

foreach (int value in values)
{
    sum += value;
}

Console.WriteLine($"\n2. feladat: Az átlaghőmérséklet: {sum / values.Length:N2} fok");
#endregion


#region 3.feladat
Console.WriteLine("\n3. feladat: Az átlaghőmérséklet naponként:");

for (int i = 0; i < values.GetLength(0); i++)
{
    sum = 0;

    for (int j = 0; j < values.GetLength(1); j++)
    {
        sum += values[i, j];
    }

    Console.WriteLine($"\t{i + 1}. nap: {sum / values.GetLength(1):N2} fok");
}
#endregion

#region 4.feladat
int lessThan10 = 0;

foreach (int value in values)
{
    if (value < 10) lessThan10++;
}

Console.WriteLine($"\n4. feladat: {lessThan10} alkalommal volt 10 fok alatt a hőmérséklet");
#endregion

#region 5.feladat
int lessThan10Days = 0;

for (int i = 0; i < values.GetLength(0); i++)
{
    for (int j = 0; j < values.GetLength(1); j++)
    {
        if (values[i, j] < 10)
        {
            lessThan10Days++;
            break;
        }
    }
}

Console.WriteLine($"\n5. feladat: {lessThan10Days} nap volt 10 fok alatt a hőmérséklet");
#endregion

#region 6.feladat
(int X, int Y) max = (0, 0);

for (int i = 0; i < values.GetLength(0); i++)
{
    for (int j = 0; j < values.GetLength(1); j++)
    {
        if (values[i, j] > values[max.Y, max.X])
        {
            max = (j, i);
        }
    }
}

Console.WriteLine($"\n6. feladat: Az {max.Y + 1}. nap, {max.X + 1}. " +
    $"mérésekor volt a legmagasabb a hőmérséklet: {values[max.Y, max.X]} fok");
#endregion

#region 7. feladat
Console.Write("\n7. feladat: Keresett hőmérséklet érték: ");
int query = int.Parse(Console.ReadLine() ?? "");

for (int i = 0; i < values.GetLength(0); i++)
{
    for (int j = 0; j < values.GetLength(1); j++)
    {
        if (values[i, j] == query)
        {
            Console.WriteLine($"\tVolt ilyen mérérés: {i + 1}. nap {j + 1}. mérése");
            return;
        }
    }
}

Console.WriteLine("\tNem volt ilyen mérés");
#endregion
