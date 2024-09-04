using Hataratkelok_Lib;

#region 1.feladat
var hataratkelok = new Hataratkelok(File.ReadLines("hataratkelok.csv"));

Console.WriteLine("1. feladat:");
Console.WriteLine($"A fájl adatainak száma: {hataratkelok.Count}");
#endregion

#region 2.feladat
Console.WriteLine("\n2. feladat:");
Console.WriteLine($"A vasúti átkelők száma: {hataratkelok.CountRailwayCrossings}");
#endregion

#region 3.feladat
Console.WriteLine("\n3. feladat:");
Console.WriteLine(string.Join("\n",
    hataratkelok.CitiesWithCountryRights.Select(x => x.InfoWithoutCountry)));
#endregion

#region 4.feladat
Console.WriteLine("\n4. feladat:");
Console.WriteLine("Az Ausztriába vezető városi határátkelőhelyek száma: " +
    hataratkelok.CountCitiesTo("Ausztria"));
#endregion

#region 5.feladat
Console.WriteLine("\n5. feladat:");
Console.WriteLine("Ábécérendben az első olyan település, amelyikből határátkelő vezet Ausztriába: " +
    hataratkelok.FirstCrossingTo("Ausztria"));
#endregion

#region 6.feladat
Console.WriteLine("\n6. feladat:");
Console.WriteLine("Magyarországgal szomszédos országok: " +
    string.Join(", ", hataratkelok.BorderingCountries));
#endregion

#region 7.feladat
Console.WriteLine("\n7. feladat:");
Console.WriteLine("Közúti és vasúti határátkelővel is rendelkező városok: " +
    string.Join(", ", hataratkelok.CitiesWithRailwayAndRoadCrossing));
#endregion

#region 8.feladat
Console.WriteLine("\n8. feladat:");
Console.WriteLine(string.Join("\n",
    hataratkelok.CountriesWithCount.Select(x => $"{x.Item1}: {x.Item2} határátkelő.")));
#endregion

#region 9. feladat
Console.WriteLine("\n9. feladat:");
Console.WriteLine("Vas:\n" + string.Join("\n", hataratkelok.FilterByCounty("Vas")));
Console.WriteLine("\nZala:\n" + string.Join("\n", hataratkelok.FilterByCounty("Zala")));
#endregion
