using System;
using System.Collections.Generic;

public class P15_1
{
    private class QueueEntry<T>
    {
        public BSTNode<T> node;
        public T lowerBound, higherBound;

        public QueueEntry(BSTNode<T> node, T lower, T higher)
        {
            this.node = node;
            lowerBound = lower;
            higherBound = higher;
        }
    }

    private class BSTNode<T>
    {
        public T data;
        public BSTNode<T> left;
        public BSTNode<T> right;

        public BSTNode(T data, BSTNode<T> left, BSTNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        public static bool IsBst(BSTNode<int> tree)
        {
            return AreKeysInRange(tree, int.MinValue, int.MaxValue);
        }

        private static bool AreKeysInRange(BSTNode<int> tree, int low, int high)
        {
            if (tree == null)
                return true;
            else if (tree.data < low || tree.data > high)
                return false;

            return AreKeysInRange(tree.left, low, tree.data) &&
                   AreKeysInRange(tree.right, tree.data, high);
        }

        public static bool IsBstBfs(BSTNode<int> tree)
        {
            Queue<QueueEntry<int>> queue = new Queue<QueueEntry<int>>();
            queue.Enqueue(new QueueEntry<int>(tree, int.MinValue, int.MaxValue));

            while (queue.Count > 0)
            {
                QueueEntry<int> entry = queue.Dequeue();
                if (entry.node.data < entry.lowerBound || entry.node.data > entry.higherBound)
                    return false;

                if (entry.node.left != null)
                    queue.Enqueue(new QueueEntry<int>(entry.node.left, entry.lowerBound, entry.node.data));

                if (entry.node.right != null)
                    queue.Enqueue(new QueueEntry<int>(entry.node.right, entry.node.data, entry.higherBound));
            }

            return true;
        }
    }

}
