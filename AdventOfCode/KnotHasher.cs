using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class KnotHasher
    {
        public static int SkipSize { get; private set; }
        public static int CurrentPos { get; private set; }

        public static string Hash(List<int> hashIn, List<int> asciiSeq)
        {
            SkipSize = 0;
            CurrentPos = 0;

            // add static ending
            asciiSeq.AddRange(new List<int> { 17, 31, 73, 47, 23 });
            for (int hashCount = 0; hashCount < 64; hashCount++)
            {
                int selectedLength = 0;
                int loopCounter = 0;

                while (loopCounter < asciiSeq.Count)
                {
                    selectedLength = asciiSeq[loopCounter];

                    if (selectedLength > hashIn.Count) continue;

                    var tempList = new List<int>();
                    for (int i = 0; i < selectedLength; i++) tempList.Add(hashIn[(CurrentPos + i) % hashIn.Count]);

                    tempList.Reverse();
                    for (int i = 0; i < selectedLength; i++) hashIn[(CurrentPos + i) % hashIn.Count] = tempList[i];

                    CurrentPos += selectedLength + SkipSize;
                    SkipSize++;
                    loopCounter++;
                }
            }

            string denseHash = "";
            for (int i = 0; i < 16; i++)
            {
                var block = hashIn.GetRange(i * 16, 16);
                int result = block[0];
                for (int j = 1; j < block.Count; j++) result = result ^ block[j];

                denseHash += result.ToString("X2");
            }

            return denseHash;
        }
    }
}
