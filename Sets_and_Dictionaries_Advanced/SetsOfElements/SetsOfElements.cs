using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class SetesOfElements
    {
        static void Main(string[] args)
        {
            int[] setsLength = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstSetLength = setsLength[0];
            int secondSetLength = setsLength[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());

                firstSet.Add(number);
            }

            List<int> numbersToPrint = new List<int>();

            for (int i = 0; i < secondSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondSet.Add(number);
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
