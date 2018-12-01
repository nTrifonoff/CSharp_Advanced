using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> bulletShoot = new Stack<int>(bullets);
            Queue<int> locksShoot = new Queue<int>(locks);

            int currentBulletsShoot = 0;

            while (locksShoot.Count != 0 && bulletShoot.Count != 0)
            {
                int currentBullet = bulletShoot.Pop();
                int currentLock = locksShoot.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locksShoot.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                currentBulletsShoot++;

                if (currentBulletsShoot == barrelSize && bulletShoot.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    currentBulletsShoot = 0;
                }
            }

            if (locksShoot.Count != 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksShoot.Count}");
            }
            else
            {
                int bulletsCost = (bullets.Length - bulletShoot.Count) * bulletPrice;
                int moneyEarned = intelligenceValue - bulletsCost;
                Console.WriteLine($"{bulletShoot.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
