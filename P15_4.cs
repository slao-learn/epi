using System;
using System.Collections.Generic;

public class P15_4
{
    private class BSTNode
    {
        public int data;
        public BSTNode left;
        public BSTNode right;
        
        public BSTNode(int data, BSTNode left, BSTNode right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
        
        public BSTNode(int data) : this(data, null, null)
        {
        }
        
        public BSTNode(int data, int lData, int rData) : this(data, null, null)
        {
            this.left = new BSTNode(lData);
            this.right = new BSTNode(rData);
        }
        
        public static List<int> FindKLargestKeys(BSTNode n, int k)
        {
            if (n == null)
                return new List<int>();

            List<int> kLargest = FindKLargestKeys(n.right, k);
            if (kLargest.Count < k)
            {
                kLargest.Add(n.data);
                if (kLargest.Count < k)
                    kLargest.AddRange(FindKLargestKeys(n.left, k - kLargest.Count));
            }
            return kLargest;
        }
    }
    
    public static void RunTests()
    {
        BSTNode t = new BSTNode(19,
                                new BSTNode(7, new BSTNode(3, 2, 5), new BSTNode(11, null, new BSTNode(17, new BSTNode(13), null))),
                                new BSTNode(43,
                    new BSTNode(23, null, new BSTNode(37, new BSTNode(29, null, new BSTNode(31)), new BSTNode(41))),
                    new BSTNode(47, null, new BSTNode(53))));
        List<int> largest = BSTNode.FindKLargestKeys(t, 3);
        for (int i = 0; i < largest.Count; ++i)
        {
            Console.Write(largest[i] + " ");
        }
        Console.WriteLine();

        largest = BSTNode.FindKLargestKeys(t, 7);
        for (int i = 0; i < largest.Count; ++i)
        {
            Console.Write(largest[i] + " ");
        }

    }
    
}
