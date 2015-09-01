using System;

public class P9_10
{
    public class MyQueue
    {
        private const int SCALE_FACTOR = 2;

        int[] a;
        int startIndex = 0, endIndex = 0;
        int size = 0;

        public MyQueue(int capacity)
        {
            this.a = new int[capacity];
            size = 0;
        }

        public void Enqueue(int value)
        {
//            Console.WriteLine("size=" + Size() + ", endIndex=" + endIndex);
            if (Size() == a.Length)
            {
                int[] b = new int[a.Length * SCALE_FACTOR];
                int bIndex = 0;
                for (int i = startIndex; i < a.Length; ++i)
                    b [bIndex++] = a [i];
                for (int i = endIndex == 0 ? 0 : endIndex - 1; i < startIndex; ++i)
                    b [bIndex++] = a [i];
                startIndex = 0;
                endIndex = a.Length;
                a = b;
//                for (int i = 0; i < b.Length; ++i)
//                {
//                    Console.Write(b [i] + " ");
//                }
            }
            ++size;
            a [endIndex] = value;
            endIndex = (endIndex + 1) % a.Length;
        }

        public int Dequeue()
        {
            if (Size() > 0)
            {
                --size;
                int result = a [startIndex];
                startIndex = (startIndex + 1) % a.Length;
                return result;
            } else
            {
                throw new Exception("Empty");
            }
        }

        public int Size()
        {
            return size;
        }

    }

    public static void RunTests()
    {
        MyQueue queue = new MyQueue(5);
        queue.Enqueue(5);
        Console.WriteLine(queue.Size());
        queue.Enqueue(6);
        Console.WriteLine(queue.Size());
        queue.Enqueue(7);
        Console.WriteLine(queue.Size());
        queue.Enqueue(3);
        Console.WriteLine(queue.Size());
        queue.Enqueue(2);
        Console.WriteLine(queue.Size());
        queue.Enqueue(1);
        Console.WriteLine(queue.Size());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Size());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Size());
    }

}
