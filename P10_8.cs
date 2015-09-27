using System;
using System.Collections.Generic;

namespace epi
{
    public class P10_8
    {
        public static List<int> GetInorder(BTNode t)
        {
            List<int> result = new List<int>();
            BTNode prev = null;
            BTNode current = t;
            while (current != null)
            {
                BTNode next = null;
                if (prev == current.left || prev == current.parent && current.left == null)
                {
                    result.Add(current.data);
                }
                if (prev == current.parent && current.left != null)
                {
                    next = current.left;
                } else
                {
                    next = prev != current.right && current.right != null ? current.right : current.parent;
                }
                prev = current;
                current = next;
            }
            return result;
        }

        public static void RunTests()
        {
            BTNode t = BTNode.CreateMinimalBST(new int[]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7
            });
            Print(GetInorder(t));
            Print(GetInorder(BTNode.CreateMinimalBST(new int[]
            {
                1
            })));
            Print(GetInorder(BTNode.CreateMinimalBST(new int[]
            {
                1, 2
            })));
        }

        private static void Print(List<int> l)
        {
            foreach (int v in l)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();
        }

    }
}

