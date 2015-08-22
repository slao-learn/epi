using System;

public class P8_4
{
    private class LinkedNode
    {
        public int data;
        public LinkedNode next;
        
        public LinkedNode(int data, LinkedNode next)
        {
            this.data = data;
            this.next = next;
        }
    }
    
    private static LinkedNode TestCycle(LinkedNode l)
    {
        if (l.next == null)
            return null;

        LinkedNode a = l, b = l;
        while (b != null && b.next != null)
        {
            a = a.next;
            b = b.next.next;

            if (a == b)
            {
                b = l;
                while (a != b)
                {
                    a = a.next;
                    b = b.next;
                }
                return a;
            }
        }
        return null;
    }
    
    public static void RunTests()
    {
        LinkedNode a = new LinkedNode(3, new LinkedNode(5, new LinkedNode(7, null)));
        Console.WriteLine("a = " + Print(a));
        Console.WriteLine(Print(TestCycle(a)));

        // 1 -> 2 -> 5 -> 8 -> 2 -> 5 -> ... looping
        LinkedNode d = new LinkedNode(2, null);
        LinkedNode c = new LinkedNode(8, null);
        d.next = new LinkedNode(5, c);
        LinkedNode b = new LinkedNode(1, d);
        c.next = d;
        Console.WriteLine(TestCycle(b).data);

        Console.WriteLine(Print(TestCycle(new LinkedNode(1, null))));
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
