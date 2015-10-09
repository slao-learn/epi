using System;

namespace epi
{
    public class P12_6
    {
        public enum Ordering
        {
            SMALLER,
            EQUAL,
            LARGER
        }

        public static double SquareRoot(double x)
        {
            double left, right;
            if (x >= 1.0)
            {
                left = 1.0;
                right = x;
            } else
            {
                left = 0;
                right = 1.0;
            }

            while (Compare(left, right) == Ordering.SMALLER)
            {
                double mid = left + (right - left) * 0.5;
                double squared = mid * mid;
                if (Compare(squared, x) == Ordering.EQUAL)
                {
                    return mid;
                } else if (Compare(squared, x) == Ordering.LARGER)
                {
                    right = mid;
                } else
                {
                    left = mid;
                }
            }
            return left;
        }

        private static Ordering Compare(double a, double b)
        {
            double epsilon = 0.000001;
            double diff = (a - b) / b;
            return diff < -epsilon ? Ordering.SMALLER : (diff > epsilon ? Ordering.LARGER : Ordering.EQUAL);
        }

        public static void RunTests()
        {
            Console.WriteLine(SquareRoot(1.0));
            Console.WriteLine(SquareRoot(0.25));
            Console.WriteLine(SquareRoot(9.0));
            Console.WriteLine(SquareRoot(9.5));
            Console.WriteLine(SquareRoot(16.5));
            Console.WriteLine(SquareRoot(100.000000));
            Console.WriteLine(SquareRoot(64));
        }
    }
}

