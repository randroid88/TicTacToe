using System;
using NUnit.Framework;
using static TicTacToe.Cell.ColumnNames;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        private static int _numberOfRows;
        private static int _numberOfColumns;
        private static Board _board;

        [SetUp]
        public void Setup()
        {
            GivenBoard(3, 3);
        }

        [Test]
        public void WhenBoardCreated_GivenValidSize()
        {
            ThenBoardExists();
            ThenNoCellsAreMarked();
        }

        [Test]
        public void WhenCellMarked_GivenCellWasOpen()
        {
            var a0Cell = GivenCell(A, 0);

            _board.MarkCell(a0Cell, "X");

            ThenCellIsMarkedWith("X", a0Cell);
        }

        // Negative Cases

        [Test]
        public void WhenBoardCreated_GivenInvalidSize()
        {
            try
            {
                GivenBoard(0, 3);
                FailIfAssertWasNotThrown();
            }
            catch (ArgumentException)
            {
                ThenExpectedExceptionWasThrown();
            }
        }

        [Test]
        public void WhenCellMarked_GivenInvalidCellPosition()
        {
            var a0Cell = GivenCell(A, 3); // Remember, rows start at 0

            try
            {
                _board.MarkCell(a0Cell, "X");
                FailIfAssertWasNotThrown();
            }
            catch (IndexOutOfRangeException)
            {
                ThenExpectedExceptionWasThrown();
            }
        }
        
        [Test]
        public void WhenCellMarked_GivenCellAlreadyMarked()
        {
            var markedCell = GivenAlreadyMarkedCell("O");

            var cellMarkChanged =_board.MarkCell(markedCell, "X");

            ThenCellMarkWasNotChanged(cellMarkChanged);
            ThenCellIsMarkedWith("O", markedCell);
        }

        private static void ThenCellMarkWasNotChanged(bool cellMarkChanged)
        {
            Assert.False(cellMarkChanged);
        }

        private static void GivenBoard(int numberOfColumns, int numberOfRows)
        {
            _numberOfColumns = numberOfColumns;
            _numberOfRows = numberOfRows;
            _board = new Board(_numberOfColumns, _numberOfRows);
        }

        private static Cell GivenCell(Cell.ColumnNames column, int row)
        {
            return new Cell(column, row);
        }

        private static Cell GivenAlreadyMarkedCell(string playerToken)
        {
            var cell = GivenCell(Cell.ColumnNames.C, 2);
            _board.MarkCell(cell, playerToken);
            return cell;
        }

        private static void ThenBoardExists()
        {
            Assert.IsNotNull(_board);
        }

        private static void ThenExpectedExceptionWasThrown()
        {
            Assert.Pass();
        }

        private static void FailIfAssertWasNotThrown()
        {
            Assert.Fail();
        }

        private static void ThenCellIsMarkedWith(string playerToken, Cell cell)
        {
            Assert.AreEqual(playerToken, _board.GetCellMark(cell));
        }

        private static void ThenNoCellsAreMarked()
        {
            for (var row = 0; row < _numberOfRows; row++)
            {
                for (int column = 0; column < _numberOfColumns; column++)
                {
                    var cell = new Cell((Cell.ColumnNames) column, row);
                    Assert.IsNull(_board.GetCellMark(cell));
                }
            }
        }
    }
}