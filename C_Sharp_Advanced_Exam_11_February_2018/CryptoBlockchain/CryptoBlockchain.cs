using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string input = GetTextInput(rows);
            string pattern = @"\[[^\d\[\]\{\]\}]*(\d{3,})[^\d\[\]\{\]\}]*]|\{[^\d\[\]\{\]\}]*(\d{3,})[^\d\[\]\{\]\}]*}";

            var matches = Regex.Matches(input, pattern);
            string textToPrint = string.Empty;

            List<int> numbersList = new List<int>();

            foreach (Match match in matches)
            {
                if (match.ToString().StartsWith('['))
                {
                    int numbers = match.Groups[1].Length;
                    int currentMatchLength = match.Length;

                    if (numbers % 3 == 0)
                    {
                        GetNumbersFromMatch(numbersList, match);

                        for (int i = 0; i < numbersList.Count; i++)
                        {
                            int numToChar = numbersList[i] - currentMatchLength;

                            textToPrint += (char)numToChar;
                        }

                        numbersList.Clear();
                    }
                }
                else
                {
                    int numbers = match.Groups[2].Length;
                    int currentMatchLength = match.Length;

                    if (numbers % 3 == 0)
                    {
                        GetNumbersFromMatch(numbersList, match);

                        for (int i = 0; i < numbersList.Count; i++)
                        {
                            int numToChar = numbersList[i] - currentMatchLength;

                            textToPrint += (char)numToChar;
                        }

                        numbersList.Clear();
                    }
                }
            }

            Console.WriteLine(textToPrint);
        }

        private static void GetNumbersFromMatch(List<int> numbersList, Match match)
        {
            string text = match.Groups[1].ToString();

            if (match.ToString().StartsWith('{'))
            {
                text = match.Groups[2].ToString();
            }

            while (text.Length != 0)
            {
                string textToAdd = text.Substring(0, 3);

                numbersList.Add(int.Parse(textToAdd));

                text = text.Remove(0, 3);
            }
        }

        private static string GetTextInput(int rows)
        {
            string input = string.Empty;

            for (int row = 0; row < rows; row++)
            {
                input += Console.ReadLine();
            }

            return input;
        }
    }
}
