using System;
using System.Collections;

public class P9_1
{
    private class MaxStack
    {
        private class Data
        {
            public int value;
            public int maxValue;
        }

        private Stack stack;

        public MaxStack()
        {
            stack = new Stack();
        }

        public void Push(int value)
        {
            Data data = new Data();
            data.value = value;
            if (stack.Count > 0)
            {
                Data top = stack.Peek() as Data;
                data.maxValue = Math.Max(top.maxValue, value);
            } else
            {
                data.maxValue = value;
            }
            stack.Push(data);
        }

        public int Pop()
        {
            if (stack.Count == 0)
            {
                throw new Exception("no element to pop");
            }
            Data top = stack.Pop() as Data;
            return top.value;
        }

        public int Peek()
        {
            if (stack.Count == 0)
            {
                throw new Exception("no element to peek");
            }
            Data top = stack.Peek() as Data;
            return top.value;
        }

        public int Max()
        {
            if (stack.Count == 0)
            {
                throw new Exception("no element in stack");
            }
            Data top = stack.Peek() as Data;
            return top.maxValue;
        }
    }

    public static void RunTests()
    {
        MaxStack stack = new MaxStack();
        stack.Push(5);
        stack.Push(0);
        stack.Push(-10);
        Console.WriteLine(stack.Max());
        stack.Push(12);
        Console.WriteLine(stack.Max());
        stack.Push(15);
        Console.WriteLine(stack.Max());
        stack.Pop();
        stack.Pop();
        Console.WriteLine(stack.Max());
    }
}