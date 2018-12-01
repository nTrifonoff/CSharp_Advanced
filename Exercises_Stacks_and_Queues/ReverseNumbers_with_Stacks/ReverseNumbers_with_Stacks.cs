using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbers_with_Stacks
{
    class ReverseNumbers_with_Stacks
    {
        static void Main(string[] args)
        {
            int [] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> reverseNumbers = new Stack<int>(numbers);

            while (reverseNumbers.Count > 0)
            {
                Console.Write(reverseNumbers.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}
