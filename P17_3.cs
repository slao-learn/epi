using System;

namespace epi
{
    public class P17_3
    {
        public static int NumberOfWays(bool[,] B)
        {
            int n = B.GetLength(0), m = B.GetLength(1);
            int[,] A = new int[n, m];
            A [0, 0] = 1;
            for (int r = 0; r < n; ++r)
            {
                for (int c = 0; c < m; ++c)
                {
                    int top = (r == 0 ? 0 : A [r - 1, c]);
                    int left = (c == 0 ? 0 : A [r, c - 1]);
                    if (!B [r,c])
                    {
                        A [r,c] += top + left;
                    }
                }
            }
            return A [n - 1, m - 1];
        }

        public static void RunTests()
        {
            bool[,] B = new bool[4, 3];
            Console.WriteLine(NumberOfWays(B));
            B [2, 2] = true;
            B [3, 0] = true;
            Console.WriteLine(NumberOfWays(B));
        }
    }
}

