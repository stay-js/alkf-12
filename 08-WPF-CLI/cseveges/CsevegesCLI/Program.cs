using CsevegesLib;

string[] members = await File.ReadAllLinesAsync("../../../../tagok.txt");
var chats = new Chats(await File.ReadAllLinesAsync("../../../../csevegesek.txt"));

Console.WriteLine($"4. feladat: Tagok száma: {members.Length}fő - Beszélgetések: {chats.Count}db");

Console.WriteLine("5. feladat: Leghosszabb beszélgetés adatai" +
    $"\n\t{"Kezdeményező:",-15} {chats.Longest.Sender}" +
    $"\n\t{"Fogadó:",-15} {chats.Longest.Reciever}" +
    $"\n\t{"Kezdete:",-15} {Chat.FormatDate(chats.Longest.Start)}" +
    $"\n\t{"Vége:",-15} {Chat.FormatDate(chats.Longest.End)}" +
    $"\n\t{"Hossz:",-15} {chats.Longest.Duration.TotalSeconds}mp");

Console.Write("6. feladat: Adja meg egy tag nevét: ");
string name = Console.ReadLine() ?? "";
Console.WriteLine($"\tA beszélgetések összes ideje: {chats.TimeSpentChatting(name)}");

Console.WriteLine("7. feladat: Nem beszélgetett senkivel\n\t" +
    string.Join("\n\t", chats.DidntTalkToAnyone(members)));

var longestSilent = chats.LongestSilentPeriod();
Console.WriteLine("8. feldat: Leghosszabb csendes időszak 15h-tól" +
    $"\n\t{"Kezdete:",-10} {Chat.FormatDate(longestSilent.Start)}" +
    $"\n\t{"Vége:",-10} {Chat.FormatDate(longestSilent.End)}" +
    $"\n\t{"Hossza:",-10} {longestSilent.Duration}");
