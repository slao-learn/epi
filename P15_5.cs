using System;

namespace epi
{
    public class P15_5
    {
        public class BSTNode
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
        }

        public static BSTNode GetLCA(BSTNode root, BSTNode a, BSTNode b)
        {
            int min = Math.Min(a.data, b.data);
            int max = Math.Max(a.data, b.data);
            BSTNode lca = root;
            while (lca.data < min || lca.data > max)
            {
                while (lca.data > max)
                    lca = lca.left;
                while (lca.data < min)
                    lca = lca.right;
            }
            return lca;
        }

        public static void RunTests()
        {
            BSTNode a = new BSTNode(3, 2, 5);
            BSTNode b = new BSTNode(17, new BSTNode(13), null);
            BSTNode t = new BSTNode(19,
                new BSTNode(7, a, new BSTNode(11, null, b)),
                new BSTNode(43,
                    new BSTNode(23, null, new BSTNode(37, new BSTNode(29, null, new BSTNode(31)), new BSTNode(41))),
                    new BSTNode(47, null, new BSTNode(53))
                )
            );
            Console.WriteLine(GetLCA(t, a, b).data);
        }

    }
}

