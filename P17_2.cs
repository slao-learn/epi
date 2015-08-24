using System;

public class P17_2
{
    public static int GetLevenshteinDistance(string a, string b)
    {
        if (a == b)
        {
            return 0;
        } else if (a.Length > b.Length)
        {
            string tmp = a;
            a = b;
            b = tmp;
        }

        int dist = a.Length + b.Length;
        if (a.Length < b.Length)
        {
            dist = 1 + GetLevenshteinDistance(a, b.Substring(1));
        }
        if (a.Length > 0 && b.Length > 0)
        {
            int inplace = (a[0] != b[0] ? 1 : 0) + GetLevenshteinDistance(a.Substring(1), b.Substring(1));
            if (inplace < dist)
                dist = inplace;
        }

        return dist;
    }

    private static int GetDistanceLessSpace(string a, string b)
    {
        if (a.Length < b.Length)
        {
            string tmp = a;
            a = b;
            b = tmp;
        }

        int[] d = new int[b.Length + 1];
        for (int i = 1; i <= a.Length; ++i)
        {
            int pre_i_1_j_1 = d[0];
            d[0] = i;
            for (int j = 1; j <= b.Length; ++j)
            {
                int pre_i_1_j = d[j];
                d[j] = (a[i - 1] == b[j - 1] ? pre_i_1_j_1
                        : 1 + Math.Min(pre_i_1_j_1, Math.Min(d[j - 1], d[j])));
                pre_i_1_j_1 = pre_i_1_j;
            }
        }
        return d[d.Length - 1];
    }

    public static void RunTests()
    {
        Console.WriteLine(GetLevenshteinDistance("bob", "bob"));
        Console.WriteLine(GetLevenshteinDistance("bob", "bib"));
        Console.WriteLine(GetLevenshteinDistance("apple", "appiel"));
        Console.WriteLine(GetLevenshteinDistance("apple", "appie"));
        Console.WriteLine(GetLevenshteinDistance("coo", "tyu"));
        Console.WriteLine("Less Space...");
        Console.WriteLine(GetDistanceLessSpace("bob", "bob"));
        Console.WriteLine(GetDistanceLessSpace("bob", "bib"));
        Console.WriteLine(GetDistanceLessSpace("apple", "appiel"));
        Console.WriteLine(GetDistanceLessSpace("apple", "appie"));
        Console.WriteLine(GetDistanceLessSpace("coo", "tyu"));

    }
}

