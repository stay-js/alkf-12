﻿using FoglalasLib;

await File.WriteAllTextAsync("hibak.txt", string.Empty);

var roomRegistration = new RoomRegistration(File.ReadLines("termek.txt").Skip(1));

Console.WriteLine("Az elérhető termek:");
Console.WriteLine(string.Join("\n", roomRegistration.RoomIds));

List<Reservation> reservations = [];

foreach (string line in File.ReadLines("foglalasok.txt").Skip(1))
{
    try
    {
        reservations.Add(new Reservation(line));
    }
    catch (Exception e)
    {
        await File.WriteAllTextAsync("hibak.txt", $"{line} - {e.Message}\n");
    }
}

await roomRegistration.MakeReservations(reservations);

Console.WriteLine("\nA termek a foglalások után:");
Console.WriteLine(string.Join("\n\n", roomRegistration.Rooms));

Console.Write("\n\nKérem egy tanár azonosítóját: ");
string teacherId = Console.ReadLine() ?? "";
Console.WriteLine("A tanár foglalásai:");

foreach (var room in roomRegistration.Rooms)
{
    var reservationsByTeacher = room.TimeTable.GetReservationsByTeacherId(teacherId);
    if (!reservationsByTeacher.Any()) continue;

    Console.WriteLine(room.Id);
    Console.WriteLine(string.Join("\n", reservationsByTeacher));
}
