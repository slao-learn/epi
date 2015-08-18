using System.Collections.Generic;
using System;

public class P14_1
{
    public static int[] IntersectTwoSortedArrays(int[] a, int[] b)
    {
        if (a == null || b == null)
        {
            return new int[0];
        }

        List<int> result = new List<int>();
        int prev = a[0] - 1;

        int aIndex = 0, bIndex = 0;
        while (aIndex < a.Length && bIndex < b.Length)
        {
            if (a[aIndex] == b[bIndex] && a[aIndex] != prev)
            {
                prev = a[aIndex];
                result.Add(prev);
                ++aIndex;
                ++bIndex;
            } else if (a[aIndex] < b[bIndex])
            {
                ++aIndex;
            } else
            {
                ++bIndex;
            }
        }

        return result.ToArray();
    }

    public static void RunTests()
    {
        int[] a = new int[] { 2, 3, 3, 5, 5, 6, 7, 7, 8, 12 };
        int[] b = new int[] { 5, 5, 6, 8, 8, 9, 10, 10 };
        int[] c = IntersectTwoSortedArrays(a, b);
        for ( int i = 0; i < c.Length; ++i)
        {
            Console.Write(c[i] + " ");
        }
    }
}
