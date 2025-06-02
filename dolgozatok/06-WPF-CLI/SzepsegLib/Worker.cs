namespace SzepsegLib
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfessionId { get; set; }
        public string PhoneNumber { get; set; }

        public Worker(string line)
        {
            string[] parts = line.Split(';');

            Id = int.Parse(parts[0]);
            Name = parts[1];
            ProfessionId = int.Parse(parts[2]);
            PhoneNumber = parts[3];
        }

        public int Earnings => DataStore
            .Instance?
            .Procedures
            .Where(x => x.WorkerId == Id)
            .Sum(x => x.Price) ?? 0;

        public override string ToString()
        {
            string profession = DataStore
                .Instance?
                .Professions
                .FirstOrDefault(x => x.Id == ProfessionId)?
                .Name ?? "";

            return $"{Name} ({profession}): {Earnings} Ft";
        }
    }
}
