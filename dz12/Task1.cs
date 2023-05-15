using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz12
{
    internal class Task1
    {
        public static void Run()
        {
            int a = 10, b = 3;
            double c = -3.5, d = 5.9;
            string e = "first str", f = "second str";
            Console.WriteLine("Variables before swap:");
            Show<int>(a, b);
            Swap<int>(ref a, ref b);
            Console.WriteLine("Variables after swap:");
            Show<int>(a, b);
            Console.WriteLine();
            Console.WriteLine("Variables before swap:");
            Show<double>(c, d);
            Swap<double>(ref c, ref d);
            Console.WriteLine("Variables after swap:");
            Show<double>(c, d);
            Console.WriteLine();
            Console.WriteLine("Variables before swap:");
            Show<string>(e, f);
            Swap<string>(ref e, ref f);
            Console.WriteLine("Variables after swap:");
            Show<string>(e, f);
        }

        private static void Show<T>(T first, T second)
        {
            Console.WriteLine($"Variables values:first - {first}, second - {second}");

        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
    }
}
