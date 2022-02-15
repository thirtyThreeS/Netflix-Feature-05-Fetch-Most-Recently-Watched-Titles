using _05NetflixFeature;

class LRUCache
{
    int capacity;
    Dictionary<int, LinkedListNode> cache;
    MyLinkedList cacheVals;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, LinkedListNode>(capacity);
        cacheVals = new MyLinkedList();
    }

    
    LinkedListNode Get(int key)
    {
        if (!cache.ContainsKey(key)) return null;

        else
        {
            string value = cache[key].data;
            cacheVals.RemoveNode(cache[key]);
            cacheVals.InsertAtTail(key, value);
            return cacheVals.GetTail();
        }
    }

    void Set(int key, string value)
    {
        if (!cache.ContainsKey(key))
        {
            EvictIfNeeded();
            cacheVals.InsertAtTail(key, value);
            cache[key] = cacheVals.GetTail();
        }
        else
        {
            cacheVals.RemoveNode(cache[key]);
            cacheVals.InsertAtTail(key, value);
            cache[key] = cacheVals.GetTail();
        }
    }

    void EvictIfNeeded()
    {
        if (cacheVals.size >= capacity)
        {
            LinkedListNode node = cacheVals.RemoveHead();
            cache.Remove(node.key);
        }
    }

    void Print()
    {
        var node = cacheVals.head;
        while (node != null)
        {
            Console.WriteLine($"({node.key}, {node.data})");
            node = node.next;
        }
        Console.WriteLine("");
    }

    public static void Main()
    {
        LRUCache cache = new(3);
        Console.WriteLine("The most recently watched titles are: (key, value)");
        cache.Set(10, "Lion King");
        cache.Print();

        cache.Set(15, "Home Alone");
        cache.Print();

        cache.Set(20, "The Prestige");
        cache.Print();

        cache.Set(25, "Marry Me");
        cache.Print();

        cache.Set(05, "40 Year Old Virgin");
        cache.Print();

        cache.Get(25);
        cache.Print();
    }
}