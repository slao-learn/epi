using System;
using System.Collections.Generic;

public class P7_7
{
    private static readonly char[][] phone = new char[][]
    {
        new char[] { '0' },
        new char[] { '1' },
        new char[] { 'a', 'b', 'c' },
        new char[] { 'd', 'e', 'f' },
        new char[] { 'g', 'h', 'i' },
        new char[] { 'j', 'k', 'l' },
        new char[] { 'm', 'n', 'o' },
        new char[] { 'p', 'q', 'r', 's' },
        new char[] { 't', 'u', 'v' },
        new char[] { 'w', 'x', 'y', 'z' }
    };

    public static List<string> GetAllMnemonics(string digits)
    {
        int[] d = new int[digits.Length];
        for (int i = 0; i < digits.Length; ++i)
        {
            d[i] = (int)(digits[i] - '0');
        }
        List<string> list = GetAllMnemonicsHelper(d, 0);
        return list;
    }

    private static List<string> GetAllMnemonicsHelper(int[] digits, int startIndex)
    {
        if (startIndex == digits.Length)
        {
            return new List<string>() { "" };
        }

        List<string> mnemonics = new List<string>();
        char[] letters = GetChars(digits[startIndex]);
        for (int i = 0; i < letters.Length; ++i)
        {
            List<string> sub = GetAllMnemonicsHelper(digits, startIndex+1);
            for (int j = 0; j < sub.Count; ++j)
            {
                mnemonics.Add(letters[i] + sub[j]);
            }
        }
        return mnemonics;
    }

    private static char[] GetChars(int digit)
    {
        return phone[digit];
    }

    public static void RunTests()
    {
        string number = "234";
        List<string> m = GetAllMnemonics(number);
        Console.WriteLine(number);
        foreach ( string w in m )
        {
            Console.WriteLine(w);
        }
        Console.WriteLine();

        number = "123456790";
        m = GetAllMnemonics(number);
        Console.WriteLine(number);
        foreach ( string w in m )
        {
            Console.WriteLine(w);
        }
        Console.WriteLine();

    }
}

