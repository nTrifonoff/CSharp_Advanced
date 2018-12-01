using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < countOfLines; i++)
            {
                string [] input = Console.ReadLine().Split(" -> ");

                string[] clothes = input[1].Split(",");
                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int k = 0; k < clothes.Length; k++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[k]))
                    {
                        wardrobe[color].Add(clothes[k], 1);
                    }
                    else
                    {
                        wardrobe[color][clothes[k]] += 1;
                    }
                }
            }

            string [] itemToFind = Console.ReadLine().Split(" ");

            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var pair in kvp.Value)
                {
                    if (itemToFind[0] == kvp.Key && itemToFind[1] == pair.Key)
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value}");
                    }
                }
            }
        }
    }
}
