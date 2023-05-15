using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz12
{
    internal class Task2
    {
        public static void Run()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();
            Console.WriteLine("This priority queue has string type");
            int choice;
            do
            {
                Console.WriteLine("Enter what to do(1 - show, 2 - show size, 3 - check isEmpty, 4 - show Top el, 5 - enqueue, 6 - dequeue):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        queue.Show();
                        break;
                    case 2:
                        Console.WriteLine($"Size: {queue.Size()}");
                        break;
                    case 3:
                        Console.WriteLine($"Result: {queue.IsEmpty()}");
                        break;
                    case 4:
                        Pair<string> top = new Pair<string>();
                        try
                        {
                            top = queue.Top();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error collapsed: {ex.Message}");
                            break;
                        }
                        Console.WriteLine($"Top: {top}");
                        break;
                    case 5:
                        Console.Write("Enter element to enqueue(value, priority): ");
                        string[] input = Console.ReadLine().Split(' ');
                        int.TryParse(input[1], out int prior);
                        queue.Enqueue(new Pair<string>(input[0], prior));
                        break;
                    case 6:
                        Pair<string> result = new Pair<string>();
                        try
                        {
                            result = queue.Dequeue();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error collapsed: {ex.Message}");
                            break;
                        }
                        Console.WriteLine($"Result: {result}");
                        break;
                }
            } while (choice != 0);
        }
    }

    internal struct Pair<T>
    {
        public T Value { get; set; }
        public int Priority { get; set; }
        public Pair(T val, int prior)
        {
            Value = val;
            Priority = prior;
        }

        public override string ToString()
        {
            return $"Value - {Value}, Priority - {Priority}";
        }
    }

    internal class PriorityQueue<T>
    {
        List<Pair<T>> queue;

        public PriorityQueue()
        {
            queue = new List<Pair<T>>();
        }

        public void Enqueue(Pair<T> val)
        {
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue[i].Priority > val.Priority)
                {
                    queue.Insert(i, val);
                    return;
                }
            }
            if (queue.Count == 0)
                queue = new List<Pair<T>>(0) { val };
            else
                queue.Insert(queue.Count, val);
        }

        public Pair<T> Dequeue()
        {
            if (queue.Count == 0)
                throw new Exception("Empty queue");
            Pair<T> result = queue[0];
            queue.Remove(new Pair<T>(queue[0].Value, queue[0].Priority));
            return result;
        }

        public void Show()
        {
            foreach(var pair in queue)
                Console.WriteLine(pair);
            Console.WriteLine();
        }
        
        public int Size()
        {
            return queue.Count;
        }

        public Pair<T> Top()
        {
            if (queue.Count == 0)
                throw new Exception("Empty queue");
            return queue[0];
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }
    }
}
