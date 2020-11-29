using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

namespace MineSweeper
{
  public class MineField : IEnumerable<Square>
  {
    private readonly Square[,] _field;
    public int RowDimension => _field.GetLength(0);
    public int ColumnDimension => _field.GetLength(1);
    public int MineCount => this.Count(square => square.SquareType == SquareType.Mine);
    public int RevealedCount => Coordinates().Where(IsRevealed).Count();

    private readonly IMinePositions _minePositioning;
    public MineField(int rowDimension, int columnDimension, IMinePositions minePositioning)
    {
      if (rowDimension < 2 || columnDimension < 2)
      {
        throw new ArgumentException("row and column dimensions are below minimum usable value");
      }
      _field = new Square[rowDimension, columnDimension];
      _minePositioning = minePositioning;
      try
      {
        InitializeField();
      }
      catch (IndexOutOfRangeException)
      {
        throw new ArgumentException("Mine list contains elements greater than field array dimensions");
        //delete this object/clean up memory
      }
    }
    public Square this[RowColumn coord] => _field[coord.Row, coord.Column];

    private void InitializeField()
    {
      FillFieldWithSquares();
      var mines = _minePositioning.GetMinePositions();
      PlaceMines(mines);
      SetSquareHintValues();
    }
    private void FillFieldWithSquares()
    {
      foreach (var coord in Coordinates())
      {
        _field[coord.Row, coord.Column] = new Square(SquareType.Zero);
      }
    }

    private void PlaceMines(IEnumerable<RowColumn> mines)
    {
      //try or throw somth here if out of bounds
      foreach (RowColumn index in mines)
      {
        this[index].SquareType = SquareType.Mine;
      }
    }
    public IEnumerable<RowColumn> GetNeighboursOfSquare(int row, int column)
    {
      var leftNeighbour = (column - 1);
      var rightNeighbour = (column + 1);
      var upNeighbour = (row - 1);
      var downNeighbour = (row + 1);

      var neighbourList = new List<RowColumn>{
        new RowColumn(row, rightNeighbour), new RowColumn(row, leftNeighbour), new RowColumn(upNeighbour, column), new RowColumn(downNeighbour, column), new RowColumn(upNeighbour, rightNeighbour), new RowColumn(upNeighbour, leftNeighbour), new RowColumn(downNeighbour, rightNeighbour), new RowColumn(downNeighbour, leftNeighbour)
        };
      neighbourList.RemoveAll(OutOfRange);
      return neighbourList;
    }
    private bool OutOfRange(RowColumn rowColumn)
    {
      return rowColumn.Row < 0 || rowColumn.Row >= _field.GetLength(0) || rowColumn.Column < 0 || rowColumn.Column >= _field.GetLength(1);
    }
    public int AdjacentMineCount(IEnumerable<RowColumn> neighbourList)
    {
      var count = 0;

      foreach (RowColumn index in neighbourList)
      {
        if (_field[index.Row, index.Column].SquareType == SquareType.Mine)
        {
          count++;
        }
      }
      return count;
    }
    private void SetSquareHintValues()
    {
      for (int row = 0; row < RowDimension; row++)
      {
        for (int column = 0; column < ColumnDimension; column++)
        {
          if (_field[row, column].SquareType != SquareType.Mine)
          {
            var neighbours = GetNeighboursOfSquare(row, column);
            int value = AdjacentMineCount(neighbours);
            _field[row, column].SquareType = (SquareType)value;
          }
        }
      }
    }
    public string FieldAsString()
    {
      var printableField = new StringBuilder();
      for (int i = 0; i < this.RowDimension; i++)
      {
        for (int j = 0; j < this.ColumnDimension; j++)
        {
          printableField.Append(this._field[i, j].SquareAsString());
        }
        printableField.Append("\n");
      }
      return printableField.ToString();
    }

    public IEnumerable<RowColumn> Coordinates()
    {
      for (int row = 0; row < RowDimension; row++)
      {
        for (int column = 0; column < ColumnDimension; column++)
        {
          yield return new RowColumn(row, column);
        }
      }
    }
    public bool IsRevealed(RowColumn index)
    {
      return this[index].IsRevealed;
    }

    public IEnumerator<Square> GetEnumerator() => _field.Cast<Square>().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}