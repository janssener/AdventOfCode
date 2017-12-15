using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class FirewallSection
    {
        public int Index { get; private set; }
        public int Depth { get; private set; }
        public int CurrentScanPos { get; private set; } = 0;
        public int MoveDirection { get; private set; } = 1;

        public FirewallSection(int index, int depth, int currentScanPos = 0, int moveDire = 1)
        {
            Index = index;
            Depth = depth;
            CurrentScanPos = currentScanPos;
            MoveDirection = moveDire;
        }

        public bool GotCaught()
        {
            return CurrentScanPos == 0;
        }

        public void MoveScanner()
        {
            CurrentScanPos += MoveDirection;
            if ((MoveDirection == 1 && CurrentScanPos + 1 >= Depth) ||
                (MoveDirection == -1 && CurrentScanPos == 0))
            {
                MoveDirection *= -1;
            }
        }
    }

    public static class Day13
    {
        public static int Run()
        {
            var firewall = GetFireWall();
            return RunLogic(firewall, false);
        }

        public static int Run2()
        {
            bool caught = true;
            int delayNeeded = 0;
            var firewall = GetFireWall();
            firewall = firewall.OrderBy(t => t.Depth).ToList(); // should reduce some extra loops
            for (int i = 0; caught; i++)
            {
                delayNeeded = i;
                List<FirewallSection> tempFW = new List<FirewallSection>();
                firewall.ForEach((wall) => tempFW.Add(new FirewallSection(wall.Index, wall.Depth, wall.CurrentScanPos, wall.MoveDirection)));

                if (RunLogic(tempFW, true) == 0)
                {
                    caught = true; // useless
                    break;
                }

                foreach (var wall in firewall)
                {
                    wall.MoveScanner();
                }
                Console.WriteLine(i);
            }

            return delayNeeded;
        }


        private static int RunLogic(List<FirewallSection> firewall, bool part2)
        {
            FirewallSection segment;
            int severity = 0;
            bool caught = false;
            for (int i = 0; i <= firewall.Max(t => t.Index); i++)
            {
                // check if we are caught
                segment = firewall.Find(t => t.Index == i);
                if (segment != null && segment.GotCaught())
                {
                    caught = true;
                    severity += segment.Depth * segment.Index;
                    if (part2) break;
                }

                foreach (var seg in firewall)
                {
                    seg.MoveScanner();
                }
            }

            return part2 ? caught ? 1 : 0 : severity;
        }

        private static List<FirewallSection> GetFireWall()
        {
            List<FirewallSection> firewall = new List<FirewallSection>();
            using (StreamReader sr = new StreamReader(@""))
            {
                while (!sr.EndOfStream)
                {
                    var lineRead = sr.ReadLine().Split(new string[] { ": " }, StringSplitOptions.None).Select(t => int.Parse(t));
                    firewall.Add(new FirewallSection(lineRead.First(), lineRead.Last()));
                }
            }

            return firewall;
        }
    }
}