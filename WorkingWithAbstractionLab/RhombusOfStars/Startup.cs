using System;

namespace RhombusOfStars
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());

            PrintRombOfStars(inputNumber);

        }

        public static void PrintRombOfStars(int inputNumber)
        {
            TopPart(inputNumber);
            BottomPart(inputNumber);
        }

        private static void TopPart(int inputNumber)
        {
            for (int row = 0; row < inputNumber; row++)
            {
                Console.Write($"{new string(' ', inputNumber - 1 - row)}");

                for (int col = 0; col <= row; col++)
                {
                    Console.Write($"{new string('*', 1)}");

                    if (col != row)
                    {
                        Console.Write($"{new string(' ', 1)}");
                    }
                }

                Console.WriteLine();
            }
        }

        private static void BottomPart(int inputNumber)
        {
            for (int row = inputNumber - 2; row >= 0; row--)
            {
                Console.Write($"{new string(' ', inputNumber - 1 - row)}");

                for (int col = 0; col <= row; col++)
                {
                    Console.Write($"{new String('*', 1)}");
                    if (col != row)
                    {
                        Console.Write($"{new String(' ', 1)}");
                    }
                }
                Console.WriteLine();

            }
        }
    }
}
