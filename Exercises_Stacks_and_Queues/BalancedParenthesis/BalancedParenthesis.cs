using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string parenthesis = Console.ReadLine();
            Stack<char> stackOfParenthesis = new Stack<char>();

            char[] openParenthesis = new char[] { '(', '[', '{' };

            for (int i = 0; i < parenthesis.Length; i++)
            {
                char currentParenthesis = parenthesis[i];

                if (openParenthesis.Contains(currentParenthesis))
                {
                    stackOfParenthesis.Push(currentParenthesis);
                }

                if (stackOfParenthesis.Count == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }
                if (stackOfParenthesis.Peek() == '(' && currentParenthesis == ')')
                {
                    stackOfParenthesis.Pop();
                }
                else if (stackOfParenthesis.Peek() == '[' && currentParenthesis == ']')
                {
                    stackOfParenthesis.Pop();
                }
                else if (stackOfParenthesis.Peek() == '{' && currentParenthesis == '}')
                {
                    stackOfParenthesis.Pop();
                }
            }

            if (stackOfParenthesis.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
