using System;
using System.Linq;

namespace Custom_Min_Function
{
    class Custom_Min_Function
    {
        static void Main(string[] args)
        {
            Func<int[], int> smallestNumber = number => number.Min();

            Action<int> print = number => Console.WriteLine(number);

            int[] numbers = Console.ReadLine().
                Split()
                .Select(int.Parse)
                .ToArray();

            print(smallestNumber(numbers));

        }
    }
}
