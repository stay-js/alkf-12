namespace DiakokEsTantargyak_Lib
{
    public class School
    {
        private readonly List<Student> students = [];
        private readonly List<Subject> subjects = [];

        public void AddStudent(Student student) => students.Add(student);
        public void AddSubject(Subject subject) => subjects.Add(subject);

        public Student this[int id]
        {
            get
            {
                var student = students.Find(x => x.Id == id);

                if (student is not null) return student;
                throw new KeyNotFoundException($"Nincs ilyen azonosítójú diák: {id}");
            }
        }

        public Subject this[string name]
        {
            get
            {
                var subject = subjects.Find(x => x.Name == name);

                if (subject is not null) return subject;
                throw new KeyNotFoundException($"Nincs ilyen nevű tantárgy: {name}");
            }
        }
    }
}
