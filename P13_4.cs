using System;
using System.Collections.Generic;

public class P13_4
{
    public class LRUCache
    {
        private int capacity;
        Dictionary<string, LinkedListNode<KeyValuePair<string, int>>> priceTable;
        LinkedList<KeyValuePair<string, int>> lru;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            priceTable = new Dictionary<string, LinkedListNode<KeyValuePair<string, int>>>(capacity);
            lru = new LinkedList<KeyValuePair<string, int>>();
        }

        private void MoveToFront(LinkedListNode<KeyValuePair<string, int>> node)
        {
            lru.Remove(node);
            lru.AddFirst(node);
        }

        public bool Lookup(string isbn, out int price)
        {
            LinkedListNode<KeyValuePair<string, int>> node;
            if (priceTable.TryGetValue(isbn, out node))
            {
                MoveToFront(node);
                price = node.Value.Value;
                return true;
            }
            price = 0;
            return false;
        }

        public void Insert(string isbn, int price)
        {
            LinkedListNode<KeyValuePair<string, int>> newNode;
            var newNodeValue = new KeyValuePair<string, int>(isbn, price);
            if (priceTable.TryGetValue(isbn, out newNode))
            {
                MoveToFront(newNode);
                newNode.Value = newNodeValue;
            } else
            {
                if (priceTable.Count == capacity)
                {
                    var node = lru.Last;
                    priceTable.Remove(node.Value.Key);
                    lru.RemoveLast();
                }
                newNode = lru.AddFirst(newNodeValue);
            }
            priceTable[isbn] = newNode;
        }

        public bool Update(string isbn, int price)
        {
            LinkedListNode<KeyValuePair<string, int>> node;
            if (!priceTable.TryGetValue(isbn, out node))
            {
                return false;
            }
            node.Value = new KeyValuePair<string, int>(isbn, price);
            MoveToFront(node);
            return true;
        }

        public bool Remove(string isbn)
        {
            LinkedListNode<KeyValuePair<string, int>> node;
            if (!priceTable.TryGetValue(isbn, out node))
                return false;
            lru.Remove(node);
            priceTable.Remove(isbn);
            return true;
        }
    }

    public static void RunTests()
    {
        LRUCache cache = new LRUCache(5);
        cache.Insert("A", 11);
        cache.Insert("B", 22);
        cache.Insert("C", 33);
        int price = 0;
        Console.Write(cache.Lookup("A", out price) + " ");
        Console.WriteLine(price);
        Console.Write(cache.Lookup("B", out price) + " ");
        Console.WriteLine(price);
        Console.Write(cache.Lookup("C", out price) + " ");
        Console.WriteLine(price);
        cache.Insert("D", 44);
        cache.Insert("E", 55);
        cache.Insert("F", 66);
        Console.Write(cache.Lookup("F", out price) + " ");
        Console.WriteLine(price);
        Console.WriteLine(cache.Lookup("A", out price));
        Console.Write(cache.Lookup("B", out price) + " ");
        Console.WriteLine(price);
        cache.Remove("F");
        Console.WriteLine(cache.Lookup("F", out price));
        cache.Update("B", 23);
        Console.Write(cache.Lookup("B", out price) + " ");
        Console.WriteLine(price);
    }
}