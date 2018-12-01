using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> integers = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!integers.ContainsKey(number))
                {
                    integers.Add(number, 1);
                }
                else
                {
                    integers[number] += 1;
                }
            }

            foreach (var kvp in integers.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}
