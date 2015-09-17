using System;

namespace epi
{
    public class P14_3
    {
        public static void PrintFreqs(string s)
        {
            int[] f = new int[26]; // assume english
            s = s.ToLower();
            for (int i = 0; i < s.Length; ++i)
            {
                int index = s [i] - 'a';
                if (index >= 0 && index < f.Length)
                    ++f [index];
            }
            bool first = true;
            for (int i = 0; i < f.Length; ++i)
            {
                if (f [i] > 0)
                {
                    if (!first)
                        Console.Write(", ");
                    Console.Write("({0},{1})", (char)('a' + i), f [i]);
                    first = false;
                }
            }
            Console.WriteLine();
        }

        public static void RunTests()
        {
            PrintFreqs("We are working to support a learning experience");
            PrintFreqs("");
            PrintFreqs("a");
            PrintFreqs("zz");
        }
    }
}

