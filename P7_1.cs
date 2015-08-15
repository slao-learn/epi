using System;

public class P7_1
{
    private static int ParseString(string value)
    {
        char[] arr = value.ToCharArray();
        int result = 0;
        bool isNeg = arr[0] == '-';

        for (int i = (isNeg ? 1 : 0); i < arr.Length; ++i)
        {
            int digit = arr[i] - '0';
            result = result * 10 + digit;
        }

        return (isNeg ? -result : result);
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
            value = -value;
        }
        while (value > 0)
        {
            char c = (char)('0' + (value % 10));
            result = c + result;
            value /= 10;
        }
        return (isNeg ? "-" + result : result);
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