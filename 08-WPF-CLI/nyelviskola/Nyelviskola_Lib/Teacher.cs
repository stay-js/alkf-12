﻿using System.Text.Json.Serialization;

namespace Nyelviskola_Lib
{
    public class Teacher
    {
        public int ID { get; init; }
        public string Name { get; init; }
        public int LanguageID { get; init; }
        public int HourlyRate { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }

        [JsonIgnore]
        public bool Net { get; init; }

        [JsonPropertyName("net")]
        public int JSONFormattedNet => Net ? 1 : 0;

        public Teacher(string line)
        {
            string[] parts = line.Split(';');

            ID = int.Parse(parts[0]);
            Name = parts[1];
            LanguageID = int.Parse(parts[2]);
            HourlyRate = int.Parse(parts[3]);
            PhoneNumber = parts[4];
            Email = parts[5];
            Net = Convert.ToBoolean(int.Parse(parts[6]));
        }

        [JsonIgnore]
        public int LessonCount => DataStore
            .Instance?
            .Lessons
            .Count(x => x.TeacherID == ID) ?? 0;

        [JsonIgnore]
        public int Earnings => DataStore
            .Instance?
            .Lessons
            .Where(x => x.TeacherID == ID)
            .Sum(x => x.Cost) ?? 0;

        public override string ToString() => $"{Name} ({DataStore
            .Instance?
            .Languages
            .FirstOrDefault(x => x.ID == LanguageID)?
            .Name})";
    }
}
