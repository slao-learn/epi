using System;
using System.Collections.Generic;

public class P10_4
{
    private class BinaryTreeNode<T>
    {
        public T data;
        public BinaryTreeNode<T> left, right;
        public BinaryTreeNode<T> parent;
        
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;

            if (this.left != null)
            {
                left.parent = this;
            }

            if (this.right != null)
            {
                right.parent = this;
            }
        }
        
        public BinaryTreeNode(T data) : this(data, null, null)
        {
        }

        public BinaryTreeNode<T> GetLca(BinaryTreeNode<T> a, BinaryTreeNode<T> b)
        {
            int aHeight = 0, bHeight = 0;
            BinaryTreeNode<T> aTmp = a, bTmp = b;

            // calculate depths
            while (aTmp != null)
            {
                aTmp = aTmp.parent;
                aHeight++;
            }
            while (bTmp != null)
            {
                bTmp = bTmp.parent;
                bHeight++;
            }

            // Move deeper node up to shallower node
            for (int i = aHeight; i > bHeight; --i)
            {
                aTmp = aTmp.parent;
            }
            for (int i = bHeight; i > aHeight; --i)
            {
                bTmp = bTmp.parent;
            }

            // Move up each until LCA found
            while (aTmp != bTmp)
            {
                aTmp = aTmp.parent;
                bTmp = bTmp.parent;
            }
            return aTmp;
        }
    }
    
    public static void RunTests()
    {
//        BinaryTreeNode<int> t = new BinaryTreeNode<int>(1,
//                                                        new BinaryTreeNode<int>(2, new BinaryTreeNode<int>(3), new BinaryTreeNode<int>(6)),
//                                                        new BinaryTreeNode<int>(4, new BinaryTreeNode<int>(5), null));
//        BinaryTreeNode<int> u = new BinaryTreeNode<int>(1,
//                                                        new BinaryTreeNode<int>(2, new BinaryTreeNode<int>(3, new BinaryTreeNode<int>(4), null), null),
//                                                        new BinaryTreeNode<int>(4));
//
//        // figure 10.1
//        BinaryTreeNode<int> v = new BinaryTreeNode<int>(
//            314,
//            new BinaryTreeNode<int>(6,
//                                new BinaryTreeNode<int>(271,
//                                new BinaryTreeNode<int>(28), new BinaryTreeNode<int>(0)),
//                                new BinaryTreeNode<int>(561,
//                                null, new BinaryTreeNode<int>(3,
//                                      new BinaryTreeNode<int>(17), null))),
//            new BinaryTreeNode<int>(6,
//                                new BinaryTreeNode<int>(2,
//                                null, new BinaryTreeNode<int>(1,
//                                      new BinaryTreeNode<int>(401,
//                                null, new BinaryTreeNode<int>(641)),
//                                      new BinaryTreeNode<int>(257))),
//                                new BinaryTreeNode<int>(271,
//                                null, new BinaryTreeNode<int>(28))));
    }
}