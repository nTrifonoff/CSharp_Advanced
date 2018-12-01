using System;
using System.Linq;

namespace Sneaking
{
    class Sneaking
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[] directions = Console.ReadLine().ToCharArray();

            char[][] room = new char[rows][];

            int row = 0;
            int col = 0;

            for (int i = 0; i < room.Length; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();

                if (room[i].Contains('S'))
                {
                    row = i;
                    col = Array.IndexOf(room[i], 'S');
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                MoveEnemy(room);
                CheckEnemies(room, ref row, ref col);
                MoveHero(room, ref row, ref col, directions[i]);
                CheckNikoladze(room, ref row, ref col);
            }
        }

        private static void CheckNikoladze(char[][] room, ref int row, ref int col)
        {
            if (room[row].Contains('N') && room[row].Contains('S'))
            {
                Console.WriteLine("Nikoladze killed!");

                int nikoladzeCol = Array.IndexOf(room[row], 'N');

                room[row][nikoladzeCol] = 'X';

                PrintRoom(room);
            }
        }

        private static void CheckEnemies(char[][] room, ref int row, ref int col)
        {
            int indexB = Array.IndexOf(room[row], 'b');
            int indexD = Array.IndexOf(room[row], 'd');
            int indexS = Array.IndexOf(room[row], 'S');

            if (indexB != -1 && indexS > indexB)
            {
                Console.WriteLine($"Sam died at {row}, {col}");

                room[row][col] = 'X';

                PrintRoom(room);
            }
            else if (indexD != -1 && indexS < indexD)
            {
                Console.WriteLine($"Sam died at {row}, {col}");

                room[row][col] = 'X';

                PrintRoom(room);
            }
        }

        private static void PrintRoom(char[][] room)
        {
            for (int r = 0; r < room.Length; r++)
            {
                for (int c = 0; c < room[r].Length; c++)
                {
                    Console.Write(room[r][c]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void MoveHero(char[][] room, ref int row, ref int col, char direction)
        {
            room[row][col] = '.';

            switch (direction)
            {
                case 'U': row--; break;
                case 'D': row++; break;
                case 'L': col--; break;
                case 'R': col++; break;
                default:
                    break;
            }

            room[row][col] = 'S';
        }

        private static void MoveEnemy(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                int indexD = Array.IndexOf(room[row], 'd');
                int indexB = Array.IndexOf(room[row], 'b');

                if (indexD != -1)
                {
                    if (indexD == 0)
                    {
                        room[row][indexD] = 'b';
                    }
                    else
                    {
                        room[row][indexD] = '.';
                        indexD--;
                        room[row][indexD] = 'd';
                    }
                }
                else if (indexB != -1)
                {
                    if (indexB == room[row].Length - 1)
                    {
                        room[row][indexB] = 'd';
                    }
                    else
                    {
                        room[row][indexB] = '.';
                        indexB++;
                        room[row][indexB] = 'b';
                    }
                }
            }
        }
    }
}
