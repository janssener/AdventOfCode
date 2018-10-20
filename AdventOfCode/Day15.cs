using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day15
    {

        private const int AFactor = 16807;
        private const int BFactor = 48271;
        private const int DivideFactor = 2147483647;

        private const int ASeed = 289;
        private const int BSeed = 629;

        // 40 million
        private const int ProcessCount = 40000000;

        public static int Run()
        {
            int totalMatches = 0;
            long aVal = ASeed;
            long bVal = BSeed;

            for (int i = 0; i < ProcessCount; i++)
            {
                aVal = (aVal * AFactor) % DivideFactor;
                bVal = (bVal * BFactor) % DivideFactor;

                if ((aVal & 0xFFFF) == (bVal & 0xFFFF))
                {
                    totalMatches++;
                }
            }

            return totalMatches;
        }

        public static int Run2()
        {
            int totalMatches = 0;
            long aVal = ASeed;
            long bVal = BSeed;

            Queue<long> aValQueue = new Queue<long>();
            Queue<long> bValQueue = new Queue<long>();

            for (int i = 0; i < ProcessCount; i++)
            {
                aVal = (aVal * AFactor) % DivideFactor;
                bVal = (bVal * BFactor) % DivideFactor;

                // multiple of 4
                if (aVal % 4 == 0)
                {
                    aValQueue.Enqueue(aVal);
                }

                // multiple of 2
                if (bVal % 8 == 0)
                {
                    bValQueue.Enqueue(bVal);
                }

                if (aValQueue.Count > 0 && bValQueue.Count > 0)
                {
                    if ((aValQueue.Dequeue() & 0xFFFF) == (bValQueue.Dequeue() & 0xFFFF))
                    {
                        totalMatches++;
                    }
                }
            }

            return totalMatches;
        }
    }
}
