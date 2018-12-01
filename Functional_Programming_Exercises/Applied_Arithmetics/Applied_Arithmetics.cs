using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    class Applied_Arithmetics
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            string command = Console.ReadLine();

            Func<List<long>, List<long>> addOne = num => num.Select(x => x + 1).ToList();
            Func<List<long>, List<long>> multiply = num => num.Select(x => x * 2).ToList();
            Func<List<long>, List<long>> subtract = num => num.Select(x => x - 1).ToList();
            Action<List<long>> print = n => Console.WriteLine(string.Join(" ", n));

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = addOne(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiply(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtract(numbers);
                }
                else if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
