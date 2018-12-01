using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] filledBottles = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacity);
            Stack<int> bottles = new Stack<int>(filledBottles);

            int wastedWater = 0;

            while (cups.Count != 0 && bottles.Count != 0)
            {
                int cup = cups.Peek();
                int bottle = bottles.Pop();
                int reduce = bottle - cup;

                if (reduce >= 0)
                {
                    wastedWater += bottle - cup;
                    cups.Dequeue();
                }
                else
                {
                    if (bottles.Count == 0)
                    {

                        cups.Dequeue();
                        wastedWater = bottle - cup;
                        break;
                    }
                    while (bottles.Count != 0)
                    {
                        bottle = bottles.Pop();

                        cup = Math.Abs(reduce);

                        reduce = bottle - cup;

                        if (reduce >= 0)
                        {
                            wastedWater += reduce;
                            cups.Dequeue();
                            break;
                        }
                    }
                }
            }

            List<int> print = new List<int>();

            if (cups.Count != 0)
            {
                print = new List<int>(cups);

                Console.WriteLine($"Cups: {string.Join(' ', print)}");

                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                print = new List<int>(bottles.Reverse());

                Console.WriteLine($"Bottles: {string.Join(' ', print)}");

                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
