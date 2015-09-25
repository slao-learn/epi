using System;

namespace epi
{
    public class P5_11
    {
        public class Rect
        {
            public int x, y, width, height;
        }

        public static Rect GetIntersect(Rect r1, Rect r2)
        {
            Rect result = null;
            if (IsIntersect(r1, r2))
            {
                result = new Rect();
                result.x = Math.Max(r1.x, r2.x);
                result.y = Math.Max(r1.y, r2.y);
                result.width = Math.Min(r1.x + r1.width, r2.x + r2.width) - Math.Max(r1.x, r2.x);
                result.width = Math.Min(r1.y + r1.height, r2.y + r2.height) - Math.Max(r1.y, r2.y);
            }
            return result;
        }

        private static bool IsIntersect(Rect r1, Rect r2)
        {
            return (r1.x <= r2.x + r2.width && r1.x + r1.width >= r2.x &&
                    r1.y <= r2.y + r2.height && r1.y + r1.height >= r2.y);
        }
    }
}

