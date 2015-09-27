using System;
using System.ComponentModel;

namespace epi
{
    public static class Util
    {
        public static void Print(int[] a)
        {
            foreach (int i in a)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine ();
        }

        public static void Print(float[] a)
        {
            foreach (var i in a)
            {
                Console.Write(i.ToString("0.###") + " ");
            }
            Console.WriteLine ();
        }
    }
}