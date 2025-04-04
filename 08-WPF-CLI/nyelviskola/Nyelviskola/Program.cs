using Nyelviskola_Lib;

DataStore.Initialize();
if (DataStore.Instance is null) return;

DataStore.Instance.ExportAllToJson();

Console.WriteLine("6. feladat: " +
    DataStore.Instance.Lessons.Count(x => x.LessonIsInGivenMonth(2023, 04)) +
    " alkalmat jegyeztek fel 2023. áprilisában.");

Console.Write("7. feladat: A tanár neve: ");

string name = Console.ReadLine() ?? string.Empty;
var teacher = DataStore.Instance.Teachers
    .FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

if (teacher is null) Console.WriteLine("\tIlyen néven nem található tanár.");
else Console.WriteLine($"\tTelefont: {teacher.PhoneNumber}\n\tEmail: {teacher.Email}");

Console.WriteLine("8. feladat: A 3 legtöbb alkalmat tanító tanár:");
var topThreeTeachers = DataStore
    .Instance
    .Teachers
    .OrderByDescending(x => x.LessonCount)
    .Take(3)
    .Select(x => $"\t{x}: {x.LessonCount} alkalom");
Console.WriteLine(string.Join('\n', topThreeTeachers));

Console.WriteLine("9. feladat: A 3 legtöbb pénzt kereső tanár:");
var topThreeEarningTeachers = DataStore
    .Instance
    .Teachers
    .OrderByDescending(x => x.Earnings)
    .Take(3)
    .Select(x => $"\t{x}: {x.Earnings:C0}");
Console.WriteLine(string.Join('\n', topThreeEarningTeachers));
