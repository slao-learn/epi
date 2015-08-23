using System;
using System.Collections.Generic;

public class P13_3
{
    public static bool IsAnonLetterConstructible(string letter, string magazine)
    {
        if (letter.Length > magazine.Length)
            return false;

        Dictionary<char, int> counts = new Dictionary<char, int>();

        for (int i = 0; i < letter.Length; ++i)
        {
            char c = letter[i];
            if (c == ' ') continue;
            if (counts.ContainsKey(c))
            {
                ++counts[c];
            } else
            {
                counts[c] = 1;
            }
        }

        for (int i = 0; i < magazine.Length; ++i)
        {
            char c = magazine[i];
            if (c == ' ') continue;
            if (counts.ContainsKey(c))
            {
                --counts[c];
                if (counts[c] == 0)
                {
                    counts.Remove(c);
                    if (counts.Count == 0)
                        return true;
                }
            }
        }

        return counts.Count == 0;
    }

    public static void RunTests()
    {
        Console.WriteLine(IsAnonLetterConstructible("hello", "the lady in red"));
        Console.WriteLine(IsAnonLetterConstructible("hello", "he likes oatmeal"));
    }
}
