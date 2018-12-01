using System;
using System.Linq;

namespace Matrix_of_Palindromes
{
    class Matrix_of_Palindromes
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("" + (char)('a' + i) + (char)('a' + i + j) + (char)('a' + i) + ' ');
                }
                Console.WriteLine();
            }
        }
    }
}
