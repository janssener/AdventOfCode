using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day6
    {
        public static int Run()
        {
            int loops = 0;

            using (StreamReader sr = new StreamReader(@""))
            {
                string line = "";
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                }

                var banks = line.Split('\t', ' ').Select(t => int.Parse(t)).ToList();
                bool hasSeen = false;
                List<List<int>> priorSeq = new List<List<int>>();
                priorSeq.Add(new List<int>(banks));

                while (!hasSeen)
                {
                    int maxBlock = banks.Max();
                    int index = banks.IndexOf(maxBlock);

                    // zero out current
                    banks[index] = 0;

                    for (int i = 1; maxBlock > 0; i++)
                    {
                        banks[(index + i) % banks.Count] = banks[(index + i) % banks.Count] + 1;
                        maxBlock--;
                    }
                    

                    foreach (var priorList in priorSeq)
                    {
                        if (priorList.SequenceEqual(banks))
                            hasSeen = true;
                    }

                    // add to the list
                    priorSeq.Add(new List<int>(banks));
                    loops++;
                }
            }

            return loops ;
        }

        public static int Run2()
        {
            int loops = 0;
            using (StreamReader sr = new StreamReader(@""))
            {
                string line = "";
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                }

                var banks = line.Split('\t', ' ').Select(t => int.Parse(t)).ToList();

                Dictionary<List<int>, int> priorSeq = new Dictionary<List<int>, int>();
                priorSeq.Add(new List<int>(banks), 0);

                while (!priorSeq.Any(t => t.Value >= 2))
                {
                    int maxBlock = banks.Max();
                    int index = banks.IndexOf(maxBlock);

                    // zero out current
                    banks[index] = 0;

                    for (int i = 1; maxBlock > 0; i++)
                    {
                        banks[(index + i) % banks.Count] = banks[(index + i) % banks.Count] + 1;
                        maxBlock--;
                    }

                    // lazy
                    var foundKey = priorSeq.FirstOrDefault(t => t.Key.SequenceEqual(banks)).Key;
                    var foundVal = priorSeq.FirstOrDefault(t => t.Key.SequenceEqual(banks)).Value;
                    if (foundKey != null)
                    {
                        priorSeq.Remove(foundKey);
                        priorSeq.Add(foundKey, foundVal + 1);
                    }

                    // add to the list
                    priorSeq.Add(new List<int>(banks), 0);
                    loops++;
                }
            }

            return loops - Run();
        }
    }
}
