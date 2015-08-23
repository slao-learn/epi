using System;

public class P14_2
{
    public static void MergeSort(int[] a, int aLength, int[] b, int bLength)
    {
        int tail = aLength + bLength - 1;
        int aIndex = aLength - 1;
        int bIndex = bLength - 1;

        while (aIndex >= 0 && bIndex >= 0)
        {
            a[tail--] = (a[aIndex] >= b[bIndex] ? a[aIndex--] : b[bIndex--]);
        }
        if (bIndex >= 0)
            a[tail--] = b[bIndex--];
    }

    public static void RunTests()
    {
        int[] a = new int[] { 1, 3, 5, 7, 7, 9 };
        int[] b = new int[] { 2, 3, 4, 6, 8, 10, 11, 12 };
        int[] newA = new int[a.Length + b.Length];
        for (int i = 0; i < a.Length; ++i)
        {
            newA[i] = a[i];
        }
        MergeSort(newA, a.Length, b, b.Length);
        for (int i = 0; i < newA.Length; ++i)
        {
            Console.Write(newA[i] + " ");
        }
    }
}