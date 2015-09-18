using System;
using System.Collections.Generic;

namespace epi
{
    public class P17_6
    {
        public class Item
        {
            public int value;
            public int weight;
            public Item(int val, int w)
            {
                value = val;
                weight = w;
            }
        }

        public static int Knapsack(int w, List<Item> items)
        {
            int[] V = new int[w + 1];
            for (int i = 0; i < items.Count; ++i)
            {
                Item item = items [i];
                for (int j = w; j >= item.weight; --j)
                {
                    V [j] = Math.Max(V [j], V [j - item.weight] + item.value);
                }
            }
            return V [w];
        }

        public static void RunTests()
        {
            List<Item> l = new List<Item>();
            Add(l, 65, 20);
            Add(l, 35, 8);
            Add(l, 245, 60);
            Add(l, 195, 55);
            Add(l, 65, 40);
            Add(l, 150, 70);
            Add(l, 275, 85);
            Add(l, 155, 25);
            Add(l, 120, 30);
            Add(l, 320, 65);
            Add(l, 75, 75);
            Add(l, 40, 10);
            Add(l, 200, 95);
            Add(l, 100, 50);
            Add(l, 220, 40);
            Add(l, 99, 10);
            Console.WriteLine(Knapsack(130, l));
        }

        private static void Add(List<Item> items, int value, int weight)
        {
            items.Add(new Item(value, weight));
        }
    }
}

