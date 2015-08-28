using System;

public class P17_3
{
    public static int GetInt(string code)
    {
        int value = 0;
        for (int i = 0; i < code.Length; ++i)
        {
            value = value * 26 + (int)(code [i] - 'A' + 1);
        }
        return value;
    }

    public static void RunTests()
    {
        Console.WriteLine(GetInt("A"));
        Console.WriteLine(GetInt("Z"));
        Console.WriteLine(GetInt("AA"));
        Console.WriteLine(GetInt("ZZ"));
        Console.WriteLine(GetInt("MN"));
        Console.WriteLine(GetInt("CCC"));
    }
}
