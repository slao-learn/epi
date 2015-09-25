using System;
using System.Text;

namespace epi
{
    public class P7_8
    {
        public static string LookAndSay(int n)
        {
            if (n < 1)
                return null;
            string s = "1";
            StringBuilder sb = new StringBuilder("1");
            for (int i = 2; i <= n; ++i)
            {
                s = Read(s);
                sb.Append(",").Append(s);
            }
            return sb.ToString();
        }

        private static string Read(string t)
        {
            StringBuilder sb = new StringBuilder();
            int c = 1;
            for (int i = 1; i < t.Length; ++i)
            {
                if (t [i - 1] == t [i])
                {
                    ++c;
                } else
                {
                    sb.Append(c).Append(t [i - 1]);
                    c = 1;
                }
            }
            sb.Append(c).Append(t [t.Length - 1]);
            return sb.ToString();
        }

        public static void RunTests()
        {
            Console.WriteLine(LookAndSay(1));
            Console.WriteLine(LookAndSay(8));
        }
    }
}

