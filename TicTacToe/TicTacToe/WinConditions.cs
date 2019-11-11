using System.Collections.Generic;
using static TicTacToe.Cell.ColumnNames;

namespace TicTacToe
{
    public class WinConditions
    {
        private Cell[,][][] CellWinConditions { get; }

        public WinConditions()
        {
            // 3 by 3 win conditions
            // Hardcoded for now
            CellWinConditions = new[,]
            {
                {GetA0WinConditions(), GetB0WinConditions(), GetC0WinConditions()},
                {GetA1WinConditions(), GetB1WinConditions(), GetC1WinConditions()}, 
                {GetA2WinConditions(), GetB2WinConditions(), GetC2WinConditions()}
            };
        }

        public IEnumerable<Cell[]> GetWinConditionsForCell(Cell cell)
        {
            return CellWinConditions[cell.Row, cell.Column];
        }

        private static Cell[][] GetA1WinConditions()
        {
            var a1RowWinCondition = new[] {new Cell(B, 1), new Cell(C, 1)};
            var a1ColumnWinCondition = new[] {new Cell(A, 0), new Cell(A, 2)};
            var a1WinConditions = new[] {a1RowWinCondition, a1ColumnWinCondition};
            return a1WinConditions;
        }

        private static Cell[][] GetA0WinConditions()
        {
            var a0RowWinCondition = new[] {new Cell(B, 0), new Cell(C, 0)};
            var a0ColumnWinCondition = new[] {new Cell(A, 1), new Cell(A, 2)};
            var a0DiagonalWinCondition = new[] {new Cell(B, 1), new Cell(C, 2)};
            var a0WinConditions = new[] {a0RowWinCondition, a0ColumnWinCondition, a0DiagonalWinCondition};
            return a0WinConditions;
        }

        private static Cell[][] GetB0WinConditions()
        {
            var b0RowWinCondition = new[] {new Cell(A, 0), new Cell(C, 0)};
            var b0ColumnWinCondition = new[] {new Cell(B, 1), new Cell(B, 2)};
            var b0WinConditions = new[] {b0RowWinCondition, b0ColumnWinCondition};
            return b0WinConditions;
        }

        private static Cell[][] GetC0WinConditions()
        {
            var c0RowWinCondition = new[] {new Cell(A, 0), new Cell(B, 0)};
            var c0ColumnWinCondition = new[] {new Cell(C, 1), new Cell(C, 2)};
            var c0DiagonalWinCondition = new[] {new Cell(B, 1), new Cell(A, 2)};
            var c0WinConditions = new[] {c0RowWinCondition, c0ColumnWinCondition, c0DiagonalWinCondition};
            return c0WinConditions;
        }

        private static Cell[][] GetB1WinConditions()
        {
            var b1RowWinCondition = new[] {new Cell(A, 1), new Cell(C, 1)};
            var b1ColumnWinCondition = new[] {new Cell(B, 0), new Cell(B, 2)};
            var b1DiagonalWinCondition = new[] {new Cell(A, 0), new Cell(C, 2)};
            var b1WinConditions = new[] {b1RowWinCondition, b1ColumnWinCondition, b1DiagonalWinCondition};
            return b1WinConditions;
        }

        private static Cell[][] GetC1WinConditions()
        {
            var c1RowWinCondition = new[] {new Cell(A, 1), new Cell(B, 1)};
            var c1ColumnWinCondition = new[] {new Cell(C, 0), new Cell(C, 2)};
            var c1WinConditions = new[] {c1RowWinCondition, c1ColumnWinCondition};
            return c1WinConditions;
        }

        private static Cell[][] GetA2WinConditions()
        {
            var a2RowWinCondition = new[] {new Cell(B, 2), new Cell(C, 2)};
            var a2ColumnWinCondition = new[] {new Cell(A, 0), new Cell(A, 1)};
            var a2DiagonalWinCondition = new[] {new Cell(B, 1), new Cell(C, 0)};
            var a2WinConditions = new[] {a2RowWinCondition, a2ColumnWinCondition, a2DiagonalWinCondition};
            return a2WinConditions;
        }

        private static Cell[][] GetB2WinConditions()
        {
            var b2RowWinCondition = new[] {new Cell(A, 2), new Cell(C, 2)};
            var b2ColumnWinCondition = new[] {new Cell(B, 0), new Cell(B, 1)};
            var b2WinConditions = new[] {b2RowWinCondition, b2ColumnWinCondition};
            return b2WinConditions;
        }

        private static Cell[][] GetC2WinConditions()
        {
            var c2RowWinCondition = new[] {new Cell(A, 2), new Cell(B, 2)};
            var c2ColumnWinCondition = new[] {new Cell(C, 0), new Cell(C, 1)};
            var c2DiagonalWinCondition = new[] {new Cell(B, 1), new Cell(A, 0)};
            var c2WinConditions = new[] {c2RowWinCondition, c2ColumnWinCondition, c2DiagonalWinCondition};
            return c2WinConditions;
        }
    }
}