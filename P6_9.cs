using System;
using System.Collections.Generic;

namespace epi
{
    public class P6_9
    {
        public static List<int> EnumeratePrimes(int n)
        {
            List<int> l = new List<int>();
            bool[] p = new bool[n + 1];
            for (int i = 2; i < p.Length; ++i)
            {
                if (!p [i]) // is prime
                {
                    l.Add(i);
                
                    for (int j = i * i; j < p.Length; j += i)
                    {
                        p [j] = true;
                    }
                }
            }
            return l;
        }

        public static void RunTests()
        {
            Print(EnumeratePrimes(18));
            Print(EnumeratePrimes(100));
        }

        private static void Print(List<int> l)
        {
            foreach (var i in l)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}

