using System;

public class P5_7
{
    public static double Power(double x, int y)
    {
        double result = 1.0;
        long power = y;

        if (y < 0)
        {
            power = -power;
            x = 1.0 / x;
        }

        while (power > 0)
        {
            if ((power & 1) == 1)
            {
                result *= x;
            }
            x *= x;
            power >>= 1;
        }

        return result;
    }

    public static void RunTests()
    {
        Console.WriteLine(Power(3, 3));
        Console.WriteLine(Power(4, 4));
        Console.WriteLine(Power(2, 5));
        Console.WriteLine(Power(2, -3));
        Console.WriteLine(Power(1, 500));
        Console.WriteLine(Power(10, 1));
        Console.WriteLine(Power(55, 0));
    }
}

