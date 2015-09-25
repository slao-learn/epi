using System;
using System.Collections.Generic;

namespace epi
{
    public class P8_11
    {
        public class LinkedNode
        {
            public int data;
            public LinkedNode next;

            public LinkedNode(int data, LinkedNode next)
            {
                this.data = data;
                this.next = next;
            }
        }

        public static void EvenOddMerge(LinkedNode l)
        {
            LinkedNode last = l;
            while (last.next != null)
                last = last.next;
            LinkedNode t = last;
            LinkedNode h = l;

            while (h != last && h != null)
            {
                LinkedNode tmp = h.next;
                if (tmp.next != null)
                {
                    h.next = tmp.next;
                    t.next = tmp;
                    tmp.next = null;
                }
                t = t.next;
                h = h.next;
            }
        }

        public static void RunTests()
        {
            LinkedNode l = new LinkedNode(0, new LinkedNode(1, new LinkedNode(2, new LinkedNode(3, new LinkedNode(4, null)))));
            EvenOddMerge(l);
            Console.WriteLine(Print(l));

            l = new LinkedNode(0, null);
            EvenOddMerge(l);
            Console.WriteLine(Print(l));

            l = new LinkedNode(0, new LinkedNode(1, null));
            EvenOddMerge(l);
            Console.WriteLine(Print(l));

            l = new LinkedNode(0, new LinkedNode(1, new LinkedNode(2, null)));
            EvenOddMerge(l);
            Console.WriteLine(Print(l));
        }

        private static string Print(LinkedNode p)
        {
            if (p == null)
                return "null";
            string o = p.data.ToString();
            while (p.next != null)
            {
                o += " -> " + p.next.data;
                p = p.next;
            }
            return o;
        }

    }
}

