using System;
using System.Collections.Generic;

public class P6_2
{
    public static void Increment(List<int> list)
    {
        ++list [list.Count - 1];
        for (int i = list.Count - 1; i > 0 && list[i] == 10; --i)
        {
            list[i] = 0;
            ++list[i - 1];
        }
        if (list [0] == 10)
        {
            list [0] = 0;
            list.Insert(0, 1);
        }
    }

    public static void RunTests()
    {
        List<int> list = new List<int>() { 1, 2, 9 };
        Increment(list);
        foreach (var val in list)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();

        list = new List<int>() { 1, 9, 9 };
        Increment(list);
        foreach (var val in list)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();

        list = new List<int>() { 9, 9, 9 };
        Increment(list);
        foreach (var val in list)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();

        list = new List<int>() { 0 };
        Increment(list);
        foreach (var val in list)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }
}
