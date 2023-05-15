using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz12
{
    internal class Task3
    {
        public static void Run()
        {
            Console.WriteLine("This priority queue has string type");
            Console.Write("Enter queue max count: ");
            int.TryParse(Console.ReadLine(), out int maxCount);
            QueueRing<string> queue = new QueueRing<string>(maxCount);
            int choice;
            do
            {
                Console.WriteLine("Enter what to do(1 - show, 2 - show count, 3 - check isEmpty, 4 - show isFull, 5 - move, 6 - add, 7 - clear):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        queue.Show();
                        break;
                    case 2:
                        Console.WriteLine($"Count: {queue.Count()}");
                        break;
                    case 3:
                        Console.WriteLine($"Result: {queue.IsEmpty()}");
                        break;
                    case 4:
                        Console.WriteLine($"Result: {queue.IsFull()}");
                        break;
                    case 5:
                        Console.WriteLine($"Result: {queue.Move()}");
                        break;
                    case 6:
                        Console.Write("Enter element to add: ");
                        string input = Console.ReadLine();
                        queue.Add(input);
                        break;
                    case 7:
                        queue.Clear();
                        break;
                }
            } while (choice != 0);
        }
    }

    internal class QueueRing<T>
    {
        List<T> queue;
        int MaxCount { get; set; }

        public QueueRing(int maxCount)
        {
            queue = new List<T>();
            MaxCount = maxCount;
        }

        public void Clear()
        {
            queue = new List<T> { };
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        public int Count()
        {
            return queue.Count;
        }

        public bool IsFull()
        {
            return queue.Count == MaxCount;
        }

        public void Add(T item)
        {
            if (!IsFull())
            {
                if (queue.Count == 0)
                {
                    queue = new List<T> { item };
                }
                else
                {
                    queue.Add(item);
                }
            }
        }

        public bool Move()
        {
            if (!IsEmpty())
            {
                T item = queue[Count() - 1];
                for (int i = Count() - 1; i > 0; i--)
                {
                    queue[i] = queue[i - 1];
                }
                queue[0] = item;
                return true;
            }
            else
                return false;
        }

        public void Show()
        {
            Console.WriteLine("Queue:");
            foreach (T item in queue)
                Console.Write(item + "  ");
            Console.WriteLine();
        }
    }
}
