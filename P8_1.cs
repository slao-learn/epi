using System;

public class P8_1
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

    private class DoublyLinkedNode
    {
        public int data;
        public DoublyLinkedNode next;
        public DoublyLinkedNode prev;
        
        public DoublyLinkedNode(int data, DoublyLinkedNode next)
        {
            this.data = data;
            this.next = next;
            if (next != null)
            {
                this.next.prev = this;
            }
        }
    }

    private static LinkedNode Merge(LinkedNode l1, LinkedNode l2)
    {
        LinkedNode head = null;
        LinkedNode l1p = l1, l2p = l2;
        if (l1.data < l2.data)
        {
            head = l1;
            l1p = l1.next;
        } else
        {
            head = l2;
            l2p = l2.next;
        }
        LinkedNode cur = head;

        while (l1p != null && l2p != null)
        {
            if (l1p.data < l2p.data)
            {
                cur.next = l1p;
                l1p = l1p.next;
            } else
            {
                cur.next = l2p;
                l2p = l2p.next;
            }
            cur = cur.next;
        }
        cur.next = (l1p != null ? l1p : l2p);
        return head;
    }

    private static DoublyLinkedNode Merge(DoublyLinkedNode l1, DoublyLinkedNode l2)
    {
        DoublyLinkedNode head = null;
        DoublyLinkedNode l1p = l1, l2p = l2;
        if (l1.data < l2.data)
        {
            head = l1;
            l1p = l1.next;
            l1.prev = head;
        } else
        {
            head = l2;
            l2p = l2.next;
            l2.prev = head;
        }
        head.prev = null;
        DoublyLinkedNode cur = head;
        
        while (l1p != null && l2p != null)
        {
            if (l1p.data < l2p.data)
            {
                cur.next = l1p;
                l1p.prev = cur;
                l1p = l1p.next;
            } else
            {
                cur.next = l2p;
                l2p.prev = cur;
                l2p = l2p.next;
            }
            cur = cur.next;
        }

        cur.next = (l1p != null ? l1p : l2p);
        if (cur.next != null)
        {
            cur.next.prev = cur;
        }

        return head;

    }

    public static void RunTests()
    {
        LinkedNode a = new LinkedNode(3, new LinkedNode(5, new LinkedNode(7, null)));
        Console.WriteLine("a = " + Print(a));
        LinkedNode b = new LinkedNode(1, new LinkedNode(2, new LinkedNode(5, new LinkedNode(8, null))));
        Console.WriteLine("b = " + Print(b));
        LinkedNode c = Merge(a, b);
        Console.WriteLine("c = " + Print(c));

        DoublyLinkedNode d = new DoublyLinkedNode(3, new DoublyLinkedNode(5, new DoublyLinkedNode(7, null)));
        Console.WriteLine("d = " + Print(d));
        DoublyLinkedNode e = new DoublyLinkedNode(1, new DoublyLinkedNode(2, new DoublyLinkedNode(5, new DoublyLinkedNode(8, null))));
        Console.WriteLine("e = " + Print(e));
        DoublyLinkedNode f = Merge(d, e);
        Console.WriteLine("f = " + Print(f));
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

    private static string Print(DoublyLinkedNode p)
    {
        string o = "f: " + p.data.ToString();
        while (p.next != null)
        {
            o += " -> " + p.next.data;
            p = p.next;
        }
        o += ',' + " b: " + p.data.ToString();
        while (p.prev != null)
        {
            o += " -> " + p.prev.data;
            p = p.prev;
        }
        return o;
    }
}
