namespace Hospital
{
    using System.Collections.Generic;
    using System.Text;

    public class Departament
    {
        private const int bedCapacity = 60;
        private const int roomsCount = 20;
        
        public Departament(string name)
        {
            this.Name = name;
            this.Capacity = bedCapacity;
            this.Rooms = AddRooms();
        }

        public string Name { get; private set; }

        public List<Room> Rooms;

        public int Capacity { get;  set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var room in this.Rooms)
            {
                foreach (var patient in room.PatientsInRoom)
                {
                    if(patient != null)
                    {
                        result.AppendLine($"{patient}");
                    }
                }
            }

            return result.ToString();
        }

        public List<Room> AddRooms()
        {
            var rooms = new List<Room>();
            var room = new Room();

            for (int add = 0; add < roomsCount; add++)
            {
                rooms.Add(room);
            }
            return rooms;
        }

    }
}
