namespace Hospital
{
    using System.Collections.Generic;
    using System.Text;

    public class Departament
    {
        private const int bedCapacity = 60;
        private const int roomsCount = 20;
        
        public Departament()
        {
            this.Capacity = bedCapacity;
            this.Rooms = AddRooms();
        }

        public List<Room> Rooms;

        public int Capacity { get;  set; }

        public List<Room> AddRooms()
        {
            var rooms = new List<Room>();
            

            for (int add = 0; add < roomsCount; add++)
            {
                var room = new Room();
                rooms.Add(room);
            }
            return rooms;
        }

    }
}
