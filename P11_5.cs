using System;
using System.Collections.Generic;
using System.Collections;

namespace epi
{
    public class P11_5
    {
        private class MaxSort : IComparer<int>
        {
            #region IComparer implementation
            public int Compare(int x, int y)
            {
                if (x < y)
                    return 1;
                if (x > y)
                    return -1;
                return 0;
            }
            #endregion
        }

        public static float[] GetRunningMedians(int[] a)
        {
            float[] medians = new float[a.Length];
            BinaryHeap<int> maxHeap = new BinaryHeap<int>(new MaxSort());
            BinaryHeap<int> minHeap = new BinaryHeap<int>();

            for (int i = 0; i < a.Length; ++i)
            {
                int val = a [i];
                if (minHeap.Count == 0)
                    minHeap.Insert(val);
                else
                {
                    if (val > minHeap.Peek())
                        minHeap.Insert(val);
                    else
                        maxHeap.Insert(val);
                }

                if (minHeap.Count > maxHeap.Count + 1)
                    maxHeap.Insert(minHeap.RemoveRoot());
                else if (maxHeap.Count > minHeap.Count)
                    minHeap.Insert(maxHeap.RemoveRoot());
                
                medians [i] = (minHeap.Count > maxHeap.Count ? (float)minHeap.Peek() : ((float)(maxHeap.Peek() + minHeap.Peek()) / 2f));
            }

            return medians;
        }

        public static void RunTests()
        {
            Util.Print(GetRunningMedians(new int[]
            {
                1,
                0,
                3,
                5,
                2,
                0 ,
                1
            }));
        }
    }
}

