using System;

public class P7_5
{
    public static bool IsPalindromic(string s)
    {
        int l = 0, r = s.Length - 1;
        s = s.ToLower();
        while (l < r)
        {
            while (!IsAlphaNumeric(s [l]) && l < r)
                ++l;
            while (!IsAlphaNumeric(s [r]) && l < r)
                --r;
            if (l < r && s [l++] != s [r--])
            {
                return false;
            }
        }
        return true;
    }

    private static bool IsAlphaNumeric(char c)
    {
        return ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'));
    }

    public static void RunTests()
    {
        Console.WriteLine(IsPalindromic("A man, a plan, a canal, Panama"));
        Console.WriteLine(IsPalindromic("c!a=b.a%c%^&"));
        Console.WriteLine(IsPalindromic("vb"));
        Console.WriteLine(IsPalindromic("123 a 321"));
        Console.WriteLine(IsPalindromic("A"));
    }
}
