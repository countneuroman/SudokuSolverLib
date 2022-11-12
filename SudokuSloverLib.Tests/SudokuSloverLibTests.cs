using SudokuSolverLib;

namespace SudokuSloverLib.Tests;

public class SudokuSloverLibTests
{
    [Fact]
    public void Success_slove_test()
    {
        var puzzle = new[,]
        {
            { 0, 2, 0, 0, 7, 0, 0, 0, 0 }, { 0, 0, 0, 9, 0, 0, 4, 0, 0 }, { 5, 0, 9, 0, 0, 0, 0, 0, 0 },
            { 0, 6, 0, 0, 0, 5, 0, 0, 0 }, { 3, 0, 0, 0, 0, 0, 0, 4, 0 }, { 0, 0, 1, 6, 0, 0, 9, 0, 7 },
            { 9, 5, 0, 0, 0, 6, 1, 0, 0 }, { 2, 0, 0, 8, 0, 0, 0, 7, 0 }, { 0, 4, 0, 3, 5, 2, 0, 0, 0 }
        };
        var expected = new[,]
        {
            { 6, 2, 4, 5, 7, 8, 3, 9, 1 }, { 8, 7, 3, 9, 6, 1, 4, 2, 5 }, { 5, 1, 9, 2, 3, 4, 7, 6, 8 },
            { 7, 6, 2, 4, 9, 5, 8, 1, 3 }, { 3, 9, 5, 1, 8, 7, 2, 4, 6 }, { 4, 8, 1, 6, 2, 3, 9, 5, 7 },
            { 9, 5, 8, 7, 4, 6, 1, 3, 2 }, { 2, 3, 6, 8, 1, 9, 5, 7, 4 }, { 1, 4, 7, 3, 5, 2, 6, 8, 9 }
        };
        var solver = new Solver();

        int[,]? result = solver.Solve(puzzle);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Array_size_error_test()
    {
        var puzzle = new[,]
        {
            { 0, 2, 0, 0, 7, 0, 0, 0, 0 }, { 0, 0, 0, 9, 0, 0, 4, 0, 0 }
        };
        var expected = new[,] { { -1 } };
        var solver = new Solver();

        int[,]? result = solver.Solve(puzzle);
        
        Assert.Equal(expected, result);
    }
}