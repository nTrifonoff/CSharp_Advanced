using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            Stack<string> stackToUse = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                string currentCommand = command[0];

                if (currentCommand == "1")
                {
                    string currentText = command[1];
                    stackToUse.Push(text);

                    text += currentText;
                }
                else if (currentCommand == "2")
                {
                    int count = int.Parse(command[1]);

                    if (count > text.Length)
                    {
                        count = Math.Min(count, text.Length);
                    }

                    stackToUse.Push(text);
                    text = text.Substring(0, text.Length - count);
                }
                else if (currentCommand == "3")
                {
                    int index = int.Parse(command[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (currentCommand == "4")
                {                  
                    if (stackToUse.Count > 0)
                    {
                        text = stackToUse.Pop();
                    }
                    else
                    {
                        text = string.Empty;
                    }
                }
            }
        }
    }
}
