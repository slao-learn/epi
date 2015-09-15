using System;

namespace epi
{
    public class P11_3
    {
        public static int[] Sort(int[] arr, int k)
        {
            int[] result = new int[arr.Length];
            int resultIndex = 0;
            BinaryHeap<int> heap = new BinaryHeap<int>();

            // add k items into heap
            for (int i = 0; i < k && i < arr.Length; ++i)
            {
                heap.Insert(arr [i]); 
            }

            // add and remove
            for (int i = k; i < arr.Length; ++i)
            {
                heap.Insert(arr [i]);
                result [resultIndex++] = heap.RemoveRoot();
            }

            // remove remaining
            while (heap.Count > 0)
                result [resultIndex++] = heap.RemoveRoot();

            return result;
        }

        public static void RunTests()
        {
            Print(Sort(new int[] { 1, 3, 2, 5, 4, 6, 8, 7 }, 1));
            Print(Sort(new int[] { 5, 3, 1, 2, 4, 8, 6, 7 }, 4));
        }

        private static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write(arr [i] + " ");
            }
            Console.WriteLine();
        }
    }
}

