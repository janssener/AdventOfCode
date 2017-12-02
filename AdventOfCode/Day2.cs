using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day2
    {

        public static int Run3()
        {
            int checksum = 0;

            using (var sr = new StreamReader(@"lazily type file path because we went for pure speed"))
            {
                while (!sr.EndOfStream)
                {
                    var lineRead = sr.ReadLine();
                    var items = lineRead.Split('\t', ' ').ToList().OrderBy(t => int.Parse(t));
                    var diff = Math.Abs(int.Parse(items.First()) - int.Parse(items.Last()));
                    checksum += diff;
                }
            }

            return checksum;
        }

        public static int Run4()
        {
            int checksum = 0;

            using (var sr = new StreamReader(@"lazily type file path because we went for pure speed"))
            {
                while (!sr.EndOfStream)
                {
                    var lineRead = sr.ReadLine();
                    var items = lineRead.Split('\t', ' ').ToList().OrderByDescending(t => int.Parse(t)).ToList();

                    for (int i = 0; i < items.Count(); i++)
                    {
                        bool cutEarly = false;
                        for (int j = 0; j < items.Count(); j++)
                        {
                            if (i == j) continue;
                            if (int.Parse(items[i]) % int.Parse(items[j]) == 0)
                            {
                                checksum += (int.Parse(items[i]) / int.Parse(items[j]));
                                cutEarly = true;
                                break;
                            }
                            if (cutEarly) break;
                        }
                    }
                }
            }

            return checksum;
        }
    }
}
