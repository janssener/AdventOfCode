using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day11
    {
        public static int Run()
        {
            return RunLogic();
        }

        public static int Run2()
        {
            return RunLogic2();
        }

        private static int RunLogic2()
        {

            int x = 0;
            int y = 0;

            int totalSteps = 0;
            using (StreamReader sr = new StreamReader(@""))
            {
                List<string> lineRead = new List<string>();
                while (!sr.EndOfStream)
                {
                    lineRead.AddRange(sr.ReadLine().Split(','));
                }

                y += lineRead.Count(t => t.StartsWith("n") && t != "n");
                y += lineRead.Count(t => t == "n") * 2; // 2 step to make up for diag
                y -= lineRead.Count(t => t.StartsWith("s") && t != "s");
                y -= lineRead.Count(t => t == "s") * 2;

                x += lineRead.Count(t => t.EndsWith("e"));
                x -= lineRead.Count(t => t.EndsWith("w"));

                totalSteps = GetSteps(x, y);
            }

            return totalSteps;
        }

        private static int RunLogic()
        {
            int x = 0;
            int y = 0;

            int maxSteps = 0;
            using (StreamReader sr = new StreamReader(@""))
            {
                List<string> lineRead = new List<string>();
                while (!sr.EndOfStream)
                {
                    lineRead.AddRange(sr.ReadLine().Split(','));
                }

                foreach (var moveSet in lineRead)
                {
                    switch (moveSet)
                    {
                        case "n":
                            y += 2;
                            break;
                        case "s":
                            y -= 2;
                            break;
                        case "ne":
                            x++;
                            y++;
                            break;
                        case "nw":
                            x--;
                            y++;
                            break;
                        case "se":
                            y--;
                            x++;
                            break;
                        case "sw":
                            y--;
                            x--;
                            break;
                        default:
                            break;
                    }

                    var testStepCount = GetSteps(x, y);
                    maxSteps = testStepCount > maxSteps ? testStepCount : maxSteps;
                }
            }

            return maxSteps;
        }

        private static int GetSteps(int x, int y)
        {
            var xYdiff = Math.Abs(x) - Math.Abs(y);
            var vertMovement = Math.Abs(xYdiff) / 2; // by 2 to account for moving sideways when we incremented above by 2 for vertMovement

            var pairMove = Math.Min(Math.Abs(x), Math.Abs(y));
            return vertMovement + pairMove;
        }
    }
}