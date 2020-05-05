namespace PointInRectangle
{
    using System;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            var rectangleInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var topLeftX = rectangleInfo[0];
            var topLeftY = rectangleInfo[1];
            var bottomRightX = rectangleInfo[2];
            var bottomRightY = rectangleInfo[3];

            var topPoint = new Point(topLeftX, topLeftY);
            var bottomPoint = new Point(bottomRightX, bottomRightY);

            var rectangle = new Rectangle(topPoint, bottomPoint);

            var numberOfInputs = int.Parse(Console.ReadLine());

            for (int times = 0; times < numberOfInputs; times++)
            {
                var checkPointCoordinates = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var checkPoint = new Point(checkPointCoordinates[0], checkPointCoordinates[1]);

                Console.WriteLine(rectangle.Contains(checkPoint));
            }

        }
    }
}
