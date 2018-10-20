using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day16
    {
        private const string StartString = "abcdefghijklmnop";

        public static string Run()
        {
            var ops = ReadInput();

            return ProcessString(ops, StartString); ;
        }

        public static string Run2()
        {
            var ops = ReadInput();
            var procString = StartString;
            int loopIndex = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                procString = ProcessString(ops, procString);
                if(StartString == procString)
                {
                    loopIndex = i + 1;
                    break;
                }
            }

            // so we can't brute it... we know we cycle to the start again. divide the amount of iterations until
            // we hit our loop and then find the remainder. That remainder is the amount of time we need to then loop
            // since that will be our point from where we are at an iteration until the 1billion mark
            for (int i = 0; i < 1000000000 % loopIndex; i++)
            {
                procString = ProcessString(ops, procString);
            }

            return procString;
        }

        private static List<string> ReadInput()
        {
            List<string> inputList = null;
            using (StreamReader sr = new StreamReader(@"your path if lazy like me"))
            {
                inputList = sr.ReadToEnd().Split(',').ToList();
            }

            return inputList;
        }

        private static string ProcessString(List<string> operations, string processString)
        {
            var sb = new StringBuilder(processString);
            foreach (var op in operations)
            {
                switch(op.First())
                {
                    // swap at integer location in string
                    case 'X':
                    case 'x':
                        var locations = op.Substring(1).Split('/').Select(t => int.Parse(t));
                        var tempChar = sb[locations.First()];
                        sb[locations.First()] = sb[locations.Last()];
                        sb[locations.Last()] = tempChar;
                        break;

                    // swap the actual characters
                    case 'P':
                    case 'p':
                        var swapChars = op.Substring(1).Split('/');
                        var tempString = sb.ToString();
                        var firstIndex = tempString.IndexOf(swapChars.First());
                        var lastIndex = tempString.IndexOf(swapChars.Last());
                        tempChar = sb[firstIndex];
                        sb[firstIndex] = sb[lastIndex];
                        sb[lastIndex] = tempChar;
                        break;

                    // spin the characters of specific size
                    case 'S':
                    case 's':
                        var charsToMove = int.Parse(op.Substring(1));
                        tempString = sb.ToString();
                        var pivotPoint = tempString.Count() - charsToMove;

                        // ouch, expensive... bad but I am lazy right now
                        sb = new StringBuilder(tempString.Substring(pivotPoint) + string.Concat(tempString.Take(pivotPoint)));
                        break;
                    default:
                        throw new Exception("Operation was found that wasn't supported " + op.First());
                }
            }

            return sb.ToString();
        }
    }
}
