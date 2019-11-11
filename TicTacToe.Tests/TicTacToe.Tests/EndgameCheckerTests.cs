using System;
using System.Collections.Generic;
using NUnit.Framework;
using static TicTacToe.Cell.ColumnNames;

namespace TicTacToe.Tests
{
    public class EndgameCheckerTests
    {
        private const string LeftToRight = "LeftToRight";
        private const string RightToLeft = "RightToLeft";
        private Board _board;
        private Cell _lastMarkedCell;

        [SetUp]
        public void Setup()
        {
            GivenStandardBoard();
        }

        [Test]
        public void WhenEndgameChecked_GivenNoCellsMarked()
        {
            var gameIsOver = WhenEndgameIsChecked();
            
            ThenGameIsNotOver(gameIsOver);
        }
        
        [Test]
        public void WhenEndgameChecked_GivenSingleCellMarked()
        {
            GivenSingleCellMarked();
            
            var gameIsOver = WhenEndgameIsChecked();
            
            ThenGameIsNotOver(gameIsOver);
        }
        
        [Test]
        public void WhenEndgameChecked_GivenRowWinConditionMet()
        {
            GivenBoardWithRowFilledWith(GivenAnyPlayerToken(), GivenAnyRow());
            
            var gameIsOver = WhenEndgameIsChecked();
            
            ThenGameIsOver(gameIsOver);
        }
        
        [Test]
        public void WhenEndgameChecked_GivenColumnWinConditionMet()
        {
            GivenBoardWithColumnFilledWith(GivenAnyPlayerToken());

            var gameIsOver = WhenEndgameIsChecked();
            
            ThenGameIsOver(gameIsOver);
        }

        [Test]
        public void WhenEndgameChecked_GivenDiagonalWinConditionMet()
        {
            GivenBoardWithAnyDiagonalFilledWith(GivenAnyPlayerToken());

            var gameIsOver = WhenEndgameIsChecked();
            
            ThenGameIsOver(gameIsOver);
        }

        private void GivenBoardWithAnyDiagonalFilledWith(string playerToken)
        {
            if (GivenAnyDiagonal().Equals(LeftToRight))
            {
                GivenBoardWithLeftToRightDiagonalFilledWith(playerToken);
            }
            else
            {
                GivenBoardWithRightToLeftDiagonalFilledWith(playerToken);
            }
        }

        private void GivenBoardWithColumnFilledWith(string playerToken)
        {
            var columns = new List<Cell.ColumnNames> {A, B, C};
            var anyColumn = columns[new Random().Next(columns.Count)];
            _board.MarkCell(new Cell(anyColumn, 0), playerToken);
            _board.MarkCell(new Cell(anyColumn, 1), playerToken);
            _lastMarkedCell = new Cell(anyColumn, 2);
            _board.MarkCell(_lastMarkedCell, playerToken);
        }

        private void GivenBoardWithRightToLeftDiagonalFilledWith(string playerToken)
        {
            _board.MarkCell(new Cell(C, 0), playerToken);
            _board.MarkCell(new Cell(B, 1), playerToken);
            _lastMarkedCell = new Cell(A, 2);
            _board.MarkCell(_lastMarkedCell, playerToken);
        }

        private void GivenBoardWithLeftToRightDiagonalFilledWith(string playerToken)
        {
            _board.MarkCell(new Cell(A, 0), playerToken);
            _board.MarkCell(new Cell(B, 1), playerToken);
            _lastMarkedCell = new Cell(C, 2);
            _board.MarkCell(_lastMarkedCell, playerToken);
        }

        private void GivenBoardWithRowFilledWith(string playerToken, int row)
        {
            _board.MarkCell(new Cell(A, row), playerToken);
            _board.MarkCell(new Cell(B, row), playerToken);
            _lastMarkedCell = new Cell(C, row);
            _board.MarkCell(_lastMarkedCell, playerToken);
        }

        private static string GivenAnyPlayerToken()
        {
            var playerTokens = new List<string> { "X","O"};
            return playerTokens[new Random().Next(playerTokens.Count)];
        }

        private static int GivenAnyRow()
        {
            var rows = new List<int> {0, 1, 2};
            var anyRow = rows[new Random().Next(rows.Count)];
            return anyRow;
        }

        private static string GivenAnyDiagonal()
        {
            var diagonals = new List<string> { LeftToRight, RightToLeft};
            return diagonals[new Random().Next(diagonals.Count)];
        }

        private static void ThenGameIsNotOver(bool gameIsOver)
        {
            Assert.False(gameIsOver);
        }

        private bool WhenEndgameIsChecked()
        {
            var gameIsOver = EndgameChecker.GameIsOver(_board, _lastMarkedCell);
            return gameIsOver;
        }

        private void GivenSingleCellMarked()
        {
            _lastMarkedCell = new Cell(A, 0);
        }

        private void GivenStandardBoard()
        {
            _board = new Board(3, 3);
        }

        private static void ThenGameIsOver(bool gameIsOver)
        {
            Assert.True(gameIsOver);
        }
    }
}