using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string snake = Console.ReadLine();

            char[][] matrix = new char[rows][];

            GetMatrix(matrix, cols, snake);

            int [] shotDestination = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Shoot(matrix, shotDestination);

            Collapse(matrix);

            PrintMatrix(matrix);
        }

        private static void Collapse(char[][] matrix)
        {
            Queue<char> elements = new Queue<char>(matrix.Length);

            for (int col = 0; col < matrix[0].Length; col++)
            {
                int counter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        elements.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = counter; row < matrix.Length; row++)
                {
                    matrix[row][col] = elements.Dequeue();
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void Shoot(char[][] matrix, int[] shotDestination)
        {
            int targetRow = shotDestination[0];
            int targetCol = shotDestination[1];
            int radius = shotDestination[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool isInside = Math.Pow((row - targetRow), 2) + Math.Pow((col - targetCol), 2) <= Math.Pow(radius, 2);

                    if (isInside)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void GetMatrix(char[][] matrix, int cols, string snake)
        {
            int counter = 0;
            bool isLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];

                if (isLeft == true)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        counter = setLetter(matrix, snake, counter, row, col);
                    }

                    isLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        counter = setLetter(matrix, snake, counter, row, col);
                    }

                    isLeft = true;
                }
            }
        }

        private static int setLetter(char[][] matrix, string snake, int counter, int row, int col)
        {
            matrix[row][col] = snake[counter++];

            if (counter == snake.Length)
            {
                counter = 0;
            }

            return counter;
        }
    }
}
