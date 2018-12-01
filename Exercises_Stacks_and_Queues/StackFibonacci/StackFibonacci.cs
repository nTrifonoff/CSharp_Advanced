using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    class StackFibonacci
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Stack<long> fibonacciStack = new Stack<long>();
            fibonacciStack.Push(1);
            fibonacciStack.Push(0);

            long sum = 0;

            for (int i = 1; i < n; i++)
            {
                long firstNum = fibonacciStack.Pop();
                long secondNum = fibonacciStack.Pop();
                sum = firstNum + secondNum;

                fibonacciStack.Push(sum);
                fibonacciStack.Push(secondNum);
            }
            Console.WriteLine(n == 0 ? "0" : n == 1 ? "1" : $"{sum}");
        }
    }
}
