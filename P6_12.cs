using System;

public class P6_12
{
    public static void Subset(int[] arr, int k)
    {
        Random r = new Random();
        for (int i = 0; i < k; ++i)
        {
            int index = r.Next(i, arr.Length - 1);
            Swap(arr, i, index);
        }
    }

    private static void Swap(int[] arr, int i, int j)
    {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }

    public static void RunTests()
    {
        int[] a = new int[] { 3, 5, 7, 4, 8, 9, 10, 15, 23 };
        Subset(a, 4);
        for (int i = 0; i < 4; ++i)
        {
            Console.Write(a[i] + " ");
        }
    }
}
