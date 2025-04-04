using System.Globalization;
using System.Text.Json.Serialization;

namespace Nyelviskola_Lib
{
    public class Lesson
    {
        public int ID { get; init; }
        public int TeacherID { get; init; }
        public DateOnly Date { get; init; }
        public TimeOnly Time { get; init; }
        public int Hours { get; init; }

        public Lesson(string line)
        {
            string[] parts = line.Split(';');
            ID = int.Parse(parts[0]);
            TeacherID = int.Parse(parts[1]);
            Date = DateOnly.Parse(parts[2], new CultureInfo("hu-HU"));
            Time = TimeOnly.Parse(parts[3], new CultureInfo("hu-HU"));
            Hours = int.Parse(parts[4]);
        }

        [JsonIgnore]
        public int Cost => Hours * DataStore.Instance?.Teachers
            .FirstOrDefault(x => x.ID == TeacherID)?.HourlyRate ?? 0;

        public bool LessonIsInGivenMonth(int year, int month) =>
            Date.Year == year && Date.Month == month;
    }
}
