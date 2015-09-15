using System;

public class P6_1
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

    // Time complexity = O(n)
    // Space complexity = O(1)
    public static void RearrangeOnePass(int pivotIndex, int[] values)
    {
        Console.WriteLine("PivotIndex={0}\nInput={1}", pivotIndex, ArrayString(values));

        int pivot = values[pivotIndex];
        int less = 0, equals = 0, more = values.Length - 1;

        while (equals <= more)
        {
            if (values[equals] < pivot)
            {
                Swap(values, less++, equals++);
            } else if (values[equals] == pivot)
            {
                equals++;
            } else
            {
                Swap(values, more--, equals);
            }
        }

        Console.WriteLine("Output={0}\n", ArrayString(values));
    }

    // Time complexity = O(n)
    // Space complexity = O(1)
    // assume valid inputs are 1, 2, 3
    public static void RearrangeVariant1(int pivotIndex, int[] values)
    {
        Console.WriteLine("PivotIndex={0}\nInput={1}", pivotIndex, ArrayString(values));

        int i1 = 0, i2 = 0, i3 = values.Length - 1;

        while (i2 <= i3)
        {
            if (values[i2] == 1)
            {
                values[i2++] = values[i1];
                values[i1++] = 1;
            } else if (values[i2] == 2)
            {
                ++i2;
            } else
            {
                values[i2] = values[i3];
                values[i3--] = 3;
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

        Console.WriteLine("Rearrange method");

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

        Console.WriteLine("Rearrange One Pass method");

        pivotIndex = 4;
        arr = new int[] { 1,4,2,2,6,7,5,15,9,10,8 };
        RearrangeOnePass(pivotIndex, arr);
        
        pivotIndex = 7;
        arr = new int[] { 1,4,2,2,6,7,5,15,9,10,8 };
        RearrangeOnePass(pivotIndex, arr);
        
        pivotIndex = 0;
        arr = new int[] { 1,4,2,2,6,7,5,15,9,10,8 };
        RearrangeOnePass(pivotIndex, arr);
        
        pivotIndex = 8;
        arr = new int[] { 1,4,2,2,6,7,5,15,9,10,8 };
        RearrangeOnePass(pivotIndex, arr);

        pivotIndex = 8;
        arr = new int[] { 1,3,2,2,1,1,2,2,3,1,3 };
        RearrangeVariant1(pivotIndex, arr);
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
