using System;
using System.Collections.Generic;

public class P18_7
{
    public static int FindStartCity(int[] g, int[] d)
    {
        const int mpg = 20;
        int carry = 0;
        KeyValuePair<int, int> minCarryPair = new KeyValuePair<int, int>(0, 0);
        for (int i = 1; i < g.Length; ++i)
        {
            carry += g[i-1] - d[i-1] / mpg;
            if (carry < minCarryPair.Value)
            {
                minCarryPair = new KeyValuePair<int, int>(i, carry);
            }
        }
        return minCarryPair.Key;
    }

    public static void RunTests()
    {
        int[] g = new int[] { 20, 15, 15, 15, 35, 25, 30, 15, 65, 45, 10, 45, 25 };
        int[] d = new int[] { 300, 400, 1000, 300, 300, 600, 400, 1100, 400, 1000, 200, 300, 300 };
        Console.WriteLine(FindStartCity(g, d));
    }
}
