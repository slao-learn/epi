using System;

public class P6_7
{
    private static int BuySellStock(int[] prices)
    {
        int minBuyPrice = prices[0];
        int maxReturn = 0;

        for (int i = 1; i < prices.Length; ++i)
        {
            if (prices[i] < minBuyPrice)
            {
                minBuyPrice = prices[i];
            }
            int current = prices[i] - minBuyPrice;
            if (current > maxReturn)
            {
                maxReturn = current;
            }
        }

        return maxReturn;
    }

    private static int Variant(int[] values)
    {
        int longest = 1;
        int current = 1;
        int currentVal = values[0];

        for (int i = 1; i < values.Length; ++i)
        {
            if (currentVal == values[i])
            {
                current++;
                longest = Math.Max(current, longest);
            } else
            {
                currentVal = values[i];
                current = 1;
            }
        }

        return longest;
    }

    public static void RunTests()
    {
        int[] prices = new int[] { 310, 315, 275, 295, 260, 270, 290, 230, 255, 250 };
        Console.WriteLine(BuySellStock(prices));

        int[] values = new int[] { 3, 4, 4, 6, 7, 3, 3, 3, 3, 0 };
        Console.WriteLine(Variant(values));
    }
}
