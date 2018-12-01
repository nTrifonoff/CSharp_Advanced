using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace DataTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = "s:([^;]+);r:([^;]+);m--\"([a-zA-z ]+)\"";

            int totalData = 0;
            string name = string.Empty;
            string[] names = new string[2];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                var matches = Regex.Matches(line, pattern);

                foreach (Match match in matches)
                {
                    string group1 = match.Groups[1].ToString();
                    string group2 = match.Groups[2].ToString();
                    string group3 = match.Groups[3].ToString();

                    for (int k = 0; k < group1.Length; k++)
                    {
                        char symbol = group1[k];

                        if (symbol >= 48 && symbol <= 57)
                        {
                            totalData += int.Parse(symbol.ToString());
                        }
                        else if (symbol >= 65 && symbol <= 90 || symbol >= 97 && symbol <= 122)
                        {
                            name += symbol;
                        }
                    }

                    names[0] = name;
                    name = string.Empty;

                    for (int k = 0; k < group2.Length; k++)
                    {
                        char symbol = group2[k];

                        if (symbol >= 48 && symbol <= 57)
                        {
                            totalData += int.Parse(symbol.ToString());
                        }
                        else if (symbol >= 65 && symbol <= 90 || symbol >= 97 && symbol <= 122 || symbol == ' ')
                        {
                            name += symbol;
                        }
                    }

                    names[1] = name;
                    name = string.Empty;

                    Console.WriteLine($"{names[0]} says \"{group3}\" to {names[1]}");
                }

            }
            Console.WriteLine($"Total data transferred: {totalData}MB");
        }
    }
}
