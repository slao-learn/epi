using System;
using System.Collections.Generic;

public class P10_1
{
    private class BinaryTreeNode<T>
    {
        public T data;
        public BinaryTreeNode<T> left, right;

        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        public BinaryTreeNode(T data) : this(data, null, null)
        {
        }

        public static bool IsBalanced(BinaryTreeNode<T> tree)
        {
            int height;
            return CheckBalanced(tree, out height);
        }

        private static bool CheckBalanced(BinaryTreeNode<T> tree, out int height)
        {
            if (tree == null)
            {
                height = -1;
                return true;
            }

            int leftHeight;
            if (!CheckBalanced(tree.left, out leftHeight))
            {
                height = 0;
                return false;
            }

            int rightHeight;
            if (!CheckBalanced(tree.right, out rightHeight))
            {
                height = 0;
                return false;
            }

            height = 1 + Math.Max(leftHeight, rightHeight);
            return (Math.Abs(leftHeight - rightHeight) <= 1);
        }

        // return the size of the largest subtree that is complete
        public static int LargestCompleteSubtreeSize(BinaryTreeNode<T> tree)
        {
            int height;
            bool perfect;
            IsComplete(tree, out height, out perfect);
            return height;
        }

        private static bool IsComplete(BinaryTreeNode<T> tree, out int height, out bool perfect)
        {
            if (tree == null)
            {
                height = 0;
                perfect = true;
                return true;
            }

            int leftHeight;
            bool leftPerfect;
            bool leftComplete = IsComplete(tree.left, out leftHeight, out leftPerfect);

            int rightHeight;
            bool rightPerfect;
            bool rightComplete = IsComplete(tree.right, out rightHeight, out rightPerfect);

            if (leftComplete && rightComplete &&
                ((leftPerfect && leftHeight == rightHeight) || (rightPerfect && leftHeight - 1 == rightHeight)))
            {
                perfect = leftPerfect && rightPerfect && leftHeight == rightHeight;
                height = 1 + leftHeight;
                return true;
            } else
            {
                height = Math.Max(leftHeight, rightHeight);
                perfect = false;
                return false;
            }
        }

        // return first node which is not k-balanced but all descendents are k-balanced
        public static BinaryTreeNode<T> GetNotKBalanced(BinaryTreeNode<T> tree, int k)
        {
            BinaryTreeNode<T> node;
            int size;
            CheckKBalanced(tree, k, out size, out node);
            return node;
        }

        private static bool CheckKBalanced(BinaryTreeNode<T> tree, int k, out int size, out BinaryTreeNode<T> node)
        {
            if (tree == null)
            {
                node = null;
                    size = 0;
                return true;
            }

            BinaryTreeNode<T> leftNode;
            int leftSize;
            bool leftKBalanced = CheckKBalanced(tree.left, k, out leftSize, out leftNode);

            BinaryTreeNode<T> rightNode;
            int rightSize;
            bool rightKBalanced = CheckKBalanced(tree.right, k, out rightSize, out rightNode);

            size = 1 + leftSize + rightSize;
            if (leftKBalanced && rightKBalanced)
            {
                if (Math.Abs(leftSize - rightSize) > k)
                {
                    node = tree;
                    return false;
                } else
                {
                    node = null;
                    return true;
                }
            }
            node = leftNode ?? rightNode;
            return false;
        }
    }

    public static void RunTests()
    {
        BinaryTreeNode<int> t = new BinaryTreeNode<int>(1,
                                                        new BinaryTreeNode<int>(2, new BinaryTreeNode<int>(3), new BinaryTreeNode<int>(6)),
                                                        new BinaryTreeNode<int>(4, new BinaryTreeNode<int>(5), null));
        BinaryTreeNode<int> u = new BinaryTreeNode<int>(1,
                                                        new BinaryTreeNode<int>(2, new BinaryTreeNode<int>(3, new BinaryTreeNode<int>(4), null), null),
                                                        new BinaryTreeNode<int>(4));
        Console.WriteLine(BinaryTreeNode<int>.IsBalanced(t));
        Console.WriteLine(BinaryTreeNode<int>.IsBalanced(u));

        Console.WriteLine(BinaryTreeNode<int>.LargestCompleteSubtreeSize(t));
        Console.WriteLine(BinaryTreeNode<int>.LargestCompleteSubtreeSize(u));

        // figure 10.1
        BinaryTreeNode<int> v = new BinaryTreeNode<int>(
            314,
            new BinaryTreeNode<int>(6,
                new BinaryTreeNode<int>(271,
                    new BinaryTreeNode<int>(28), new BinaryTreeNode<int>(0)),
                new BinaryTreeNode<int>(561,
                    null, new BinaryTreeNode<int>(3,
                        new BinaryTreeNode<int>(17), null))),
            new BinaryTreeNode<int>(6,
                new BinaryTreeNode<int>(2,
                    null, new BinaryTreeNode<int>(1,
                        new BinaryTreeNode<int>(401,
                            null, new BinaryTreeNode<int>(641)),
                        new BinaryTreeNode<int>(257))),
                new BinaryTreeNode<int>(271,
                    null, new BinaryTreeNode<int>(28))));
        BinaryTreeNode<int> match = BinaryTreeNode<int>.GetNotKBalanced(v, 3);
        Console.WriteLine(match.data);
    }
}