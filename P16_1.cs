using System;
using System.Collections.Generic;

public class P16_1
{
    public static void TowersOfHanoi(int numRings)
    {
        Stack<int>[] pegs = new Stack<int>[3] { new Stack<int>(), new Stack<int>(), new Stack<int>() };

        for (int i = numRings; i > 0; --i)
        {
            pegs[0].Push(i);
        }

        foreach(var peg in pegs)
        {
            PrintStack(peg);
        }
        Console.WriteLine();
        Transfer(numRings, pegs, 0, 1, 2);
    }

    private static void Transfer(int ringsToMove, Stack<int>[] pegs, int fromStackIndex, int toStackIndex, int tempStackIndex)
    {
        if (ringsToMove > 0)
        {
            Transfer(ringsToMove - 1, pegs, fromStackIndex, tempStackIndex, toStackIndex);

            pegs[toStackIndex].Push(pegs[fromStackIndex].Pop());
            Console.WriteLine("Move from peg {0} to peg {1}", fromStackIndex, toStackIndex);
            foreach(var peg in pegs)
            {
                PrintStack(peg);
            }
            Console.WriteLine();
            Transfer(ringsToMove - 1, pegs, tempStackIndex, toStackIndex, fromStackIndex);
        }
    }

    public static void RunTests()
    { 
        TowersOfHanoi(6);
    }

    private static void PrintStack(Stack<int> stack)
    {
        var e = stack.GetEnumerator();
        bool empty = true;
        while (e.MoveNext())
        {
            empty = false;
            Console.Write(e.Current + " ");
        }
        if (empty)
        {
            Console.WriteLine("empty");
        } else
        {
            Console.WriteLine();
        }
    }
}
