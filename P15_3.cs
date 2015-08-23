using System;
using System.Collections.Generic;

public class P15_3
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

        public static BSTNode FindFirstGreaterThanK(BSTNode n, int k)
        {
            BSTNode result = null;
            while (n != null)
            {
                if (n.data > k)
                {
                    if (result == null || n.data < result.data)
                        result = n;
                    n = n.left;
                } else
                {
                    n = n.right;
                }
            }
            return result;
        }
    }

    public static void RunTests()
    {
        BSTNode t = new BSTNode(19,
                                    new BSTNode(7, new BSTNode(3, 2, 5), new BSTNode(11, null, new BSTNode(17, new BSTNode(13), null))),
                                    new BSTNode(43,
                                        new BSTNode(23, null, new BSTNode(37, new BSTNode(29, null, new BSTNode(31)), new BSTNode(41))),
                                        new BSTNode(47, null, new BSTNode(53))
                                    )
                                );
        Console.WriteLine(BSTNode.FindFirstGreaterThanK(t, 23).data);
        Console.WriteLine(BSTNode.FindFirstGreaterThanK(t, 18).data);
        Console.WriteLine(BSTNode.FindFirstGreaterThanK(t, 55) == null);
        Console.WriteLine(BSTNode.FindFirstGreaterThanK(t, 52).data);
        Console.WriteLine(BSTNode.FindFirstGreaterThanK(t, 16).data);
        Console.WriteLine(BSTNode.FindFirstGreaterThanK(t, 17).data);
        Console.WriteLine(BSTNode.FindFirstGreaterThanK(t, 1).data);
    }

}
