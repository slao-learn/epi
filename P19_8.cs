using System;
using System.Collections.Generic;

public class P19_8
{
    public static int GetProdSeqLength(List<string> d, string s, string t)
    {
        Queue<KeyValuePair<string, int>> q = new Queue<KeyValuePair<string, int>>();
        q.Enqueue(new KeyValuePair<string, int>(s, 1));
        d.Remove(s);
        while (q.Count > 0)
        {
            KeyValuePair<string, int> entry = q.Dequeue();

            if (entry.Key == t)
                return entry.Value;
            
            for (int i = d.Count - 1; i > 0; --i)
            {
                string compare = d [i];
                if (IsMatch(entry.Key, compare))
                {
                    if (compare == t)
                        return entry.Value + 1;
                    q.Enqueue(new KeyValuePair<string, int>(compare, entry.Value + 1));
                    d.Remove(compare);
                }
            }
        }
        return -1;
    }

    public static int GetProdSeqLength2(List<string> d, string s, string t)
    {
        Queue<KeyValuePair<string, int>> q = new Queue<KeyValuePair<string, int>>();
        q.Enqueue(new KeyValuePair<string, int>(s, 1));
        d.Remove(s);
        while (q.Count > 0)
        {
            KeyValuePair<string, int> entry = q.Dequeue();

            if (entry.Key == t)
                return entry.Value;

            char[] baseStr = entry.Key.ToCharArray();
            for (int i = 0; i < baseStr.Length; ++i)
            {
                for (int j = 0; j < 26; ++j)
                {
                    baseStr [i] = (char)((int)'a' + j);
                    string newStr = new string(baseStr);
                    if (d.Contains(newStr))
                    {
                        q.Enqueue(new KeyValuePair<string, int>(newStr, entry.Value + 1));
                        d.Remove(newStr);
                    }
                }
                baseStr [i] = entry.Key [i];
            }
        }
        return -1;
    }

    private static bool IsMatch(string a, string b)
    {
        if (a.Length != b.Length)
            return false;

        bool foundDiff = false;
        for (int i = 0; i < a.Length; ++i)
        {
            if (a[i] != b[i])
            {
                if (foundDiff)
                    return false;
                foundDiff = true;
            }
        }
        return foundDiff;
    }

    public static void RunTests()
    {
        List<string> d = new List<string>()
        {
            "bat",
            "cot",
            "dog",
            "dag",
            "dot",
            "cat"
        };
        Console.WriteLine(GetProdSeqLength(d, "cat", "dog"));


        d = new List<string>()
        {
            "bat",
            "cot",
            "dog",
            "dag",
            "dot",
            "cat"
        };
        Console.WriteLine(GetProdSeqLength(d, "cat", "dag"));

        d = new List<string>()
        {
            "bat",
            "cot",
            "dog",
            "dag",
            "dot",
            "cat"
        };
        Console.WriteLine(GetProdSeqLength2(d, "cat", "dog"));


        d = new List<string>()
        {
            "bat",
            "cot",
            "dog",
            "dag",
            "dot",
            "cat"
        };
        Console.WriteLine(GetProdSeqLength2(d, "cat", "dag"));

    }
}
