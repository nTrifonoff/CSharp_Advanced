using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicalElements = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < elements.Length; k++)
                {
                    if (!chemicalElements.Contains(elements[k]))
                    {
                        chemicalElements.Add(elements[k]);
                    }
                }
            }

            foreach (var element in chemicalElements)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}
