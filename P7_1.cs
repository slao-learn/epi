using System;

public class P7_1
{
    private static int ParseString(string value)
    {
        char[] arr = value.ToCharArray();
        int result = 0;
        int place = 1;

        for (int i = value.Length - 1; i >= 0; --i)
        {
            char c = arr[i];
            if (i == 0 && c == '-')
            {
                result *= -1;
            } else
            {
                int digit = c - '0';
                result += digit * place;
                place *= 10;
            }
        }

        return result;
    }

    private static string ParseInt(int value)
    {
        string result = "";
        bool isNeg = false;

        if (value == 0)
        {
            return "0";
        }

        if (value < 0)
        {
            isNeg = true;
            value *= -1;
        }
        while (value > 0)
        {
            char c = (char)('0' + (value % 10));
            result = c + result;
            value /= 10;
        }
        if (isNeg)
        {
            result = "-" + result;
        }
        return result;
    }

    public static void RunTests()
    {
        Console.WriteLine(ParseString("100"));
        Console.WriteLine(ParseString("-567"));
        Console.WriteLine(ParseString("9452"));
        Console.WriteLine(ParseString("0"));

        Console.WriteLine(ParseInt(100));
        Console.WriteLine(ParseInt(-567));
        Console.WriteLine(ParseInt(9452));
        Console.WriteLine(ParseInt(0));
    }
}