using System;

public class P12_9
{
    public static int FindKthLargest(int[] a, int k)
    {
        Random random = new Random();
        int left = 0, right = a.Length - 1;
        while (left <= right)
        {
            int pivotIndex = random.Next(left, right);
            int newPivotIndex = PartitionAroundPivot(a, pivotIndex, left, right);
            if (newPivotIndex == k - 1)
            {
                return a[newPivotIndex];
            } else if (newPivotIndex < k - 1)
            {
                left = newPivotIndex + 1;
            } else
            {
                right = newPivotIndex - 1;
            }
        }
        return a[left];
    }

    private static int PartitionAroundPivot(int[] a, int pivotIndex, int left, int right)
    {
        int pivotValue = a[pivotIndex];
        Swap(a, pivotIndex, right);
        int newPivotValue = left;
        for (int i = left; i < right; ++i)
        {
            if (a[i] > pivotValue)
            {
                Swap(a, i, newPivotValue++);
            }
        }
        Swap(a, right, newPivotValue);
        return newPivotValue;
    }

    private static void Swap(int[] a, int i, int j)
    {
        int tmp = a[i];
        a[i] = a[j];
        a[j] = tmp;
    }
    
    public static void RunTests()
    {
        int[] a = new int[] { 3, 2, 1, 5, 4 };
        Console.WriteLine(FindKthLargest(a, 1));

        a = new int[] { 3, 2, 1, 5, 4 };
        Console.WriteLine(FindKthLargest(a, 2));

        a = new int[] { 3, 2, 1, 5, 4 };
        Console.WriteLine(FindKthLargest(a, 3));
    }
}