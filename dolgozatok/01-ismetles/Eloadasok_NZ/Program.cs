using Eloadasok_Lib;

#region 1.feladat
var performances = new Performances(File.ReadLines("jegyeladas.csv"));
#endregion

#region 2.feladat
Console.WriteLine("2. feladat");
Console.WriteLine($"\tElőadások száma az évadban: {performances.Count}");
#endregion

#region 3.feladat
var mostExpensive = performances.MostExpensive;

Console.WriteLine("3. feladat");
Console.WriteLine($"\tA legdrágább előadás: {mostExpensive?.Title}");
Console.WriteLine($"\tA jegy ára: {mostExpensive?.Category1Price} Ft");
#endregion

#region 4.feladat
var leastAvailableTickets = performances.LeastAvailableTickets;

Console.WriteLine("4. feladat");
if (leastAvailableTickets?.AvailableTickets == 0)
{
    Console.WriteLine($"\tVolt teltházas előadás: {leastAvailableTickets.Title}");
}
else
{
    Console.WriteLine($"\tA legnézettebb előadás: {leastAvailableTickets?.Title}" +
        $" üres helyek száma: {leastAvailableTickets?.AvailableTickets}");
}
#endregion

#region 5.feladat
Console.WriteLine("5. feladat");
foreach (var item in performances.OrderedByTicketsSold)
{
    Console.WriteLine($"\t{item.Title} - nézők száma: {item.TotalSold} fő - bevétel: {item.Income} Ft");
}
#endregion

#region 6.feladat
Console.WriteLine("6. feladat");
Console.WriteLine("\tDarabonkénti bevétel:");
foreach (var item in performances.IncomePerPerformance)
{
    Console.WriteLine($"\t{item.Item1} - {item.Item2} Ft");
}
#endregion

#region 7.feladat
await File.WriteAllLinesAsync("sokszor.txt", performances.PerformedMoreThanOnce);
#endregion

#region 8.feladat
Console.WriteLine("8. feladat");
Console.WriteLine("\tAz öt legolcsóbb előadás:");
foreach (var item in performances.CheapestByCategory2(5))
{
    Console.WriteLine($"\t{item.Title} - {item.Category2Price} Ft");
}
#endregion

#region 9.feladat
Console.WriteLine("9. feladat");
Console.WriteLine(string.Join(", ", performances.Titles));
#endregion
