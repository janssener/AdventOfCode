using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day4
    {
        public static int Run()
        {
            int valid = 0;
            using (StreamReader sr = new StreamReader(@"lazy path to file, removed for now"))
            {             
                var line = "";
                while(!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    var splitString = line.Split('\t', ' ').Where(t => !string.IsNullOrEmpty(t)).ToList();

                    bool badString = false;
                    for (int i = 0; i < splitString.Count; i++)
                    {
                        for (int j = 0; j < splitString.Count; j++)
                        {
                            if (splitString[i] == splitString[j])
                            {
                                if (i == j) continue;
                                badString = true;
                                break;
                            }
                        }
                        if (badString) break;
                    }
                    if(!badString)
                    valid++;
                }
            }

            return valid;
        }

        public static int Run2()
        {
            int valid = 0;
            using (StreamReader sr = new StreamReader(@"lazy path to file, removed for now"))
            {
                var line = "";
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    var splitString = line.Split('\t', ' ').Where(t => !string.IsNullOrEmpty(t)).ToList();

                    bool badString = false;
                    for (int i = 0; i < splitString.Count; i++)
                    {
                        for (int j = 0; j < splitString.Count; j++)
                        {
                            if (i == j) continue;
                            if (splitString[i].OrderBy(t => t).SequenceEqual( splitString[j].OrderBy(t => t)))
                            {                          
                                badString = true;
                                break;
                            }
                        }
                        if (badString) break;
                    }
                    if (!badString)
                        valid++;
                }
            }

            return valid;
        }
    }
}
