namespace StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        private Dictionary<string, Student> studentsData;


        public StudentSystem()
        {
            this.studentsData = new Dictionary<string, Student>();
        }

        public void Add(string name, int age, double grade)
        {
            if (!this.studentsData.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.studentsData[name] = student;
            }
        }

        public Student Get(string name)
        {
            
            if (this.studentsData.ContainsKey(name))
            {
                var student = this.studentsData[name];
                return student;
            }

            return null;
        }

    }
}
