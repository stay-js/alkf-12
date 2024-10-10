using DiakokEsTantargyak_Lib;

var school = new School();

school.AddSubject(new Subject("MAT", "Matematika"));
school.AddSubject(new Subject("INF", "Informatika"));

Console.WriteLine(school["Matematika"].Id);

school.AddStudent(new Student(1, "Kovács Béla"));
school.AddStudent(new Student(2, "Nagy János"));

Console.WriteLine(school[1].Name);

school[1].AddSubject(school["Matematika"].Id);
school[1].AddGrade(school["Matematika"].Id, 5);
school[1].AddGrade(school["Matematika"].Id, 4);

school[1].AddSubject(school["Informatika"].Id);
school[1].AddGrade(school["Informatika"].Id, 4);
school[1].AddGrade(school["Informatika"].Id, 5);


school[2].AddSubject(school["Matematika"].Id);
school[2].AddGrade(school["Matematika"].Id, 4);
school[2].AddGrade(school["Matematika"].Id, 3);


school[2].AddSubject(school["Informatika"].Id);
school[2].AddGrade(school["Informatika"].Id, 3);
school[2].AddGrade(school["Informatika"].Id, 2);

foreach (var (subjectId, grades) in school[2].Grades)
{
    Console.WriteLine($"{subjectId}: {string.Join(", ", grades)}");
}

try
{
    var _ = school[3];
}
catch (KeyNotFoundException e)
{
    Console.WriteLine(e.Message);
}

try
{
    var _ = school["Fizika"];
}
catch (KeyNotFoundException e)
{
    Console.WriteLine(e.Message);
}
