using System;

public class P6_18
{
    public static int[] Spiral(int[][] a)
    {
        int[] spiral = new int[a.Length * a.Length];
        int highIndex = a.Length - 1;
        int sIndex = 0;

        for (int layer = 0; layer < a.Length / 2; ++layer)
        {
            for (int i = layer; i < a.Length - layer; ++i)
            {
                spiral[sIndex++] = a[layer][i];
            }

            for (int i = layer + 1; i < a.Length - layer; ++i)
            {
                spiral[sIndex++] = a[i][highIndex - layer];
            }

            for (int i = highIndex - layer - 1; i >= layer; --i)
            {
                spiral[sIndex++] = a[highIndex - layer][i];
            }

            for (int i = highIndex - layer - 1; i > layer; --i)
            {
                spiral[sIndex++] = a[i][layer];
            }
        }

        if (a.Length % 2 == 1)
        {
            spiral[sIndex] = a[a.Length / 2][a.Length / 2];
        }

        return spiral;
    }

    public static void RunTests()
    {
        int[][] a = new int[][] {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };
        int[] spiralA = Spiral(a);
        for (int i = 0; i < spiralA.Length; ++i)
        {
            Console.Write(spiralA[i] + " ");
        }
        Console.WriteLine();

        int[][] b = new int[][] {
            new int[] { 1, 2, 3, 4 },
            new int[] { 5, 6, 7, 8 },
            new int[] { 9, 10, 11, 12 },
            new int[] { 13, 14, 15, 16 }
        };
        int[] spiralB = Spiral(b);
        for (int i = 0; i < spiralB.Length; ++i)
        {
            Console.Write(spiralB[i] + " ");
        }
        Console.WriteLine();

    }
}
