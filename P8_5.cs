using System;

public class P8_5
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

    public static LinkedNode CommonNode(LinkedNode a, LinkedNode b)
    {
        int aLength = 0, bLength = 0;
        LinkedNode aIter = a, bIter = b;
        while (aIter != null)
        {
            aLength++;
            aIter = aIter.next;
        }
        while (bIter != null)
        {
            bLength++;
            bIter = bIter.next;
        }
        if (aLength < bLength)
        {
            aIter = b;
            bIter = a;
        } else
        {
            aIter = a;
            bIter = b;
        }
        for (int i = 0; i < Math.Abs(aLength - bLength); ++i)
        {
            aIter = aIter.next;
        }
        while (aIter != bIter && aIter != null && bIter != null)
        {
            aIter = aIter.next;
            bIter = bIter.next;
        }
        return aIter;
    }

    public static void RunTests()
    {
        LinkedNode tail = new LinkedNode(6, new LinkedNode(7, new LinkedNode(8, new LinkedNode(9, null))));
        LinkedNode a = new LinkedNode(1, new LinkedNode(3, new LinkedNode(10, tail)));
        LinkedNode b = new LinkedNode(2, new LinkedNode(4, new LinkedNode(5, tail)));
        Console.WriteLine(Print(CommonNode(a, b)));

        a = new LinkedNode(1, new LinkedNode(3, new LinkedNode(10, null)));
        b = new LinkedNode(2, new LinkedNode(4, new LinkedNode(5, null)));
        Console.WriteLine(Print(CommonNode(a, b)));
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
