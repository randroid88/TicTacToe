using System;

namespace TicTacToe
{
    public static class EndgameChecker
    {
        public static bool GameIsOver(Board board, Cell lastMarkedCell)
        {
            if (board == null) return false;
            if (lastMarkedCell == null) return false;
            
            var foundTokensMatch = true;
            var winConditionNumber = 1;
            var playerToken = board.GetCellMark(lastMarkedCell);
            
            foreach (var winConditions in board.GetWinConditionsForCell(lastMarkedCell))
            {
                Console.WriteLine("Win condition: " + winConditionNumber);
                foreach (var cell in winConditions)
                {
                    Console.WriteLine("Cell: " + cell.FriendlyName);

                    if (PlayerTokenNotFoundInCell(board, cell, playerToken))
                    {
                        foundTokensMatch = false;
                    }
                }

                if (foundTokensMatch)
                {
                    return true;
                }

                foundTokensMatch = true;
                winConditionNumber++;
            }

            return false;
        }

        private static bool PlayerTokenNotFoundInCell(Board board, Cell cell, string playerToken)
        {
            return NoMarkerInCell(board, cell) || TokensDoNotMatch(playerToken, board.GetCellMark(cell));
        }

        private static bool TokensDoNotMatch(string playerToken, string cellToken)
        {
            return !cellToken.Equals(playerToken);
        }

        private static bool NoMarkerInCell(Board board, Cell cell)
        {
            return string.IsNullOrEmpty(board.GetCellMark(cell));
        }
    }
}