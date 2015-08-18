using System.Collections.Generic;
using System;

public class P13_1
{
    public static List<List<string>> FindAnagrams(List<string> words)
    {
        List<List<string>> anagrams = new List<List<string>>();
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        for (int i = 0; i < words.Count; ++i)
        {
            char[] charArr = words[i].ToCharArray();
            Array.Sort(charArr);
            string key = new string(charArr);
            if (map.ContainsKey(key))
            {
                map[key].Add(words[i]);
            } else
            {
                map[key] = new List<string> { words[i] };
            }
        }

        foreach (var pair in map)
        {
            if (pair.Value.Count >= 2)
            {
                anagrams.Add(pair.Value);
            }
        }

        return anagrams;
    }

    public static void RunTests()
    {
        List<string> words = new List<string> { "debitcard", "elvis", "silent", "badcredit", "lives", "freedom", "listen", "levis" };
        List<List<string>> anagrams = FindAnagrams(words);
        for (int i = 0; i < anagrams.Count; ++i)
        {
            for (int j = 0; j < anagrams[i].Count; ++j)
            {
                Console.Write(anagrams[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}