using System;

public class P5_8
{
    public static int ReverseDigits(int value)
    {
        int reverse = 0;
        bool isNeg = false;

        if (value < 0)
        {
            isNeg = true;
            value = -value;
        }

        while (value > 0)
        {
            reverse = reverse * 10 + (value % 10);
            value /= 10;
        }

        return isNeg ? -reverse : reverse;
    }

    public static void RunTests()
    {
        Console.WriteLine(ReverseDigits(0));
        Console.WriteLine(ReverseDigits(42));
        Console.WriteLine(ReverseDigits(-314));
        Console.WriteLine(ReverseDigits(-100));
    }

}
