using System;

public class P12_1
{
    public static int FirstIndexOf(int value, int[] arr)
    {
        int l = 0, h = arr.Length - 1;
        int found = -1;

        while (l <= h)
        {
            int m = l + (h-l) / 2;
            if (arr[m] == value)
            {
                found = m;
                h = m - 1;
            }
            else if (arr[m] < value)
                l = m + 1;
            else
                h = m - 1;
        }
        return found;
    }

    public static int FindLocalMin(int[] arr)
    {
        if (arr.Length == 3)
            return 1;

        int l = 1, r = arr.Length - 2;
        while (l <= r)
        {
            if (arr[l-1] >= arr[l] && arr[l] <= arr[l+1])
                return l;
            else
                l += 1;

            if (arr[r-1] >= arr[r] && arr[r] <= arr[r+1])
                return r;
            else
                r -= 1;
        }
        return -1;
    }

    public static int FindMaxInAscendingDescending(int[] arr)
    {
        int left = 0, right = arr.Length - 1;
        int max = arr[left];
        while (left < right)
        {
            int m = left + (right - left) / 2;
            if (arr[m] < max)
            {
                right = m - 1;
            } else
            {
                max = arr[m];
                left = m + 1;
            }
        }
        return max;
    }

    public static void RunTests()
    {
        int[] arr = new int[] { 1, 2, 4, 4, 8, 10, 32, 66 };
        Console.WriteLine(FirstIndexOf(8, arr));
        Console.WriteLine(FirstIndexOf(4, arr));

        arr = new int[] { 10, 5, 4, 3, 3, 8, 20 };
        Console.WriteLine(FindLocalMin(arr));

        arr = new int[] { 4, 5, 6, 6, 7, 7, 4, 3, 2, 0 };
        Console.WriteLine(FindMaxInAscendingDescending(arr));
    }
}