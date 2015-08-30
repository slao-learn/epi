using System;

public class P7_6
{
    public static string ReverseWords(string s)
    {
        char[] chars = s.ToCharArray();
        Reverse(chars, 0, chars.Length - 1);
        int start = -1;
        bool inWord = false;
        for (int i = 0; i < chars.Length; ++i)
        {
            if (!inWord && chars [i] != ' ')
            {
                inWord = true;
                start = i;
            } else if (chars [i] == ' ')
            {
                inWord = false;
                Reverse(chars, start, i - 1);
            }
        }
        if (inWord)
            Reverse(chars, start, chars.Length - 1);
        return new string(chars);
    }

    private static void Reverse(char[] chars, int startIndex, int endIndex)
    {
        while (startIndex < endIndex)
        {
            char tmp = chars [startIndex];
            chars [startIndex] = chars [endIndex];
            chars [endIndex] = tmp;
            ++startIndex; --endIndex;
        }
    }

    public static void RunTests()
    {
        Console.WriteLine(ReverseWords("The cat jumped over the dog and the moon"));
        Console.WriteLine(ReverseWords(""));
        Console.WriteLine(ReverseWords("a"));
        Console.WriteLine(ReverseWords("Sean John"));
    }
}
