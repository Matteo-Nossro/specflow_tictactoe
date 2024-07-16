Feature: Tic Tac Toe Game

    Scenario: Start a new game
        Given the game is started
        Then the board should be empty
    
    Scenario: Player makes a move
        Given the game is started
        And player X plays at position (0, 0)
        Then the board should look like:
          |   |   |   |
          | X |   |   |
          |   |   |   |
          |   |   |   |

    Scenario: Player X wins the game
        Given the game is started
        And player X plays at position (0, 0)
        And player O plays at position (1, 0)
        And player X plays at position (0, 1)
        And player O plays at position (1, 1)
        And player X plays at position (0, 2)
        Then player X should be the winner

    Scenario: The game is a draw
        Given the game is started
        And player X plays at position (0, 0)
        And player O plays at position (0, 1)
        And player X plays at position (0, 2)
        And player O plays at position (1, 1)
        And player X plays at position (1, 0)
        And player O plays at position (1, 2)
        And player X plays at position (2, 1)
        And player O plays at position (2, 0)
        And player X plays at position (2, 2)
        Then the game should be a draw