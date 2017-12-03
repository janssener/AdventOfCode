using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AdventOfCode
{
    public static class Day3
    {
        public enum Sides
        {
            top = 2,
            right = 3,
            left = 1,
            bottom = 0
        }
        public static void Run()
        {
            int input = 368078;

            int rungWeAreIn = 1;
            double maxInRung = 1;
            int powCounter = 1;
            while (input > maxInRung)
            {
                powCounter += 2;
                maxInRung = Math.Pow((powCounter), 2);
                rungWeAreIn++;
            }

            var differenceFromMax = maxInRung - input;
            var sideDistance = Math.Sqrt(maxInRung);
            var sideWeAreOn = Math.Truncate(differenceFromMax / (sideDistance - 1));

            switch (sideWeAreOn)
            {
                case 0:
                    var xMidpoint = maxInRung - Math.Truncate(sideDistance / 2);
                    var steps = Math.Abs(input - xMidpoint);
                    steps += (rungWeAreIn - 1);

                    break; // too lazy and need to beat mike to finish these other cases ;)
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }

        }

        public static long Run2()
        {
            int input = 368078;

            // lazily get a huge array
            Dictionary<Point, long> arrayOfNumbers = new Dictionary<Point, long>();

            for (int i = -500; i < 500; i++)
            {
                for (int j = -500; j < 500; j++)
                {
                    arrayOfNumbers.Add(new Point(i, j), 0); // screw memory

                }
            }

            int dir = 0;
            int stepsUntilRotate = 1;
            var currentPt = new Point(0, 0);
            bool increaseSteps = false;
            int steps = 1;
            long sum = 1;

            // init
            arrayOfNumbers[currentPt] = 1;
            while (sum < input)
            {
                if (stepsUntilRotate == 0)
                {
                    if (increaseSteps) ++steps;

                    increaseSteps = !increaseSteps;

                    stepsUntilRotate = steps;

                    dir = (++dir) % 4;
                }

                switch (dir)
                {
                    case 0: //right and then spiral down
                        currentPt.X++;
                        break;
                    case 1:
                        currentPt.Y--;
                        break;
                    case 2:
                        currentPt.X--;
                        break;
                    case 3:
                        currentPt.Y++;
                        break;
                }

                stepsUntilRotate -= 1;

                // please dont throw exception on index not found, we hav a lot of indexes...blindly add everything
                sum = arrayOfNumbers[new Point(currentPt.X, currentPt.Y - 1)]
                    + arrayOfNumbers[new Point(currentPt.X, currentPt.Y + 1)]

                    + arrayOfNumbers[new Point(currentPt.X - 1, currentPt.Y - 1)]
                    + arrayOfNumbers[new Point(currentPt.X - 1, currentPt.Y + 1)]
                    + arrayOfNumbers[new Point(currentPt.X - 1, currentPt.Y)]

                    + arrayOfNumbers[new Point(currentPt.X + 1, currentPt.Y - 1)]
                    + arrayOfNumbers[new Point(currentPt.X + 1, currentPt.Y)]
                    + arrayOfNumbers[new Point(currentPt.X + 1, currentPt.Y + 1)];

                arrayOfNumbers[currentPt] = sum;
            }

            return sum;
        }
    }
}
