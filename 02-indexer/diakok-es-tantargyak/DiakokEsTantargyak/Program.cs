using DiakokEsTantargyak_Lib;

var school = new School();

school.AddSubject(new Subject("MAT", "Matematika"));
school.AddSubject(new Subject("INF", "Informatika"));

Console.WriteLine($"Azonosító: {school["Matematika"].Id}\nNév: {school["Matematika"].Name}\n");

school.AddStudent(new Student(1, "Kovács Béla"));
school.AddStudent(new Student(2, "Nagy János"));

Console.WriteLine(school[1].Name);
Console.WriteLine(school[2].Name);

school[1].AddSubject(school["Matematika"]);
school[1].AddGrade(school["Matematika"], 5);
school[1].AddGrade(school["Matematika"], 4);

school[1].AddSubject(school["Informatika"]);
school[1].AddGrade(school["Informatika"], 4);
school[1].AddGrade(school["Informatika"], 5);


school[2].AddSubject(school["Matematika"]);
school[2].AddGrade(school["Matematika"], 4);
school[2].AddGrade(school["Matematika"], 3);


school[2].AddSubject(school["Informatika"]);
school[2].AddGrade(school["Informatika"], 3);
school[2].AddGrade(school["Informatika"], 2);

Console.WriteLine($"\n{school[2].Name} jegyei:");
foreach (var (subject, grades) in school[2].Grades)
{
    Console.WriteLine($"{subject.Name}: {string.Join(", ", grades)}");
}

Console.WriteLine();

try
{
    var _ = school[3];
}
catch (KeyNotFoundException err)
{
    Console.WriteLine(err.Message);
}

try
{
    var _ = school["Fizika"];
}
catch (KeyNotFoundException err)
{
    Console.WriteLine(err.Message);
}
