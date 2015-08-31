using System;
using System.Collections.Generic;

public class P9_2
{
    public static int Compute(string s)
    {
        string[] sArr = s.Split(',');
        Stack<int> stack = new Stack<int>();
        stack.Push(Convert.ToInt32(sArr [0]));
        int index = 1;
        while (index < sArr.Length)
        {
            string op = sArr [index++];
            if (op == "+" || op == "-" || op == "x" || op == "/")
            {
                int b = stack.Pop();
                int a = stack.Pop();
                stack.Push(PerformOp(op [0], b, a));
            } else
            {
                stack.Push(Convert.ToInt32(op));
            }
        }
        return stack.Pop();
    }

    private static int PerformOp(char c, int a, int b)
    {
        switch (c)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case 'x':
                return a * b;
            case '/':
                return a / b;
            default:
                return 0;
        }
    }

    public static void RunTests()
    {
        Console.WriteLine(Compute("3,4,+,2,x,1,+"));
        Console.WriteLine(Compute("1,1,+"));
        Console.WriteLine(Compute("1,1,+,-2,x"));
        Console.WriteLine(Compute("4,6,/,2,/"));
    }
}
