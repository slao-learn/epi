using System;

namespace epi
{
    public class P12_4
    {
        public static int SearchSmallest(int[] arr)
        {
            int l = 0, r = arr.Length - 1;
            while (l < r)
            {
                int m = l + (r - l) / 2;
                if (arr [m] > arr [r])
                {
                    l = m + 1;
                } else
                {
                    r = m;
                }
            }
            return l;
        }

        public static void RunTests()
        {
            Console.WriteLine(SearchSmallest(new int[] { 378, 478, 550, 631, 103, 203, 220, 234, 279, 368 }));
            Console.WriteLine(SearchSmallest(new int[] { 1, 2, 3 }));
            Console.WriteLine(SearchSmallest(new int[] { 1, 3 }));
            Console.WriteLine(SearchSmallest(new int[] { 3, 1 }));
            Console.WriteLine(SearchSmallest(new int[] { 1 }));
        }
    }
}

