using System;

public class P5_1 : Problem
{
    private static readonly short[] precomputed_parity;

    static P5_1()
    {
        int numItems = (int)Math.Pow(2, 16);
        precomputed_parity = new short[numItems];
        for (int i = 0; i < numItems; ++i)
        {
            precomputed_parity[i] = BruteParity((ulong)i);
        }
    }

    public static short BruteParity(ulong input)
    {
        short result = 0;
        while (input > 0)
        {
            result += (short)(input & 1);
            input >>= 1;
        }
        return (short)(result % 2);
    }

    public static short EraseLowestBitParity(ulong input)
    {
        short parity = 0;
        while (input != 0)
        {
            parity ^= 1;
            input &= (input - 1);
        }
        return parity;
    }

    public static short CachedParity(ulong input)
    {
        const ulong mask = 0xFFFF;
        return (short)
            (precomputed_parity[input & mask] ^
                precomputed_parity[(input >> 16) & mask] ^
                precomputed_parity[(input >> 32) & mask] ^
                precomputed_parity[(input >> 48) & mask]);
    }

    public static short XorParity(ulong input)
    {
        input ^= input >> 32;
        input ^= input >> 16;
        input ^= input >> 8;
        input ^= input >> 4;
        input ^= input >> 2;
        input ^= input >> 1;
        return (short)(input & 1);
    }

    public static void RunTests()
    {
        Console.WriteLine(Problem.GetCurrentMethod());
        Console.WriteLine();
        
        // Time complexity = O(n) where n is the width of the input value
        // Space complexity = O(1)
        Console.WriteLine("Brute Force Solution");
        PrintTime(() => { Console.WriteLine("Parity of 0 = {0}", P5_1.BruteParity(0)); });
        PrintTime(() => { Console.WriteLine("Parity of 1 = {0}", P5_1.BruteParity(1)); });
        PrintTime(() => { Console.WriteLine("Parity of 2 = {0}", P5_1.BruteParity(2)); });
        PrintTime(() => { Console.WriteLine("Parity of 3 = {0}", P5_1.BruteParity(3)); });
        PrintTime(() => { Console.WriteLine("Parity of 13 = {0}", P5_1.BruteParity(13)); });
        PrintTime(() => { Console.WriteLine("Parity of 255 = {0}", P5_1.BruteParity(255)); });
        PrintTime(() => { Console.WriteLine("Parity of 13490 = {0}", P5_1.BruteParity(13490)); });
        Console.WriteLine();
        
        // Time complexity = O(s) where s is the number of 1 bits in the input
        // Space complexity = O(1)
        Console.WriteLine("Erase Last 1 Bit Solution");
        Console.WriteLine("Parity of 0 = {0}", P5_1.EraseLowestBitParity(0));
        Console.WriteLine("Parity of 1 = {0}", P5_1.EraseLowestBitParity(1));
        Console.WriteLine("Parity of 2 = {0}", P5_1.EraseLowestBitParity(2));
        Console.WriteLine("Parity of 3 = {0}", P5_1.EraseLowestBitParity(3));
        Console.WriteLine("Parity of 13 = {0}", P5_1.EraseLowestBitParity(13));
        Console.WriteLine("Parity of 255 = {0}", P5_1.EraseLowestBitParity(255));
        Console.WriteLine();
        
        // Time complexity = O(n/L) where L is the size of the cache
        // Space complexity = O(L)
        Console.WriteLine("Cached Solution");
        Console.WriteLine("Parity of 0 = {0}", P5_1.CachedParity(0));
        Console.WriteLine("Parity of 1 = {0}", P5_1.CachedParity(1));
        Console.WriteLine("Parity of 2 = {0}", P5_1.CachedParity(2));
        Console.WriteLine("Parity of 3 = {0}", P5_1.CachedParity(3));
        Console.WriteLine("Parity of 13 = {0}", P5_1.CachedParity(13));
        Console.WriteLine("Parity of 255 = {0}", P5_1.CachedParity(255));
        Console.WriteLine();
        
        // Time complexity = O(log n)
        // Space complexity = O(1)
        Console.WriteLine("XOR Solution");
        PrintTime(() => { Console.WriteLine("Parity of 0 = {0}", P5_1.XorParity(0)); });
        PrintTime(() => { Console.WriteLine("Parity of 1 = {0}", P5_1.XorParity(1)); });
        PrintTime(() => { Console.WriteLine("Parity of 2 = {0}", P5_1.XorParity(2)); });
        PrintTime(() => { Console.WriteLine("Parity of 3 = {0}", P5_1.XorParity(3)); });
        PrintTime(() => { Console.WriteLine("Parity of 13 = {0}", P5_1.XorParity(13)); });
        PrintTime(() => { Console.WriteLine("Parity of 255 = {0}", P5_1.XorParity(255)); });
        PrintTime(() => { Console.WriteLine("Parity of 13490 = {0}", P5_1.XorParity(13490)); });
    }
}
