using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            string [] children = Console.ReadLine().Split(' ');
            int tosses = int.Parse(Console.ReadLine());
            Queue<string> names = new Queue<string>(children);

            while (names.Count != 1)
            {
                for (int i = 1; i < tosses; i++)
                {
                    names.Enqueue(names.Dequeue());
                }
                Console.WriteLine($"Removed {names.Dequeue()}");
            }
            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}
