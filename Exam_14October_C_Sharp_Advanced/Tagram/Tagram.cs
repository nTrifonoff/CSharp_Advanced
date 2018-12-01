using System;
using System.Collections.Generic;
using System.Linq;

namespace Tagram
{
    class Tagram
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> tagram = new Dictionary<string, Dictionary<string, int>>();

            string[] input = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (input[0] != "end")
            {
                if (input[0] == "ban")
                {
                    if (tagram.ContainsKey(input[1]))
                    {
                        tagram.Remove(input[1]);

                        input = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        continue;
                    }
                }

                string userName = input[0];
                string tag = input[1];
                int likes = int.Parse(input[2]);

                if (!tagram.ContainsKey(userName))
                {
                    tagram.Add(userName, new Dictionary<string, int>());
                }
                if (!tagram[userName].ContainsKey(tag))
                {
                    tagram[userName][tag] = likes;
                }
                else if (tagram[userName].ContainsKey(tag))
                {
                    tagram[userName][tag] += likes;
                }

                input = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            tagram = tagram.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(y => y.Value.Keys.Count())
                .ToDictionary(y => y.Key, y => y.Value);

            foreach (var player in tagram)
            {
                Console.WriteLine(player.Key);

                foreach (var p in player.Value)
                {
                    Console.WriteLine(" - " + p.Key + ": " + p.Value);
                }
            }
        }
    }
}
