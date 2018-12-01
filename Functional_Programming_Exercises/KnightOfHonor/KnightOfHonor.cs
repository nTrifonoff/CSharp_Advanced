using System;

namespace KnightOfHonor
{
    class KnightOfHonor
    {
        static void Main(string[] args)
        {
            Action<string[]> knights = names => Console.WriteLine("Sir " + string.Join(" \nSir ", names));

            string[] input = Console.ReadLine().Split();

            knights(input);
        }
    }
}
