using System;

public class P12_5
{
    public static int IntSqRt(int value)
    {
        int low = 0, high = value;

        while (high >= low)
        {
            int i = (high + low) / 2;
            int test = i * i;

            if (test <= value)
            {
                low = i + 1;
            } else
            {
                high = i - 1;
            }
        }

        return low - 1;
    }

    public static void RunTests()
    {
        Console.WriteLine(IntSqRt(0));
        Console.WriteLine(IntSqRt(1));
        Console.WriteLine(IntSqRt(16));
        Console.WriteLine(IntSqRt(300));
    }
}
