namespace JediGalaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            var dimestions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var x = dimestions[0];
            var y = dimestions[1];

            var matrix = new int[x, y];

            FillUpTheField(matrix);

            string command = Console.ReadLine();
            long ivoPowerScore = 0;

            while (command != "Let the Force be with you")
            {
                var ivoMoveInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int ivoRow = ivoMoveInfo[0];
                int ivoColumn = ivoMoveInfo[1];

                var evilMoveInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var evilRow = evilMoveInfo[0];
                var evilColumn = evilMoveInfo[1];

                EvilPowerMove(matrix, ref evilRow, ref evilColumn);
                IvoMove(matrix, ref ivoPowerScore, ref ivoRow, ref ivoColumn);

                command = Console.ReadLine();
            }

            Console.WriteLine(ivoPowerScore);

        }

        private static void IvoMove(int[,] matrix, ref long ivoPowerScore, ref int ivoRow, ref int ivoColumn)
        {
            while (ivoRow >= 0 && ivoColumn < matrix.GetLength(1))
            {
                var isInside = IsIside(matrix, ivoRow, ivoColumn);
                if (isInside)
                {
                    ivoPowerScore += matrix[ivoRow, ivoColumn];
                }

                ivoColumn++;
                ivoRow--;
            }
        }

        private static void EvilPowerMove(int[,] matrix, ref int evilRow, ref int evilColumn)
        {
            while (evilRow >= 0 && evilColumn >= 0)
            {
                var isInside = IsIside(matrix, evilRow, evilColumn);
                if (isInside)
                {
                    matrix[evilRow, evilColumn] = 0;
                }
                evilRow--;
                evilColumn--;
            }
        }

        private static void FillUpTheField(int[,] matrix)
        {
            var value = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }

        private static bool IsIside(int[,] matrix, int row, int column)
        {
            return row >= 0 
                && row < matrix.GetLength(0) 
                && column >= 0 
                && column < matrix.GetLength(1);
        }
    }
}
