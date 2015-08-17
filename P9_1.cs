using System;
using System.Collections;

public class P9_1
{
    private class MaxStack
    {
        private class MaxInfo
        {
            public int value;
            public int count;

            public MaxInfo(int value, int count)
            {
                this.value = value;
                this.count = count;
            }
        }

        private Stack stack;
        private Stack maxStack;

        public MaxStack()
        {
            stack = new Stack();
            maxStack = new Stack();
        }

        public void Push(int value)
        {
            if (stack.Count > 0)
            {
                MaxInfo topMax = maxStack.Peek() as MaxInfo;
                if (topMax.value == value)
                {
                    ++topMax.count;
                } else if (topMax.value < value)
                {
                    maxStack.Push(new MaxInfo(value, 1));
                }
            } else
            {
                maxStack.Push(new MaxInfo(value, 1));
            }
            stack.Push(value);
        }

        public int Pop()
        {
            if (stack.Count == 0)
            {
                throw new Exception("no element to pop");
            }
            int top = Convert.ToInt32(stack.Pop());
            MaxInfo topMax = maxStack.Peek() as MaxInfo;
            if (topMax.value == top)
            {
                --topMax.count;
                if (topMax.count == 0)
                {
                    maxStack.Pop();
                }
            }
            return top;
        }

        public int Peek()
        {
            if (stack.Count == 0)
            {
                throw new Exception("no element to peek");
            }
            return Convert.ToInt32(stack.Peek());
        }

        public int Max()
        {
            if (stack.Count == 0)
            {
                throw new Exception("no element in stack");
            }
            MaxInfo topMax = maxStack.Peek() as MaxInfo;
            return topMax.value;
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