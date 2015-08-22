using System;
using System.Collections.Generic;

public class P9_9
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

        public List<List<T>> GetDepthOrderKeys()
        {
            List<List<T>> list = new List<List<T>>();
            GetDepthOrderKeysHelper(list, this, 0);
            return list;
        }

        private void GetDepthOrderKeysHelper(List<List<T>> list, BinaryTreeNode<T> c, int depth)
        {
            if (c != null)
            {
                List<T> depthList = null;
                if (list.Count >= depth + 1)
                {
                    depthList = list[depth];
                    depthList.Add(c.data);
                } else
                {
                    depthList = new List<T>() { c.data };
                    list.Add(depthList);
                }

                GetDepthOrderKeysHelper(list, c.left, depth + 1);
                GetDepthOrderKeysHelper(list, c.right, depth + 1);
            }
        }
    }
    
    public static void RunTests()
    {
        BinaryTreeNode<int> t = new BinaryTreeNode<int>(1,
                                                        new BinaryTreeNode<int>(2, new BinaryTreeNode<int>(3), new BinaryTreeNode<int>(6)),
                                                        new BinaryTreeNode<int>(4, new BinaryTreeNode<int>(5), null));
        List<List<int>> depthOrder = t.GetDepthOrderKeys();
        foreach (List<int> l in depthOrder)
        {
            foreach(int k in l)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        BinaryTreeNode<int> u = new BinaryTreeNode<int>(1,
                                                        new BinaryTreeNode<int>(2, new BinaryTreeNode<int>(3, new BinaryTreeNode<int>(4), null), null),
                                                        new BinaryTreeNode<int>(4));
        depthOrder = u.GetDepthOrderKeys();
        foreach (List<int> l in depthOrder)
        {
            foreach(int k in l)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

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
        depthOrder = v.GetDepthOrderKeys();
        foreach (List<int> l in depthOrder)
        {
            foreach(int k in l)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

    }
}