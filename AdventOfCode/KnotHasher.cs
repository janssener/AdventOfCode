using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class KnotHasher<T>
    {
        public int SkipSize { get; private set; }
        public int CurrentPos { get; private set; }   

        public KnotHasher()
        {

        }

        public List<T> Hash(List<T> hashIn, List<int> asciiSeq)
        {
            int selectedLength = 0;
            int loopCounter = 0;

            while (loopCounter < asciiSeq.Count)
            {
                selectedLength = asciiSeq[loopCounter];

                if (selectedLength > hashIn.Count) continue;

                var tempList = new List<T>();
                for (int i = 0; i < selectedLength; i++) tempList.Add(hashIn[(CurrentPos + i) % hashIn.Count]);

                tempList.Reverse();
                for (int i = 0; i < selectedLength; i++) hashIn[(CurrentPos + i) % hashIn.Count] = tempList[i];

                CurrentPos += selectedLength + SkipSize;
                SkipSize++;
                loopCounter++;
            }

            return hashIn;
        }
    }
}
