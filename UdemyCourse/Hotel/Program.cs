using System;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Rooms[] rooms = new Rooms[10];
            rooms[0] = new Rooms();
            rooms[1] = new Rooms();
            rooms[2] = new Rooms();
            rooms[3] = new Rooms();
            rooms[4] = new Rooms();
            rooms[5] = new Rooms();
            rooms[6] = new Rooms();
            rooms[7] = new Rooms();
            rooms[8] = new Rooms();
            rooms[9] = new Rooms();

            Reception.FillRooms(rooms);
            Reception.ShowBusyRooms(rooms);

        }
    }
}
