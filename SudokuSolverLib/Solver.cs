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
            for (var row = 0; row < 9; row++)
            {
                for (var column = 0; column < 9; column++)
                {
                    if (sudoku[row, column] == 0)
                    {
                        for (var value = 1; value < 10; value++)
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
                                return new[,] { { -1 } };
                            }
                        }
                    }
                }
            }
            return sudoku;
        }
        catch
        {
            return new[,] { { -1 } };
        }
    }

    private bool Possibility(int[,] sudoku, int row, int column, int value)
    {
        if (HorizontalPossibility(sudoku, row, value) && VerticalPossibility(sudoku, column, value) && SigmentPossibility(sudoku, row, column, value))
            return true;
        return false;
    }
    private bool HorizontalPossibility(int[,] sudoku, int row, int value)
    {
        bool result = true;
        for (var i = 0; i < 9; i++)
        {
            if (sudoku[row, i] == value)
            {
                result = false;
                break;
            }

        }
        return result;
    }
    private bool VerticalPossibility(int[,] sudoku, int column, int value)
    {
        bool result = true;
        for (var i = 0; i < 9; i++)
        {
            if (sudoku[i, column] == value)
            {
                result = false;
                break;
            }

        }
        return result;
    }
    private bool SigmentPossibility(int[,] sudoku, int row, int column, int value)
    {
        int[,] sigment = Segments.GetSigment(row, column);
        bool result = true;
        for (var i = 0; i < 3; i++)
        {
            if (!result)
                break;
            for (var j = 0; j < 3; j++)
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