using System;
using System.Text;

public class P7_2
{
    public static string ConvertBase(string s, int b1, int b2)
    {
        char[] chars = s.ToUpper().ToCharArray();
        bool isNeg = (chars[0] == '-');
        int value = 0;

        // Get int value in base b1
        for (int i = (isNeg ? 1 : 0); i < chars.Length; ++i)
        {
            value *= b1;
            value += GetIntValue(chars[i]);
        }

        // Convert to string in base b2
        StringBuilder result = new StringBuilder();
        while (value > 0)
        {
            char n = GetBaseSymbol(value % b2);
            result.Insert(0, n);
            value /= b2;
        }

        if (isNeg)
        {
            result.Insert(0, '-');
        }

        return result.ToString();
    }

    private static char GetBaseSymbol(int value)
    {
        if (value < 10)
        {
            return (char)('0' + value);
        } else
        {
            return (char)('A' + (value - 10));
        }
    }

    private static int GetIntValue(char value)
    {
        if (value >= 'A' && value <= 'F')
        {
            return (int)(value - 'A') + 10;
        } else
        {
            return (int)(value - '0');
        }
    }

    public static void RunTests()
    {
        Console.WriteLine(ConvertBase("17", 10, 2));
        Console.WriteLine(ConvertBase("32", 10, 2));
        Console.WriteLine(ConvertBase("32", 10, 16));
        Console.WriteLine(ConvertBase("15", 10, 16));
        Console.WriteLine(ConvertBase("16", 10, 16));
        Console.WriteLine(ConvertBase("27", 10, 8));
        Console.WriteLine(ConvertBase("27", 10, 2));
        Console.WriteLine(ConvertBase("27", 10, 3));
        Console.WriteLine(ConvertBase("27", 10, 4));
        Console.WriteLine(ConvertBase("27", 10, 5));
        Console.WriteLine(ConvertBase("-27", 10, 16));
    }
}