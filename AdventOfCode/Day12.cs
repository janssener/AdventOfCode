using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class ProgramCommInfo
    {
        public List<string> CommPrograms;

        public string CurrentProgName { get; set; }

        public ProgramCommInfo(string currProg, List<string> commProgs)
        {
            CurrentProgName = currProg;
            CommPrograms = new List<string>(commProgs);
        }
    }

    public static class Day12
    {
        public static List<ProgramCommInfo> ProgramsReadIn;
        public static List<string> GroupedPrograms;

        public static int Run()
        {
            return RunLogic(false);
        }

        public static int Run2()
        {         
            return RunLogic(true);
        }


        private static int RunLogic(bool part2)
        {
            GroupedPrograms = new List<string>();
            ProgramsReadIn = new List<ProgramCommInfo>();
            int groups = 0;

            using (StreamReader sr = new StreamReader(@""))
            {
                while (!sr.EndOfStream)
                {
                    var lineRead = sr.ReadLine().Split(new string[] { " <-> " }, StringSplitOptions.None);
                    var dirProgName = lineRead[0];
                    var connectedProgs = lineRead[1].Split(new string[] { ", " }, StringSplitOptions.None).ToList();
                    ProgramsReadIn.Add(new ProgramCommInfo(dirProgName, connectedProgs));
                }
            }

            if (part2)
            {
                int lastLoopProgCount = 0;
                foreach (var prog in ProgramsReadIn)
                {
                    lastLoopProgCount = GroupedPrograms.Count;
                    ProcessProgram(prog);
                    if (lastLoopProgCount != GroupedPrograms.Count) groups++;
                }
            }
            else ProcessProgram(ProgramsReadIn.First());

            return part2 ? groups : GroupedPrograms.Count;
        }

        private static void ProcessProgram(ProgramCommInfo currentProg)
        {
            if (!GroupedPrograms.Contains(currentProg.CurrentProgName))
            {
                GroupedPrograms.Add(currentProg.CurrentProgName);
                foreach (var prog in currentProg.CommPrograms)
                {
                    ProcessProgram(ProgramsReadIn.Find(t => t.CurrentProgName == prog));
                }
            }
        }
    }
}