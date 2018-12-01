using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> expressionFinder = new Stack<int>(expression.Length);

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    expressionFinder.Push(i);
                }

                if (expression[i] == ')')
                {                   
                    int start = expressionFinder.Pop();
                    Console.WriteLine(expression.Substring(start, i - start + 1));
                }
            }
        }
    }
}
