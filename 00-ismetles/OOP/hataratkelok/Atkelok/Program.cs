using Atkelok_Lib;

#region 1.feladat
var borderCrossings = new BorderCrossings(File.ReadLines("hataratkelok.csv"));

Console.WriteLine("1. feladat:");
Console.WriteLine($"A fájl adatainak száma: {borderCrossings.Count}");
#endregion

#region 2.feladat
Console.WriteLine("\n2. feladat:");
Console.WriteLine($"A vasúti átkelők száma: {borderCrossings.CountByType("vasúti")}");
#endregion

#region 3.feladat
Console.WriteLine("\n3. feladat:");
Console.WriteLine(string.Join("\n",
    borderCrossings.FilterBySettlementType("megyei jogú város").Select(x => x.InfoWithoutCountry)));
#endregion

#region 4.feladat
Console.WriteLine("\n4. feladat:");
Console.WriteLine("Az Ausztriába vezető városi határátkelőhelyek száma: " +
    borderCrossings.CountCitiesTo("Ausztria"));
#endregion

#region 5.feladat
Console.WriteLine("\n5. feladat:");
Console.WriteLine("Ábécérendben az első olyan település, amelyikből határátkelő vezet Ausztriába: " +
    borderCrossings.FirstCrossingTo("Ausztria"));
#endregion

#region 6.feladat
Console.WriteLine("\n6. feladat:");
Console.WriteLine("Magyarországgal szomszédos országok: " +
    string.Join(", ", borderCrossings.BorderingCountries));
#endregion

#region 7.feladat
Console.WriteLine("\n7. feladat:");
Console.WriteLine("Közúti és vasúti határátkelővel is rendelkező városok: " +
    string.Join(", ", borderCrossings.CitiesWithRailwayAndRoadCrossing));
#endregion

#region 8.feladat
Console.WriteLine("\n8. feladat:");
Console.WriteLine(string.Join("\n",
    borderCrossings.CountriesWithCount.Select(x => $"{x.Item1}: {x.Item2} határátkelő.")));
#endregion

#region 9. feladat
Console.WriteLine("\n9. feladat:");
Console.WriteLine("Vas:\n" + string.Join("\n", borderCrossings.FilterByCounty("Vas")));
Console.WriteLine("\nZala:\n" + string.Join("\n", borderCrossings.FilterByCounty("Zala")));
#endregion
