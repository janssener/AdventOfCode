using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day5
    {
        public static int Run()
        {
            int loopTime = 0;
            using (StreamReader sr = new StreamReader(@""))
            {
                List<int> instructions = new List<int>();
                while (!sr.EndOfStream)
                {
                    instructions.Add(int.Parse(sr.ReadLine().Trim()));
                }

                bool outOfLadder = false;
                int index = 0;

                while (!outOfLadder)
                {
                    var step = instructions[index];
                    if (step == 0)
                    {
                        step = 2;
                        instructions[index] = step;
                        loopTime++; // we are skipping a loop here, because lazy
                        index++;
                    }
                    else
                    {
                        instructions[index] = instructions[index] + 1;
                        index += step;                      

                        if(index >= instructions.Count || index < 0)
                        {
                            outOfLadder = true;
                        }                 
                    }

                    loopTime++;
                }
            }

            return loopTime;
        }

        public static int Run2()
        {
            int loopTime = 0;
            using (StreamReader sr = new StreamReader(@""))
            {
                List<int> instructions = new List<int>();
                while (!sr.EndOfStream)
                {
                    instructions.Add(int.Parse(sr.ReadLine().Trim()));
                }

                bool outOfLadder = false;
                int index = 0;

                while (!outOfLadder)
                {
                    var step = instructions[index];
                    if (step == 0)
                    {
                        step = 2;
                        instructions[index] = step;
                        loopTime++; // we are skipping a loop here, because lazy
                        index++;
                    }
                    else
                    {
                        instructions[index] = step >= 3 ? instructions[index] - 1 : instructions[index] + 1;
                        index += step;

                        if (index >= instructions.Count || index < 0)
                        {
                            outOfLadder = true;
                        }
                    }

                    loopTime++;
                }
            }

            return loopTime;
        }
    }
}
