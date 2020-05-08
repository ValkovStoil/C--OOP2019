namespace Hospital
{
    using System.Collections.Generic;

    public class Departament
    {
        private const int bedCount = 60;

        
        public Departament(string name)
        {
            this.Name = name;
            this.Capacity = bedCount;
        }

        public string Name { get; private set; }

        public int Capacity { get;  set; }

    }
}
