using System;

public class P8_2
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

    private static LinkedNode Reverse(LinkedNode l)
    {
        if (l.next == null)
            return l;

        LinkedNode c = l.next, n = l.next.next, t = null;
        l.next = null;
        c.next = l;
        while (n != null)
        {
            t = n.next;
            n.next = c;
            c = n;
            n = t;
        }
        return c;
    }

    public static void RunTests()
    {
        LinkedNode a = new LinkedNode(3, new LinkedNode(5, new LinkedNode(7, null)));
        Console.WriteLine("a = " + Print(a));
        LinkedNode b = new LinkedNode(1, new LinkedNode(2, new LinkedNode(5, new LinkedNode(8, null))));
        Console.WriteLine("b = " + Print(b));
        LinkedNode c = Reverse(a);
        Console.WriteLine("c = " + Print(c));        
        c = Reverse(b);
        Console.WriteLine("c = " + Print(c));
        Console.WriteLine("c = " + Print(Reverse(new LinkedNode(4, null))));
    }
    
    private static string Print(LinkedNode p)
    {
        string o = p.data.ToString();
        while (p.next != null)
        {
            o += " -> " + p.next.data;
            p = p.next;
        }
        return o;
    }    
}
