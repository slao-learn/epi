using System;

namespace epi
{
    public class P10_2
    {
        public class BinaryTreeNode
        {
            public int data;
            public BinaryTreeNode left, right;

            public BinaryTreeNode(int data, BinaryTreeNode left, BinaryTreeNode right)
            {
                this.data = data;
                this.left = left;
                this.right = right;
            }

            public BinaryTreeNode(int data) : this(data, null, null)
            {
            }

            public BinaryTreeNode(int data, BinaryTreeNode left) : this(data, left, null)
            {
            }
        }

        public static bool IsSymmetric(BinaryTreeNode tree)
        {
            return IsSymmetricHelper(tree.left, tree.right);
        }

        private static bool IsSymmetricHelper(BinaryTreeNode a, BinaryTreeNode b)
        {
            if (a == null)
                return b == null;
            if (b == null)
                return false;

            return (a.data == b.data && 
                IsSymmetricHelper(a.left, b.right) && IsSymmetricHelper(a.right, b.left));
        }

        public static void RunTests()
        {
            BinaryTreeNode tree = new BinaryTreeNode(314,
                                      new BinaryTreeNode(6, null, new BinaryTreeNode(2, null, new BinaryTreeNode(3))),
                                      new BinaryTreeNode(6, new BinaryTreeNode(2, new BinaryTreeNode(3), null), null));
            Console.WriteLine(IsSymmetric(tree));

            tree = new BinaryTreeNode(314,
                new BinaryTreeNode(6, null, new BinaryTreeNode(561, null, new BinaryTreeNode(3))),
                new BinaryTreeNode(6, new BinaryTreeNode(2, new BinaryTreeNode(1), null), null));
            Console.WriteLine(IsSymmetric(tree));

            tree = new BinaryTreeNode(314,
                new BinaryTreeNode(6, null, new BinaryTreeNode(2, null, new BinaryTreeNode(3))),
                new BinaryTreeNode(6, new BinaryTreeNode(2), null));
            Console.WriteLine(IsSymmetric(tree));

            Console.WriteLine(IsSymmetric(new BinaryTreeNode(10)));
        }
    }
}
