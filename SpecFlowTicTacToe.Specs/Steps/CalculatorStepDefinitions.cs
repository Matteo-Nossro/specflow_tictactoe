using SpecFlowTicTacToe;
using Xunit;

namespace SpecFlowTicTacToeSpec.Steps;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private TicTacToeGame _game;

    [Given(@"the game is started")]
    public void GivenTheGameIsStarted()
    {
        _game = new TicTacToeGame();
    }

    [Then(@"the board should be empty")]
    public void ThenTheBoardShouldBeEmpty()
    {
        Assert.True(_game.IsBoardEmpty());
    }
    
    [Given("player (.) plays at position \\((\\d+), (\\d+)\\)")]
    public void GivenPlayerPlaysAtPosition(char player, int row, int col)
    {
        _game.PlayMove(player, row, col);
        
    }

    private string[][] ConvertCharArrayToStringArray(char[,] board)
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);
        var result = new string[rows][];

        for (int i = 0; i < rows; i++)
        {
            result[i] = new string[cols];
            for (int j = 0; j < cols; j++)
            {
                result[i][j] = board[i, j] == '\0' ? " " : board[i, j].ToString();
            }
        }

        return result;
    }
    
    [Then(@"the board should look like:")]
    public void ThenTheBoardShouldLookLike(Table table)
    {
        var expectedBoard = table.Rows
            .Select(row => row.Values.Select(cell => string.IsNullOrWhiteSpace(cell) ? " " : cell).ToArray())
            .ToArray();
        var actualBoard = ConvertCharArrayToStringArray(_game.GetBoard());
        Assert.Equal(expectedBoard, actualBoard);
    }
    
    [Then(@"player (.) should be the winner")]
    public void ThenPlayerShouldBeTheWinner(char player)
    {
        Assert.Equal(player, _game.GetWinner());
    }

    [Then(@"the game should be a draw")]
    public void ThenTheGameShouldBeADraw()
    {
        Assert.True(_game.IsDraw());
    }
}