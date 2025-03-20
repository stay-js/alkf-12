using TowersLib;

var solutions = new Solutions("megoldasok.txt");

Console.WriteLine($"5. feladat: A megoldást beküldők száma: {solutions.Count}");

Console.Write("8. feladat: A beküldő neve: ");
string name = Console.ReadLine() ?? "";
var solution = solutions.GetSolution(name);

if (solution is null)
{
    Console.WriteLine($"\t{name} néven nem küldetek be megoldást");
}
else if (!solution.IsValid)
{
    Console.WriteLine($"\t{name} néven beküldött megoldás helytelen");
}
else
{
    int[] left = solution.Left();
    int[] right = solution.Right();

    Console.WriteLine($"\t{name} megoldása:");

    Console.WriteLine($"\t\t{string.Join('\t', solution.Top())}");
    for (int i = 0; i < solution.Size; i++)
    {
        Console.WriteLine($"\t{left[i]}" +
            $"\t{string.Join('\t', solution.GetNumbersInRow(i))}" +
            $"\t{right[i]}");
    }
    Console.WriteLine($"\t\t{string.Join('\t', solution.Bottom())}");
}

Console.WriteLine("9. feladat: A feladványra helyes megoldást adtak: " +
    string.Join(", ", solutions.GaveCorrectSolution));
