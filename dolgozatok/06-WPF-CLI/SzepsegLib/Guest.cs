namespace SzepsegLib
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Guest(string line)
        {
            string[] parts = line.Split(';');

            Id = int.Parse(parts[0]);
            Name = parts[1];
            Address = parts[2];
            PhoneNumber = parts[3];
        }
    }
}
