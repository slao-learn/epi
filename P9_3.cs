using System;
using System.Collections.Generic;

namespace epi
{
    public class P9_3
    {
        public static bool IsWellFormed(string s)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; ++i)
            {
                if (s [i] == '{' || s [i] == '(' || s [i] == '[')
                    stack.Push(s [i]);
                else if (stack.Count == 0 ||
                         (s [i] == '}' && stack.Peek() != '{') ||
                         (s [i] == ')' && stack.Peek() != '(') ||
                         (s [i] == ']' && stack.Peek() != '['))
                    return false;
                else
                    stack.Pop();
            }
            return stack.Count == 0;
        }

        public static void RunTests()
        {
            Console.WriteLine(IsWellFormed("[]"));
            Console.WriteLine(IsWellFormed("[](){}"));
            Console.WriteLine(IsWellFormed("[])(){}"));
            Console.WriteLine(IsWellFormed("([]){()}"));
            Console.WriteLine(IsWellFormed("[()[]{()()}]"));
            Console.WriteLine(IsWellFormed("{)"));
            Console.WriteLine(IsWellFormed("{(})"));
        }
    }
}

