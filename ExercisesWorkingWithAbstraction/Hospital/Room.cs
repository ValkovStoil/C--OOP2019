namespace Hospital
{
    using System.Collections.Generic;

    public class Room
    {

        public Room()
        {
            this.PatientsInRoom = new List<Patient>();
        }

        public List<Patient> PatientsInRoom;

    }
}
