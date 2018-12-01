using System;
using System.Collections.Generic;
using System.Linq;

namespace FindsEvensOrOdds
{
    class FindsEvensOrOdds
    {
        static void Main(string[] args)
        {
            int[] numberRange = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            List<long> result = new List<long>();

            Predicate<long> even = n => n % 2 == 0;
            Predicate<long> odd = n => n % 2 != 0;

            for (int i = numberRange[0]; i <= numberRange[1]; i++)
            {
                result.Add(i);
            }

            if (command == "odd")
            {
                result = result.FindAll(odd);
            }
            else
            {
                result = result.FindAll(even);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
