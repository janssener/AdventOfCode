using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    /// <summary>
    /// refactor to use 1 core logic loop
    /// </summary>
    public static class Day10
    {
        private static int skipSize = 0;
        private static int currentPos = 0;

        public static int Run()
        {
            return RunLogic1();
        }

        public static string Run2()
        {
            skipSize = 0;
            currentPos = 0;
            var sparseHash = new List<int>();
            List<int> asciiSeq = new List<int>();

            using (StreamReader sr = new StreamReader(@""))
            {
                asciiSeq.AddRange(sr.ReadLine().Select(t => (int)t));
            }

            // add static ending
            asciiSeq.AddRange(new List<int> { 17, 31, 73, 47, 23 });

            for (int i = 0; i < 256; i++) sparseHash.Add(i);

            for (int i = 0; i < 64; i++) sparseHash = RunLogic2(sparseHash, asciiSeq);

            string denseHash = "";
            
            // make dense hash
            for (int i = 0; i < 16; i++)
            {
                var block = sparseHash.GetRange(i * 16, 16);
                int result = block[0];
                for (int j = 1; j < block.Count; j++) result = result ^ block[j];

                denseHash += result.ToString("X2");
            }

            return denseHash;
        }

        private static int RunLogic1()
        {
            int selectedLength = 0;
            List<int> sequences = new List<int>();
            List<int> listOfNums = new List<int>();

            for (int i = 0; i < 256; i++) listOfNums.Add(i);

            using (StreamReader sr = new StreamReader(@""))
            {
                sequences.AddRange(sr.ReadLine().Split(',').Select(t => int.Parse(t)));
            }

            while (skipSize < sequences.Count)
            {
                selectedLength = sequences[skipSize];
                if (selectedLength > listOfNums.Count) continue;

                var tempList = new List<int>();

                for (int i = 0; i < selectedLength; i++)
                {
                    tempList.Add(listOfNums[(currentPos + i) % listOfNums.Count]);
                }

                tempList.Reverse();
                for (int i = 0; i < selectedLength; i++)
                {
                    listOfNums[(currentPos + i) % listOfNums.Count] = tempList[i];
                }

                currentPos += selectedLength + skipSize;
                skipSize++;
            }

            return listOfNums[0] * listOfNums[1];
        }

        public static List<int> RunLogic2(List<int> hashIn, List<int> asciiSeq)
        {
            int selectedLength = 0;
            int loopCounter = 0;

            while (loopCounter < asciiSeq.Count)
            {
                selectedLength = asciiSeq[loopCounter];

                if (selectedLength > hashIn.Count) continue;

                var tempList = new List<int>();
                for (int i = 0; i < selectedLength; i++) tempList.Add(hashIn[(currentPos + i) % hashIn.Count]);

                tempList.Reverse();
                for (int i = 0; i < selectedLength; i++) hashIn[(currentPos + i) % hashIn.Count] = tempList[i];

                currentPos += selectedLength + skipSize;
                skipSize++;
                loopCounter++;
            }

            return hashIn;
        }
    }
}