using Szalag_Lib;

#region 1.feladat
var boxes = new Boxes(File.ReadLines("szallit.txt"));
#endregion

#region 2.feladat
Console.WriteLine("2. feladat");
Console.Write("Adja meg, melyik adatsorra kíváncsi! ");
int number = int.Parse(Console.ReadLine() ?? "");

var box = boxes.GetByNumber(number);
Console.WriteLine($"Honnan: {box.StartPoint} Hova: {box.EndPoint}");
#endregion

#region 3.feladat
Console.WriteLine("\n3. feladat");
Console.WriteLine($"A legnagyobb távolság: {boxes.MaxDistance}");
Console.WriteLine("A legnagyobb távolságú szállítások: " +
    string.Join(" ", boxes.IdsByTravelDistance(boxes.MaxDistance)));
#endregion

#region 4.feladat
Console.WriteLine("\n4. feladat");
Console.WriteLine("A kezdőpont előtt elhaladó rekeszek össztömege: " +
    boxes.WeightOfPassingStartPoint);
#endregion

#region 5.feladat
Console.WriteLine("\n5. feladat");
Console.Write("Adja meg a kívánt időpontot! ");
int time = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine($"A szállított rekeszek halmaza: " +
    string.Join(" ", boxes.BeingTransportedAt(time)));
#endregion

#region 6.feladat
await File.WriteAllLinesAsync("tomeg.txt",
    boxes.Weights.Select(weight => $"{weight.Item1} {weight.Item2}"));
#endregion
