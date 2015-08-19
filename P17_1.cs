using System;

public class P17_1
{
    public static int CountCombinations(int k, int[] score_ways)
    {
        return CountCombosHelper(k, 0, score_ways);
    }

    private static int CountCombosHelper(int k, int start_index, int[] score_ways)
    {
        int result = 0;
        
        if (k == 0)
            return 1;
        else if (k < 0 || start_index == score_ways.Length)
            return 0;
        
        for(int i = 0; i <= k / score_ways[start_index]; ++i)
        {
            result += CountCombosHelper(k - score_ways[start_index] * i, start_index + 1, score_ways);
        }
        
        return result;
    }

    public static int CountCombinationsDP(int k, int[] score_ways)
    {
        int[] combos = new int[k + 1];
        combos[0] = 1;
        foreach(var score in score_ways)
        {
            for(int j = score; j <= k; ++j)
            {
                combos[j] += combos[j - score];
            }
        }
        return combos[k];
    }

    public static void RunTests()
    {
        Console.WriteLine(CountCombinations(12, new int[] { 2, 3, 7 }));
        Console.WriteLine(CountCombinations(9, new int[] { 2, 3, 7 }));
        Console.WriteLine(CountCombinations(3, new int[] { 2, 3, 7 }));

        Console.WriteLine(CountCombinationsDP(12, new int[] { 2, 3, 7 }));
        Console.WriteLine(CountCombinationsDP(9, new int[] { 2, 3, 7 }));
        Console.WriteLine(CountCombinationsDP(3, new int[] { 2, 3, 7 }));
    }
}