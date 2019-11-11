using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        private readonly string[,]  _cells;
        private readonly WinConditions _winConditions;

        public Board(int numberOfColumns, int numberOfRows)
        {
            ValidateParameters(numberOfColumns, numberOfRows);
            _cells = new string[numberOfRows,numberOfColumns];
            _winConditions = new WinConditions();
        }

        public bool MarkCell(Cell cell, string playerToken)
        {
            if (!CellCanBeMarked(cell)) return false;
            
            _cells[cell.Row, cell.Column] = playerToken;
            return true;
        }

        public string GetCellMark(Cell cell)
        {
            return _cells[cell.Row, cell.Column];
        }

        public IEnumerable<Cell[]> GetWinConditionsForCell(Cell cell)
        {
            return _winConditions.GetWinConditionsForCell(cell);
        }

        private static void ValidateParameters(int numberOfColumns, int numberOfRows)
        {
            if (numberOfColumns <= 0 || numberOfRows <= 0)
            {
                throw new ArgumentException("Both numberOfColumns and numberOfRows " +
                                            "must be greater than 0 to create a board. " +
                                            "numberOfColumns: " + numberOfColumns + " Rows: " + numberOfRows);
            }
        }

        private bool CellCanBeMarked(Cell cell)
        {
            return string.IsNullOrEmpty(_cells[cell.Row, cell.Column]);
        }
    }
}