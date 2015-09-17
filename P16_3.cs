using System;
using System.Collections.Generic;

namespace epi
{
    public class P16_3
    {
        public static List<List<int>> GetPermutations(List<int> arr)
        {
            List<List<int>> list = new List<List<int>>();
            GetPermutations(0, arr, list);
            return list;
        }

        private static void GetPermutations(int i, List<int> arr, List<List<int>> list)
        {
            if (i == arr.Count)
            {
                list.Add(new List<int>(arr));
                return;
            }
            for (int j = i; j < arr.Count; ++j)
            {
                Swap(arr, i, j);
                GetPermutations(i + 1, arr, list);
                Swap(arr, i, j);
            }
        }

        private static void Swap(List<int> arr, int i, int j)
        {
            int tmp = arr [i];
            arr [i] = arr [j];
            arr [j] = tmp;
        }

        public static void RunTests()
        {
            var list = GetPermutations(new List<int>() { 1, 2, 3, 4 });
            Print(list);
        }

        private static void Print(List<List<int>> list)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                List<int> sublist = list [i];
                for (int j = 0; j < sublist.Count; ++j)
                {
                    Console.Write(sublist [j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

