using System;
using System.Collections.Generic;

namespace epi
{
    public class P9_11
    {
        public class StackQueue
        {
            private Stack<int> enqueueStack;
            private Stack<int> dequeueStack;

            public StackQueue()
            {
                enqueueStack = new Stack<int>();
                dequeueStack = new Stack<int>();
            }

            public void Enqueue(int value)
            {
                enqueueStack.Push(value);
            }

            public int Dequeue()
            {
                if (dequeueStack.Count == 0)
                {
                    while (enqueueStack.Count > 0)
                    {
                        dequeueStack.Push(enqueueStack.Pop());
                    }
                }
                if (dequeueStack.Count > 0)
                {
                    return dequeueStack.Pop();
                } else
                {
                    throw new Exception("empty");
                }
            }

            public int GetSize()
            {
                return enqueueStack.Count + dequeueStack.Count;
            }
        }
    }
}

