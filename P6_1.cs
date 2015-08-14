using System;

public class P6_1 : Problem
{
    // Time complexity = O(n)
    // Space complexity = O(1)
    public static void Rearrange(int pivotIndex, int[] values)
    {
        Console.WriteLine("PivotIndex={0}\nInput={1}", pivotIndex, ArrayString(values));

        int pivot = values[pivotIndex];
        int tailIndex = 0;
        for (int i = 0; i < values.Length; ++i)
        {
            if (values[i] < pivot)
            {
                Swap(values, i, tailIndex++);
            }
        }

        tailIndex = values.Length - 1;
        for (int i = values.Length - 1; i >= 0 && values[i] >= pivot; --i)
        {
            if (values[i] > pivot)
            {
                Swap(values, i, tailIndex--);
            }
        }

        Console.WriteLine("Output={0}\n", ArrayString(values));
    }

    private static void Swap(int[] values, int i, int j)
    {
        if (i == j)
            return;
        int tmp = values[i];
        values[i] = values[j];
        values[j] = tmp;
    }

    public static void RunTests()
    {
        int[] arr;

        int pivotIndex = 4;
        arr = new int[] { 1,4,2,2,6,7,5,15,9,10,8 };
        Rearrange(pivotIndex, arr);

        pivotIndex = 7;
        arr = new int[] { 1,4,2,2,6,7,5,15,9,10,8 };
        Rearrange(pivotIndex, arr);

        pivotIndex = 0;
        arr = new int[] { 1,4,2,2,6,7,5,15,9,10,8 };
        Rearrange(pivotIndex, arr);

        pivotIndex = 8;
        arr = new int[] { 1,4,2,2,6,7,5,15,9,10,8 };
        Rearrange(pivotIndex, arr);
    }

    private static string ArrayString(int[] arr)
    {
        string result = "";
        for (int i = 0; i < arr.Length; ++i)
        {
            if (i < arr.Length - 1)
            {
                result += arr[i] + ",";
            } else
            {
                result += arr[i];
            }
        }
        return result;
    }
}
