using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int pumpsCounter = int.Parse(Console.ReadLine());
            Queue<int[]> petrolPumps = new Queue<int[]>();

            for (int i = 0; i < pumpsCounter; i++)
            {
                int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();

                petrolPumps.Enqueue(commands);
            }
            int index = 0;

            while (true)
            {
                int totalAmount = 0;

                foreach (var pump in petrolPumps)
                {
                    int amount = pump[0];
                    int distance = pump[1];
                    totalAmount += amount - distance;

                    if (totalAmount < 0)
                    {
                        index++;
                        int[] pumpForRemove = petrolPumps.Dequeue();
                        petrolPumps.Enqueue(pumpForRemove);
                        break;
                    }
                }

                if (totalAmount >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}
