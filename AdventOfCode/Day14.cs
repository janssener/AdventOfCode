using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day14
    {

        public static int Run()
        {
            int boxesUsed = 0;
            for (int i = 0; i < 128; i++)
            {
                boxesUsed += String.Join(String.Empty,
                    KnotHasher.Hash(Enumerable.Range(0, 256).ToList(), ("flqrgnkx-" + i).Select(t => (int)t).ToList())
                    .Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                    )
                    ).Count(t => t == '1');
            }

            return boxesUsed;
        }

        // TODO: Finish this when it isn't 2am and have some motivation to re-read knot hashing
        public static int Run2()
        {
            List<string> hashes = new List<string>();

            for (int i = 0; i < 128; i++)
            {
                hashes.Add(String.Join(String.Empty,
                    KnotHasher.Hash(Enumerable.Range(0, 256).ToList(), ("flqrgnkx-" + i).Select(t => (int)t).ToList())
                    .Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                    )
                    ).Replace('1', '-')
                );
            }

            int regionCount = 1;
            // process each '-'
            for (int i = 0; i < hashes.Count; i++)
            {
                for (int j = 0; j < hashes[i].Count(); j++)
                {
                    if (hashes[i][j] == '-')
                    {
                        ProcessPosition(hashes, i, j, 1);
                        regionCount++;
                    }
                }
            }


            return 0;
        }

        private static void ProcessPosition(List<string> hashes, int listCound, int stringPosCount, int numToReplace)
        {
            StringBuilder tempString = new StringBuilder(hashes[listCound]);
            //tempString[stringPosCount] = ;
        }
    }
}