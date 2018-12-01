using System;
using System.Collections.Generic;

namespace _01ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reverseString = new Stack<char>();

            foreach (var ch in input)
            {
                reverseString.Push(ch);                       
            }

            while (reverseString.Count > 0)
            {
                Console.Write(reverseString.Pop()); 
            }
            Console.WriteLine();
        }
    }
}
