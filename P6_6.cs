using System;

namespace epi
{
    public class P6_6
    {
        public static void DeleteDups(int[] a)
        {
            int writeIndex = 1;
            for (int i = 1; i < a.Length; ++i)
            {
                if (a [i] != a [i - 1])
                {
                    if (writeIndex < i)
                    {
                        a [writeIndex] = a [i];
                    }
                    ++writeIndex;
                }
            }
            for (int i = writeIndex; i < a.Length; ++i)
            {
                a [i] = 0;
            }
        }

        public static void RunTests()
        {
            int[] a = new int[] { 2, 3, 5, 5, 7, 11, 11, 11, 13 };
            DeleteDups(a);
            Print(a);
        }

        private static void Print(int[] a)
        {
            foreach (var i in a)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}

