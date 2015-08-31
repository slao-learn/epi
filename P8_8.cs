using System;

public class P8_8
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

    public static LinkedNode DeleteKth(LinkedNode l, int k)
    {
        LinkedNode result = null;
        LinkedNode t = l;
        while (k >= 0 && t != null)
        {
            t = t.next;
            --k;
        }
        while (t != null)
        {
            t = t.next;
            l = l.next;
        }
        result = l.next;
        l.next = l.next.next;
        return result;
    }

    public static void RunTests()
    {
        LinkedNode l = new LinkedNode(1, new LinkedNode(2, new LinkedNode(3, new LinkedNode(4, null))));
        Console.WriteLine(Print(l));
        Console.WriteLine(DeleteKth(l, 2).data);
        Console.WriteLine(Print(l));
        Console.WriteLine(DeleteKth(l, 1).data);
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