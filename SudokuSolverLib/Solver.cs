/// <summary>
/// Sudoku solver
/// </summary>
namespace SudokuSolverLib;

/// <summary>
/// This class solves as array of sudoku.
/// </summary>
public class Solver
{
    /// <summary>
    /// Solves sudoku.
    /// </summary>
    /// <param name="sudoku">Array. Null values = 0.</param>
    /// <returns>Returns the solved sudoku. If an exception or cannot be solved sudoku, returns int[0, 0] = -1.</returns>
    public int[,] Solve(int[,] sudoku)
    {
        try
        {
            int[,] fakeSudoku = (int[,])sudoku.Clone();
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    if (sudoku[row, column] == 0)
                    {
                        for (int value = 1; value < 10; value++)
                        {
                            if (Possibility(sudoku, row, column, value))
                            {
                                fakeSudoku[row, column] = value;
                                int[,] result = Solve(fakeSudoku);
                                if (result[0, 0] != -1)
                                {
                                    return result;
                                }
                            }
                            if (sudoku[row, column] == 0 && value == 9)
                            {
                                return new int[,] { { -1 } };
                            }
                        }
                    }
                }
            }
            return sudoku;
        }
        catch
        {
            return new int[,] { { -1 } };
        }
    }
    bool Possibility(int[,] sudoku, int row, int column, int value)
    {
        if (HorizontalPossibility(sudoku, row, value) && VerticalPossibility(sudoku, column, value) && SigmentPossibility(sudoku, row, column, value))
            return true;
        return false;
    }
    bool HorizontalPossibility(int[,] sudoku, int row, int value)
    {
        bool result = true;
        for (int i = 0; i < 9; i++)
        {
            if (sudoku[row, i] == value)
            {
                result = false;
                break;
            }

        }
        return result;
    }
    bool VerticalPossibility(int[,] sudoku, int column, int value)
    {
        bool result = true;
        for (int i = 0; i < 9; i++)
        {
            if (sudoku[i, column] == value)
            {
                result = false;
                break;
            }

        }
        return result;
    }
    bool SigmentPossibility(int[,] sudoku, int row, int column, int value)
    {
        int[,] sigment = Segments.GetSigment(row, column);
        bool result = true;
        for (int i = 0; i < 3; i++)
        {
            if (!result)
                break;
            for (int j = 0; j < 3; j++)
            {
                if (sudoku[sigment[0, i], sigment[1, j]] == value)
                {
                    result = false;
                    break;
                }
            }
        }
        return result;
    }
}