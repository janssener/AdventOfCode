using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Day14.Run2();
            
            Console.WriteLine("finally: " + result);

            var test = Day13.Run2();
            Console.WriteLine(test);
            Console.ReadKey();
        }
    }
}
