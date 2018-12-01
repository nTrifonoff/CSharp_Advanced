using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());

            Predicate<string> filter = n => n.Length <= nameLength;

            string[] names = Console.ReadLine()
                .Split(' ');

            foreach (var name in names)
            {
                if (filter(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
