using System;
using System.Collections.Generic;

namespace epi
{
    public class P14_5
    {
        // keep track of counts of start endpoints and end endpoints for each time slot
        private class Count
        {
            public int start;
            public int end;
        }

        public static int GetMaxEventOverlap(List<KeyValuePair<int, int>> events)
        {
            // Populate list of event endpoints
            Count[] counts = new Count[24];
            for (int i = 0; i < events.Count; ++i)
            {
                int start = events [i].Key;
                int end = events [i].Value;
                if (counts [start] == null)
                    counts [start] = new Count();
                if (counts [end] == null)
                    counts [end] = new Count();
                ++counts [start].start;
                ++counts [end].end;
            }

            // Calculate max count
            int currentCount = 0, maxCount = 0;
            for (int i = 0; i < counts.Length; ++i)
            {
                if (counts [i] != null)
                {
                    currentCount += counts [i].start;
                    if (currentCount > maxCount)
                        maxCount = currentCount;
                    currentCount -= counts [i].end;
                }
            }

            return maxCount;
        }

        public static void RunTests()
        {
            List<KeyValuePair<int, int>> events = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(0, 1),
                new KeyValuePair<int, int>(1, 2)
            };
            Console.WriteLine(GetMaxEventOverlap(events));

            events = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(0, 1)
            };
            Console.WriteLine(GetMaxEventOverlap(events));

            events = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(1, 5),
                new KeyValuePair<int, int>(6, 10),
                new KeyValuePair<int, int>(11, 13),
                new KeyValuePair<int, int>(14, 15),
                new KeyValuePair<int, int>(2, 7),
                new KeyValuePair<int, int>(8, 9),
                new KeyValuePair<int, int>(12, 15),
                new KeyValuePair<int, int>(4, 5),
                new KeyValuePair<int, int>(9, 17)
            };
            Console.WriteLine(GetMaxEventOverlap(events));
        }
    }
}

