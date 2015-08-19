using System;

public class P18_5
{
    public static bool HasThreeSum(int[] a, int t)
    {
        return HasKSum(a, t, 3);
    }

    public static bool HasKSum(int[] a, int t, int k)
    {
        if (k == 0)
        {
            return (t == 0);
        }

        for (int i = 0; i < a.Length; ++i)
        {
            if (HasKSum(a, t -  a[i], k - 1))
            {
                return true;
            }
        }
        return false;
    }

    public static void RunTests()
    {
        int[] arr = new int[] { 3, 5, 8 };
        Console.WriteLine(HasThreeSum(arr, 4));
        Console.WriteLine(HasThreeSum(arr, 16));
        Console.WriteLine(HasThreeSum(arr, 6));
        Console.WriteLine(HasThreeSum(arr, 9));
        Console.WriteLine(HasThreeSum(arr, 11));
    }
}