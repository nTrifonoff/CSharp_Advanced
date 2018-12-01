using System;

namespace ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Action<string[]> names = n => Console.WriteLine(String.Join("\n", n));

            names(input);
        }
    }
}
