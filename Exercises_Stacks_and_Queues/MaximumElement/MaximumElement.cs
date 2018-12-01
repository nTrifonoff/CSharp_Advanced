using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    class MaximumElement
    {
        static void Main(string[] args)
        {
            int commandsNumber = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < commandsNumber; i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (command[0] == 1)
                {
                    numbers.Push(command[1]);
                }
                else if (command[0] == 2)
                {
                    numbers.Pop();
                }
                else if (command[0] == 3)
                {
                    Console.WriteLine(numbers.Max());
                }
            }
        }
    }
}
