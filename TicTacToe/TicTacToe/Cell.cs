namespace TicTacToe
{
    /// <summary>
    /// Represents a single cell in a grid
    /// Columns are letters like in Excel (A, B, C, etc.) See Cell.ColumnNames.cs
    /// Rows start at 0
    /// </summary>
    public partial class Cell
    {
        public int Column { get; }
        public int Row { get; }

        public string FriendlyName => "" + (ColumnNames) Column + Row;

        public Cell(ColumnNames column, int row)
        {
            Column = (int) column;
            Row = row;
        }
    }
}