using Statisztika_Lib;

#region 1.feladat
var rounds = new Rounds(File.ReadLines("dobasok.txt"));
#endregion

#region 2.feladat
Console.WriteLine("2. feladat");
Console.WriteLine($"Körök száma: {rounds.Count}");
#endregion

#region 3.feladat
Console.WriteLine("3. feladat");
Console.WriteLine($"3. dobásra Bullseye: {rounds.CountThrowsByTypeAndIndex("D25", 2)}");
#endregion

#region 4.feladat
Console.WriteLine("4. feladat");
Console.Write("Adja meg a szektor értékét! Szektor= ");
string sector = Console.ReadLine() ?? "";

var (player1, player2) = rounds.SectorCount(sector);

Console.WriteLine($"Az 1. játékos a(z) {sector} szektoros dobásainak száma: {player1}");
Console.WriteLine($"A 2. játékos a(z) {sector} szektoros dobásainak száma: {player2}");
#endregion

#region 5.feladat
Console.WriteLine("5. feladat");
var (player1_180, player2_180) = rounds.OneEightyCount;
Console.WriteLine($"Az 1. játékos {player1_180} db 180-ast dobott.");
Console.WriteLine($"A 2. játékos {player2_180} db 180-ast dobott.");
#endregion
