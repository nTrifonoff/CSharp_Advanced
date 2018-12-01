using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string [] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count != 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string symbol = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                if (symbol == "+")
                {
                    firstNumber += secondNumber;
                }

                else if (symbol == "-")
                {
                    firstNumber -= secondNumber;
                }
                stack.Push(firstNumber.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
