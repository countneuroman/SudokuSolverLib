using System;
using System.Collections.Generic;

namespace SudokuSolverLib
{
    static class Sigments
    {
        static int[,] first = new int[2, 3] { { 0, 1, 2 }, { 0, 1, 2 } };
        static int[,] second = new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } };
        static int[,] third = new int[2, 3] { { 0, 1, 2 }, { 6, 7, 8 } };
        static int[,] fourth = new int[2, 3] { { 3, 4, 5 }, { 0, 1, 2 } };
        static int[,] fifth = new int[2, 3] { { 3, 4, 5 }, { 3, 4, 5 } };
        static int[,] sixth = new int[2, 3] { { 3, 4, 5 }, { 6, 7, 8 } };
        static int[,] seventh = new int[2, 3] { { 6, 7, 8 }, { 0, 1, 2 } };
        static int[,] eighth = new int[2, 3] { { 6, 7, 8 }, { 3, 4, 5 } };
        static int[,] ninth = new int[2, 3] { { 6, 7, 8 }, { 6, 7, 8 } };
        static List<int[,]> sigments = new List<int[,]> { first, second, third, fourth, fifth, sixth, seventh, eighth, ninth };
        public static int[,] GetSigment(int row, int column)
        {
            if (row >= 0 && row < 9 && column >= 0 && column < 9)
            {
                foreach (int[,] positions in sigments)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (positions[0, i] == row)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (positions[1, j] == column)
                                {
                                    return positions;
                                }
                            }
                        }
                    }
                }
                throw new Exception("Error");
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
}
