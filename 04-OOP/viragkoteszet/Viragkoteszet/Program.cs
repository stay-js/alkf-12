using Viragkoteszet_Lib;

var katalogus = new Katalogus(File.ReadLines("alapanyagok.txt").Skip(1));
var termekek = new Termekek(File.ReadLines("termekek.txt").Skip(1), katalogus);

Console.WriteLine("Elkészíthető termékek:");
Console.WriteLine(termekek);

var dolgozok = new Dolgozok(MunkaeroFelvetel.Felvetel(File.ReadLines("dolgozok.txt").Skip(1)));

var errorList = FeladatKiosztas.Kioszt(
    File.ReadLines("feladatkiosztas.txt").Skip(1),
    termekek,
    dolgozok
    );

await File.WriteAllLinesAsync("hibalista.txt", errorList);

Console.WriteLine($"\nDolgozók ({dolgozok.DolgozokSzama}):");
Console.WriteLine(dolgozok);