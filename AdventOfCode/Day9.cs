using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day9
    {
        public static int Run()
        {
            return RunLogic(false);
        }

        public static int Run2()
        {
            return RunLogic(true);
        }

        private static int RunLogic(bool partTwo = false)
        {
            int score = 1;
            int garbageCount = 0;

            using (StreamReader sr = new StreamReader(@""))
            {
                var inText = sr.ReadToEnd();
                int groupDepth = 1;
                int index = 1;

                while (index < inText.Length)
                {
                    var charRead = inText[index];

                    if (charRead == '!')
                    {
                        index++;
                        continue;
                    }
                    else if (charRead == '<')
                    {
                        // now in garbage
                        bool inGarbage = true;
                        index++;
                        while (inGarbage)
                        {
                            charRead = inText[index];
                            if (charRead == '!')
                            {
                                index += 2;
                                continue;
                            }
                            else if (charRead == '>')
                            {
                                inGarbage = false;
                            }
                            else
                            {
                                garbageCount++;
                                index++;
                            }
                        }
                    }
                    else if (charRead == '{')
                    {
                        // process group counter
                        groupDepth++;
                        score += groupDepth;
                    }
                    else if (charRead == '}')
                    {
                        // process group exit
                        groupDepth--;
                    }

                    index++;
                }
            }

            return partTwo ? garbageCount : score;
        }
    }
}