using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class ProgramInfo
    {
        public ProgramInfo(string name, int weight, List<string> linkedProg)
        {
            Name = name;
            Weight = weight;
            LinkedProgramNames = new List<string>(linkedProg);
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public List<string> LinkedProgramNames { get; set; }
    }

    public static class Day7
    {
        public static List<ProgramInfo> pi = new List<ProgramInfo>();

        public static string Run()
        {
            string rootName = "";

            using (StreamReader sr = new StreamReader(@""))
            {

                while (!sr.EndOfStream)
                {
                    var lineRead = sr.ReadLine().Split(' ');

                    // process name
                    var name = lineRead[0];
                    var weight = int.Parse(lineRead[1].Trim('(', ')'));
                    // get the list of strings
                    List<string> linkedProg = new List<string>();

                    if (lineRead.Count() > 2)
                    {
                        for (int i = 3; i < lineRead.Count(); i++)
                        {
                            linkedProg.Add(lineRead[i].Trim(','));
                        }
                    }

                    pi.Add(new ProgramInfo(name, weight, linkedProg));
                }

                var possibleRoots = pi.Where(t => t.LinkedProgramNames.Count() > 0).ToList();


                foreach (var root in possibleRoots)
                {
                    if (!possibleRoots.Any(t => t.LinkedProgramNames.Any(m => m == root.Name)))
                    {
                        rootName = root.Name;
                        break;
                    }
                }
            }

            return rootName;
        }

        public static int Run2()
        {
            var rootName = Run();

            // traverse the list
            var rootProg = pi.Find(t => t.Name == rootName);

            List<int> weights = new List<int>();
            foreach (var linkedProg in rootProg.LinkedProgramNames)
            {
                weights.Add(TraverseAndReturn(pi.Find(t => t.Name == linkedProg), 0));
            }

            return 0;
        }


        public static int TraverseAndReturn(ProgramInfo anotherPi, int depth)
        {
            int sum = 0;
            if (anotherPi.LinkedProgramNames.Count > 0)
            {
                foreach (var branch in anotherPi.LinkedProgramNames)
                {
                    sum += TraverseAndReturn(pi.Find(t => t.Name == branch), depth + 1);
                }
            }

            Console.WriteLine("depth is: " + depth + "    sum is: " + (anotherPi.Weight + sum)); // I manually found the one here that solved it by looking at output :(

            return anotherPi.Weight + sum;
        }
    }
}
