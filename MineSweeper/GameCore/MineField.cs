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
    public int RevealedCount => Indexes().Where(IsRevealed).Count();

    private readonly IMinePositions _minePositioning;
    public MineField(int rowDimension, int columnDimension, IMinePositions minePositioning)
    {
      _field = new Square[rowDimension, columnDimension];
      _minePositioning = minePositioning;
      try
      {
        InitializeField();
      }
      catch (IndexOutOfRangeException)
      {
        throw new ArgumentException("Mine list contains elements greater than field array dimensions");
      }
    }
    public Square this[RowColumn index] => _field[index.Row, index.Column];

    private void InitializeField()
    {
      FillFieldWithSquares();
      var mines = _minePositioning.GetMinePositions();
      // MineCount = mines.Count();
      PlaceMines(mines);
      SetSquareHintValues();
    }
    private void FillFieldWithSquares()
    {
      foreach (var index in Indexes())
      {
        _field[index.Row, index.Column] = new Square(SquareType.Zero);
      }
    }
    private void PlaceMines(IEnumerable<RowColumn> mines)
    {
      foreach (RowColumn index in mines)
      {
        this[index].SquareType = SquareType.Mine;
      }
    }
    public IEnumerable<RowColumn> GetNeighboursOfSquare(int row, int column)
    {
      var leftNeighbour = column - 1;
      var rightNeighbour = column + 1;
      var upNeighbour = row - 1;
      var downNeighbour = row + 1;

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
        if (this[index].SquareType == SquareType.Mine)
        {
          count++;
        }
      }
      return count;
    }
    private void SetSquareHintValues()
    {
      foreach (RowColumn index in Indexes())
      {
        if (this[index].SquareType != SquareType.Mine)
        {
          var neighbours = GetNeighboursOfSquare(index.Row, index.Column);
          int value = AdjacentMineCount(neighbours);
          this[index].SquareType = (SquareType)value;
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

    public IEnumerable<RowColumn> Indexes()
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
    public bool IsNotMine(RowColumn index)
    {
      return this[index].SquareType == SquareType.Mine;
    }
    public void MineHitOnFirstHitReArrange(RowColumn firstHit)
    {
      foreach (var index in Indexes())
      {
        if (this[index].SquareType != SquareType.Mine && !index.Equals(firstHit))
        {
          this[index].SquareType = SquareType.Mine;
          this[firstHit].SquareType = SquareType.Zero;
          this.SetSquareHintValues();
          return;
        }
      }
    }

    public IEnumerator<Square> GetEnumerator() => _field.Cast<Square>().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}