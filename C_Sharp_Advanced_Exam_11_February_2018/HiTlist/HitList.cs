using System;
using System.Collections.Generic;
using System.Linq;

namespace HiTlist
{
    class HitList
    {
        static void Main(string[] args)
        {
            int targetInfo = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, string>> information = new Dictionary<string, Dictionary<string, string>>();

            string text = Console.ReadLine();

            while (text != "end transmissions")
            {
                string[] input = text.Split('=').ToArray();
                string name = input[0];

                if (!information.ContainsKey(name))
                {
                    information.Add(name, new Dictionary<string, string>());
                }

                string[] kvp = input[1].Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (var pair in kvp)
                {
                    var tokens = pair.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string key = tokens[0];
                    string value = tokens[1];

                    information[name][key] = value;
                }

                text = Console.ReadLine();
            }

            string target = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Last();

            int infoIndex = information[target]
                .Select(kvp => kvp.Key.Length + kvp.Value.Length)
                .Sum();

            PrintTargetInfo(information, target);

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfo)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfo - infoIndex} more info.");
            }
        }

        private static void PrintTargetInfo(Dictionary<string, Dictionary<string, string>> information, string target)
        {

            foreach (var name in information)
            {
                if (name.Key == target)
                {
                    Console.WriteLine($"Info on {target}:");

                    var sortedInfo = name.Value.OrderBy(x => x.Key);

                    foreach (var kvp in sortedInfo)
                    {
                        Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
                    }
                    break;
                }
            }
        }
    }
}
