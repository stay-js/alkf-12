using Kifizet_Lib;

#region 1. feladat
var payouts = new Payouts(File.ReadLines("lista.csv"));
#endregion

#region 3. feladat
Console.WriteLine("3. feladat:");
foreach (var payout in payouts.ActualPayouts)
{
    Console.WriteLine($"\t{payout.Name} havi fizetése: {payout.Amount} Ft.");
}
#endregion

#region 5. feladat
Console.WriteLine("\n5. feladat:");
Console.WriteLine("A dolgozók kifizetéséhet a következő címletekre van szükség:");
foreach (var item in payouts.ChangeRequired)
{
    Console.WriteLine($"\t{item.Value} db {item.Key} Ft-os");
}
#endregion

#region 6. feladat
await File.WriteAllLinesAsync("listaki.csv",
    payouts.ActualPayoutsWithMonogram.Select(x => $"{x.Key};{x.Value}"));
#endregion

#region *. feladat
Console.WriteLine("\n*. feladat:");
Console.Write("Adjon meg egy nevet: ");
string name = Console.ReadLine() ?? "";

try
{
    int amount = payouts[name];

    Console.WriteLine($"A megadott dolgozó havi keresete: {amount} Ft, " +
        $"fizetése: {Payouts.RoundToNearestHundred(amount)} Ft.");

    Console.WriteLine("Kifizetéséhez a következő címletekre van szükség:");
    foreach (var item in Payouts.Change(amount))
    {
        Console.WriteLine($"\t{item.Value} db {item.Key} Ft-os");
    }
}
catch (KeyNotFoundException err)
{
    Console.WriteLine(err.Message);
}
#endregion
