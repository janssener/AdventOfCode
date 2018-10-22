using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day17
    {
        private const int StepIncrement = 348;


        public static int Run()
        {
            List<int> circBuffer = new List<int>() { 0 };
            int currentLocation = 0;

            for (int i = 1; i < 2018; i++)
            {
                // each loop we need to index into the array position with mod
                var index = ((StepIncrement + currentLocation) % circBuffer.Count) + 1;
                if (index == circBuffer.Count)
                {
                    circBuffer.Add(i);
                }
                else
                {
                    circBuffer.Insert(index, i);
                }

                currentLocation = index;
            }

            return circBuffer[currentLocation + 1];
        }

        public static int Run2()
        {
            int currentLocation = 0;
            int value = 0;
            for (int i = 1; i < 50000000; i++)
            {
                // 0 never moves. only keep track of the value that we are on if we hit mod of 0
                var index = ((StepIncrement + currentLocation) % i) + 1;
                if (index == 1) value = i;

                currentLocation = index;
            }

            return value;
        }
    }
}
