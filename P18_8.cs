using System;

namespace epi
{
    public class P18_8
    {
        public static int GetMaxArea(int[] heights)
        {
            int l = 0, r = heights.Length - 1;
            int max = 0;
            while (l < r)
            {
                max = Math.Max(max, (r - 1) * Math.Min(heights [l], heights [r]));
                if (heights [l] < heights [r])
                    ++l;
                else if (heights [l] > heights [r])
                    --r;
                else
                {
                    ++l;
                    --r;
                }
            }
            return max;
        }

        public static void RunTests()
        {
            Console.WriteLine(GetMaxArea(new int[] { 1, 2, 1, 3, 4, 4, 5, 6, 2, 1, 3, 1, 3 ,2, 1, 2, 4, 1 }));
        }
    }
}

