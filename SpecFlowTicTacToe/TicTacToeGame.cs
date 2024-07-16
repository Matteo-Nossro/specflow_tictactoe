namespace SpecFlowTicTacToe;
public class TicTacToeGame
{
    private char[,] _board;
    private char _currentPlayer;

    public TicTacToeGame()
    {
        _board = new char[3, 3];
        _currentPlayer = 'X';
    }

    public bool IsBoardEmpty()
    {
        foreach (var cell in _board)
        {
            if (cell != '\0') return false;
        }

        return true;
    }

    public void PlayMove(char player, int row, int col)
    {
        if (_board[row, col] != '\0')
            throw new InvalidOperationException("Cell is already occupied");

        if (_currentPlayer != player)
            throw new InvalidOperationException("Not the player's turn");

        _board[row, col] = player;
        _currentPlayer = _currentPlayer == 'X' ? 'O' : 'X';
    }

    public char[,] GetBoard()
    {
        return _board.Clone() as char[,];
    }

    public char GetWinner()
    {
        // test ligne
        for (int i = 0; i < 3; i++)
        {
            if (_board[i, 0] != '\0' && _board[i, 0] == _board[i, 1] && _board[i, 1] == _board[i, 2])
                return _board[i, 0];
        }

        // test colonnes
        for (int i = 0; i < 3; i++)
        {
            if (_board[0, i] != '\0' && _board[0, i] == _board[1, i] && _board[1, i] == _board[2, i])
                return _board[0, i];
        }

        // test diagonales
        if (_board[0, 0] != '\0' && _board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2])
            return _board[0, 0];
        if (_board[0, 2] != '\0' && _board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0])
            return _board[0, 2];

        return '\0';
    }

    public bool IsDraw()
    {
        if (GetWinner() != '\0') return false;

        foreach (var cell in _board)
        {
            if (cell == '\0') return false;
        }

        return true;
    }
}

