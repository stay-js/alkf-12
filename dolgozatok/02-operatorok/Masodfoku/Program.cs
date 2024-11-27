using Masodfoku_Lib;

double a, b, c;

Console.WriteLine("Adja meg az egyik kifejezés együtthatóit:");

Console.Write("a = ");
a = double.Parse(Console.ReadLine() ?? "");

Console.Write("b = ");
b = double.Parse(Console.ReadLine() ?? "");

Console.Write("c = ");
c = double.Parse(Console.ReadLine() ?? "");

var first = new MasodfokuKifejezes(a, b, c);

Console.WriteLine("\n\nAdja meg az másik kifejezés együtthatóit:");

Console.Write("a = ");
a = double.Parse(Console.ReadLine() ?? "");

Console.Write("b = ");
b = double.Parse(Console.ReadLine() ?? "");

Console.Write("c = ");
c = double.Parse(Console.ReadLine() ?? "");

var second = new MasodfokuKifejezes(a, b, c);

Console.WriteLine($"\nAz első kifejezés ({first}) diszkriminánsa: {first.Discriminant}");
Console.WriteLine($"A második kifejezés ({second}) diszkriminánsa: {second.Discriminant}");

Console.WriteLine($"\nA két kifejezés összege: {first + second}");
Console.WriteLine($"A két kifejezés különbsége: {first - second}");

Console.WriteLine($"A két kifejezés {(first != second ? "nem " : "")}egyenlő.");
