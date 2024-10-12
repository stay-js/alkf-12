namespace DiakokEsTantargyak_Lib
{
    public class Student(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public Dictionary<Subject, List<int>> Grades { get; set; } = [];

        public void AddSubject(Subject subject) => Grades.Add(subject, []);

        public void AddGrade(Subject subject, int grade)
        {
            if (Grades.TryGetValue(subject, out var value)) value.Add(grade);
            else Grades[subject] = [grade];
        }
    }
}
