using System;

public class P7_4
{
    public static void ReplaceRemove(char[] s, int len)
    {
        int offset = 0;
        for (int i = 0; i < len; ++i)
        {
            if (s[i] == 'a')
                offset++;
            else if (s[i] == 'b')
                offset--;
        }

        // remove
        int tail = 0;
        for (int i = 0, j = 0; i < len; ++i)
        {
            if (s[i] != 'b')
            {
                tail = j;
                s[j++] = s[i];
            }
        }

        // replace
        for (int i = tail, j = len - 1 + offset; i >= 0; --i)
        {
            if (s[i] == 'a')
            {
                s[j--] = 'd';
                s[j--] = 'd';
            } else
            {
                s[j--] = s[i];
            }
        }
    }

    public static void RunTests()
    {
        string s = "badboy";
        char[] c = s.ToCharArray();
        ReplaceRemove(c, s.Length);
        Console.WriteLine(new String(c));

        s = "paper napkin";
        c = new char[s.Length + 2];
        for (int i = 0; i < s.Length; ++i)
        {
            c[i] = s[i];
        }
        ReplaceRemove(c, s.Length);
        Console.WriteLine(new String(c));
    }
}

