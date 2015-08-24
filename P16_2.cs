using System;
using System.Collections.Generic;

public class P16_2
{
    public static List<List<int>> NQueens(int n)
    {
        List<List<int>> results = new List<List<int>>();
        SolveNQueens(n, 0, new List<int>(), results);
        return results;
    }

    private static void SolveNQueens(int n, int row, List<int> colPlacement, List<List<int>> results)
    {
        if (row == n)
        {
            results.Add(colPlacement);
            return;
        }

        for (int col = 0; col < n; ++col)
        {
            if (TestPlacement(colPlacement, row, col))
            {
                List<int> newColPlacement = new List<int>(colPlacement);
                newColPlacement.Add(col);
                SolveNQueens(n, row+1, newColPlacement, results);
            }
        }
    }

    private static bool TestPlacement(List<int> colPlacement, int row, int col)
    {
        for(int i = 0; i < colPlacement.Count; ++i)
        {
            if (colPlacement[i] == col)
                return false;
            if (Math.Abs(colPlacement[i] - col) == (row - i))
                return false;
        }
        return true;
    }

    public static void RunTests()
    {
        List<List<int>> results = NQueens(1);
        Print(results);
        Console.WriteLine();

        results = NQueens(2);
        Print(results);
        Console.WriteLine();

        results = NQueens(3);
        Print(results);
        Console.WriteLine();

        results = NQueens(4);
        Print(results);
        Console.WriteLine();

        results = NQueens(5);
        Print(results);
        Console.WriteLine();

        results = NQueens(8);
        Print(results);
        Console.WriteLine();
    }

    private static void Print(List<List<int>> results)
    {
        if (results.Count == 0)
        {
            Console.WriteLine("no results");
        }
        foreach(var list in results)
        {
            foreach(var col in list)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
    }
}
