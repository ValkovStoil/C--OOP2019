﻿using System;
using System.Data;

namespace StudentSystem
{
    public class Startup
    {
        public static void Main()
        {
            var commandParser = new CommandParser();
            var studentSystem = new StudentSystem();

            while (true)
            {
                var command = commandParser.Parse(Console.ReadLine());

                if(command.Name == "Create")
                {
                    var name = command.Arguments[0];
                    var age = int.Parse(command.Arguments[1]);
                    var grade = double.Parse(command.Arguments[2]);

                    studentSystem.Add(name, age, grade);

                }
                else if(command.Name == "Show")
                {
                    var name = command.Arguments[0];

                    var student = studentSystem.Get(name);

                    Console.WriteLine(student);
                }
                else if(command.Name == "Exit")
                {
                    break;
                }
            }
        }
    }
}
