using System;
using System.Collections.Generic;

namespace epi
{
    public class P10_10
    {
        public class BinaryTreeNode
        {
            public char data;
            public BinaryTreeNode left, right;

            public BinaryTreeNode(char data, BinaryTreeNode left, BinaryTreeNode right)
            {
                this.data = data;
                this.left = left;
                this.right = right;
            }

            public BinaryTreeNode(char data) : this(data, null, null)
            {
            }

            public BinaryTreeNode(char data, BinaryTreeNode left) : this(data, left, null)
            {
            }
        }

        private static BinaryTreeNode GenerateTree(char[] inorder, char[] preorder)
        {
            Dictionary<char, int> loc = new Dictionary<char, int>();
            for (int i = 0; i < inorder.Length; ++i)
            {
                loc [inorder [i]] = i;
            }

            return GenerateTreeHelper(inorder, 0, inorder.Length - 1, preorder, 0, preorder.Length - 1, loc);
        }

        private static BinaryTreeNode GenerateTreeHelper(char[] inorder, int iStart, int iEnd, char[] preorder, int pStart, int pEnd, Dictionary<char, int> loc)
        {
//            Console.WriteLine("inorder istart={0}, iend={1}, pstart={2}, pstart={3}", iStart, iEnd, pStart, pEnd);
            if (iStart > iEnd || pStart > pEnd)
                return null;

            int rootIndex = loc [preorder [pStart]];

//            Console.WriteLine("create new head " + preorder [pStart]);

            return new BinaryTreeNode(preorder [pStart],
                GenerateTreeHelper(inorder, iStart, rootIndex - 1, preorder, pStart + 1, pStart + rootIndex - iStart, loc),
                GenerateTreeHelper(inorder, rootIndex + 1, iEnd, preorder, pStart + rootIndex - iStart + 1, pEnd, loc)
            );
        }

        public static void RunTests()
        {
            char[] inorder = new char[]
            {
                'F', 'B', 'A', 'E', 'H', 'C', 'D', 'I', 'G'
            };
            char[] preorder = new char[]
            {
                'H', 'B', 'F', 'E', 'A', 'C', 'D', 'G', 'I'
            };
            BinaryTreeNode tree = GenerateTree(inorder, preorder);
            Console.WriteLine(Print(tree));
        }

        private static string Print(BinaryTreeNode t)
        {
            if (t == null)
                return "null";
            string result = t.data.ToString();
            result += "\n|\\\n" + Print(t.left) + " " + Print(t.right) + '\n';
            return result;
        }
    }
}
