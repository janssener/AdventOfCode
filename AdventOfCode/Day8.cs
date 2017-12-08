using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day8
    {
        public static int Run()
        {
            var highestValEver = 0;
            var topResult = 0;
            Dictionary<string, int> regs = new Dictionary<string, int>();

            using (StreamReader sr = new StreamReader(@""))
            {
                while (!sr.EndOfStream)
                {
                    var lineRead = sr.ReadLine().Split(' ');
                    var reg = lineRead[0];
                    var opToReg = lineRead[1];
                    var opVal = lineRead[2];
                    var regBeingChecked = lineRead[4];
                    var opConditional = lineRead[5];
                    var conditionalCheckVal = lineRead[6];

                    if (!regs.Keys.Contains(reg))
                    {
                        // reg not there, val is 0
                        regs.Add(reg, 0);
                    }

                    if (!regs.Keys.Contains(regBeingChecked))
                    {
                        regs.Add(regBeingChecked, 0);
                    }

                    // in the second param I had regs[reg] causued 30min delay in submitting correctly
                    if (Compare(opConditional, regs[regBeingChecked], int.Parse(conditionalCheckVal)))
                    {
                        regs[reg] = opToReg == "dec" ? regs[reg] - int.Parse(opVal) : regs[reg] + int.Parse(opVal);
                        if (regs[reg] > highestValEver) highestValEver = regs[reg];
                    }
                }

                topResult = regs.OrderByDescending(t => t.Value).First().Value;
            }

            return topResult;
        }

        private static bool Compare(string Op, int regVal, int CondVal)
        {
            bool result = false;
            switch (Op)
            {
                case "<":
                    result = regVal < CondVal;
                    break;
                case ">":
                    result = regVal > CondVal;
                    break;
                case "<=":
                    result = regVal <= CondVal;
                    break;
                case ">=":
                    result = regVal >= CondVal;
                    break;
                case "==":
                    result = regVal == CondVal;
                    break;
                case "!=":
                    result = regVal != CondVal;
                    break;

                default:
                    throw new Exception(); //throw something                    
            }

            return result;
        }

        public static int Run2()
        {
            var highestValEver = 0;
            var topResult = 0;
            Dictionary<string, int> regs = new Dictionary<string, int>();

            using (StreamReader sr = new StreamReader(@""))
            {
                while (!sr.EndOfStream)
                {
                    var lineRead = sr.ReadLine().Split(' ');
                    var reg = lineRead[0];
                    var opToReg = lineRead[1];
                    var opVal = lineRead[2];
                    var regBeingChecked = lineRead[4];
                    var opConditional = lineRead[5];
                    var conditionalCheckVal = lineRead[6];

                    if (!regs.Keys.Contains(reg))
                    {
                        // reg not there, val is 0
                        regs.Add(reg, 0);
                    }

                    if (!regs.Keys.Contains(regBeingChecked))
                    {
                        regs.Add(regBeingChecked, 0);
                    }

                    if (Compare(opConditional, regs[regBeingChecked], int.Parse(conditionalCheckVal)))
                    {
                        regs[reg] = opToReg == "dec" ? regs[reg] - int.Parse(opVal) : regs[reg] + int.Parse(opVal);
                        if (regs[reg] > highestValEver) highestValEver = regs[reg];
                    }
                }

                topResult = regs.OrderByDescending(t => t.Value).First().Value;
            }

            return highestValEver;
        }
    }
}