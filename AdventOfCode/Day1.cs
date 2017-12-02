using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day1
    {

        public static int Run(string input)
        {
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[(i + 1) % input.Length])
                {
                    sum += int.Parse(input[i].ToString());
                }
            }

            return sum;
        }

        public static int Run2(string input)
        {
            var sum = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == input[(i + (input.Length / 2)) % input.Length])
                {
                    sum += int.Parse(input[i].ToString());
                }
            }
            return sum;
        }
    }
}
