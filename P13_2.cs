using System;
using System.Collections.Generic;

namespace epi
{
    public class P13_2
    {
        public static bool CanBePalindrome(string s)
        {
            Dictionary<char, int> t = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; ++i)
            {
                if (t.ContainsKey(s [i]))
                    ++t [s [i]];
                else
                    t [s [i]] = 1;
            }

            bool hasOdd = false;
            foreach (int val in t.Values)
            {
                if (val % 2 == 1)
                {
                    if (!hasOdd)
                        hasOdd = true;
                    else
                        return false;
                }
            }
            return true;
        }

        public static void RunTests()
        {
            Console.WriteLine(CanBePalindrome("abc"));
            Console.WriteLine(CanBePalindrome("abccba"));
            Console.WriteLine(CanBePalindrome("abcabc"));
            Console.WriteLine(CanBePalindrome("edified"));
            Console.WriteLine(CanBePalindrome("edifiede"));
        }
    }
}

