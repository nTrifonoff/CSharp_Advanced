using System;
using System.Linq;

namespace Miner
{
    class Miner
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int rowMiner = 0;
            int colMiner = 0;
            int coalsCount = 0;

            string[] directions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            char[][] field = new char[fieldSize][];
            NewMethod(fieldSize, ref rowMiner, ref colMiner, ref coalsCount, field);

            int coals = 0;

            for (int l = 0; l < directions.Length; l++)
            {
                string direction = directions[l];

                MoveMiner(field, direction, ref rowMiner, ref colMiner, ref coals);
            }

            if (coalsCount - coals == 0)
            {
                Console.WriteLine($"You collected all coals! ({rowMiner}, {colMiner})");
            }
            else
            {
                Console.WriteLine($"{coalsCount - coals} coals left. ({rowMiner}, {colMiner})");
            }
        }

        private static void NewMethod(int fieldSize, ref int rowMiner, ref int colMiner, ref int coalsCount, char[][] field)
        {
            for (int i = 0; i < fieldSize; i++)
            {
                field[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                if (field[i].Contains('s'))
                {
                    rowMiner = i;
                    colMiner = Array.IndexOf(field[i], 's');
                }

                if (field[i].Contains('c'))
                {
                    for (int c = 0; c < field[i].Length; c++)
                    {
                        char symb = field[i][c];

                        if (symb == 'c')
                        {
                            coalsCount++;
                        }
                    }
                }
            }
        }

        private static void MoveMiner(char[][] field, string direction, ref int rowMiner, ref int colMiner, ref int coals)
        {
            if (direction == "up")
            {
                if (field[colMiner].First() != 's')
                {
                    field[rowMiner][colMiner] = '*';
                    rowMiner--;

                    coals = addCoals(field, rowMiner, colMiner, coals);
                    endProgram(field, rowMiner, colMiner);
                }
            }
            else if (direction == "down")
            {
                if (field[colMiner].Last() != 's')
                {
                    field[rowMiner][colMiner] = '*';
                    rowMiner++;

                    coals = addCoals(field, rowMiner, colMiner, coals);
                    endProgram(field, rowMiner, colMiner);
                }
            }
            else if (direction == "left")
            {
                if (field[colMiner].First() != 's')
                {
                    field[rowMiner][colMiner] = '*';
                    colMiner--;

                    coals = addCoals(field, rowMiner, colMiner, coals);
                    endProgram(field, rowMiner, colMiner);
                }
            }
            else if (direction == "right")
            {
                if (field[rowMiner].Last() != 's')
                {
                    field[rowMiner][colMiner] = '*';
                    colMiner++;

                    coals = addCoals(field, rowMiner, colMiner, coals);
                    endProgram(field, rowMiner, colMiner);
                }
            }

            field[rowMiner][colMiner] = 's';
        }

        private static int addCoals(char[][] field, int rowMiner, int colMiner, int coals)
        {
            if (field[rowMiner][colMiner] == 'c')
            {
                coals++;
            }

            return coals;
        }

        private static void endProgram(char[][] field, int rowMiner, int colMiner)
        {
            if (field[rowMiner][colMiner] == 'e')
            {
                Console.WriteLine($"Game over! ({rowMiner}, {colMiner})");
                Environment.Exit(0);
            }
        }
    }
}
