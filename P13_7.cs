using System;
using System.Collections.Generic;

namespace epi
{
    public class P13_7
    {
        public static int GetShortestDist(string[] arr)
        {
            int min = int.MaxValue;
            Dictionary<string, int> index = new Dictionary<string, int>();
            for (int i = 0; i < arr.Length; ++i)
            {
                string s = arr [i];
                if (index.ContainsKey(s) && (i - index [s] < min))
                    min = i - index [s];
                index [s] = i;
            }
            return min;
        }

        public static void RunTests()
        {
            Console.WriteLine(GetShortestDist("the cow jumped over the moon or the other cow".Split(' ')));
            Console.WriteLine(GetShortestDist("All work and no play makes for no work".Split(' ')));
            Console.WriteLine(GetShortestDist("All work and and me".Split(' ')));
            Console.WriteLine(GetShortestDist("All".Split(' ')));
        }
    }
}

