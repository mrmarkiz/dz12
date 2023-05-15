using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz12
{
    internal class Task5
    {
        public static void Run()
        {
            Console.WriteLine("This double-linked list has string type");
            DoubleLinkedList<string> list = new DoubleLinkedList<string>();
            int choice, subchoice;
            string val;
            do
            {
                Console.WriteLine("Enter what to do(1 - show, 2 - insert, 3 - remove):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        list.Show();
                        break;
                    case 2:
                        Console.Write("Enter value to insert: ");
                        val = Console.ReadLine();
                        Console.Write("Enter where to insert(1 - beginning, 2 - end, 3 - specific): ");
                        if (int.TryParse(Console.ReadLine(), out subchoice))
                        {
                            switch (subchoice)
                            {
                                case 1:
                                    list.InsertAtBeginning(val);
                                    break;
                                case 2:
                                    list.InsertAtEnd(val);
                                    break;
                                case 3:
                                    Console.Write("Enter index to insert at: ");
                                    if (int.TryParse(Console.ReadLine(), out int index))
                                    {
                                        list.InsertAt(index, val);
                                    }
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Console.Write("Enter where to remove(1 - beginning, 2 - end, 3 - specific): ");
                        if (int.TryParse(Console.ReadLine(), out subchoice))
                        {
                            switch (subchoice)
                            {
                                case 1:
                                    list.RemoveBeginning();
                                    break;
                                case 2:
                                    list.RemoveEnd();
                                    break;
                                case 3:
                                    Console.Write("Enter value to remove: ");
                                    val = Console.ReadLine();
                                    list.RemoveSpecific(val);
                                    break;
                            }
                        }
                        break;
                }
            } while (choice != 0);
        }
    }

    internal class DoubleLinkedList<T>
    {
        List<T> list;
        public DoubleLinkedList()
        {
            list = new List<T>();
        }

        public void InsertAtBeginning(T val)
        {
            if (list.Count() == 0)
                list = new List<T> { val };
            else
                list.Insert(0, val);
        }

        public void InsertAtEnd(T val)
        {
            if (list.Count() == 0)
                list = new List<T> { val };
            else
                list.Insert(list.Count(), val);
        }

        public void InsertAt(int index, T val)
        {
            if (list.Count() == 0 || index < 0 || index > list.Count())
                list = new List<T> { val };
            else
                list.Insert(index, val);
        }

        public void RemoveBeginning()
        {
            if (list.Count() == 0)
                return;
            list.Remove(list[0]);
        }

        public void RemoveEnd()
        {
            if (list.Count() == 0)
                return;
            List<T> result = new List<T>(list.Count() - 1);
            for (int i = 0; i < list.Count - 1; i++)
            {
                result.Add(list[i]);
            }
            list = result;
        }

        public void RemoveSpecific(T val)
        {
            if (list.Count() == 0)
                return;
            list.Remove(val);
        }

        public void Show()
        {
            foreach (var item in list)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine();
        }
    }
}
