using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
  public class MineField : IEnumerable<Square>
  {
    private readonly Square[,] _field;
    public int RowDimension => _field.GetLength(0);
    public int ColumnDimension => _field.GetLength(1);
    private readonly IMinePositions _minePositioning;
    public MineField(int rowDimension, int columnDimension, IMinePositions minePositioning)
    {
      _field = new Square[rowDimension, columnDimension];
      _minePositioning = minePositioning;
      InitializeField();

    }

    public Square this[RowColumn coord] => _field[coord.Row, coord.Column];

    private void InitializeField()
    {
      FillFieldWithSquares();
      HashSet<RowColumn> mines = _minePositioning.GetMinePositions();
      PlaceMines(mines);
      SetSquareHintValues();

    }
    private void FillFieldWithSquares()
    {
      foreach (var coord in Coordinates())
      {
        _field[coord.Row, coord.Column] =  new Square(SquareType.Safe, 0);
      }
    }

    private void PlaceMines(HashSet<RowColumn> mines)
    {
      foreach (RowColumn index in mines)
      {
        this[index].SquareType = SquareType.Mine;
      }
    }
    public HashSet<RowColumn> GetNeighboursOfSquare(int row, int column)
    {
      var leftNeighbour = (column - 1);
      var rightNeighbour = (column + 1);
      var upNeighbour = (row - 1);
      var downNeighbour = (row + 1);

      HashSet<RowColumn> neighbourList = new HashSet<RowColumn>{
        new RowColumn(row, rightNeighbour), new RowColumn(row, leftNeighbour), new RowColumn(upNeighbour, column), new RowColumn(downNeighbour, column), new RowColumn(upNeighbour, rightNeighbour), new RowColumn(upNeighbour, leftNeighbour), new RowColumn(downNeighbour, rightNeighbour), new RowColumn(downNeighbour, leftNeighbour)
        };
      neighbourList.RemoveWhere(OutOfRange);
      return neighbourList;
    }
    private bool OutOfRange(RowColumn rowColumn)
    {
      return rowColumn.Row < 0 || rowColumn.Row >= _field.GetLength(0) || rowColumn.Column < 0 || rowColumn.Column >= _field.GetLength(1);
    }
    public int AdjacentMineCount(HashSet<RowColumn> neighbourList)
    {
      int count = 0;

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
          HashSet<RowColumn> neighbours = GetNeighboursOfSquare(row, column);
          int value = AdjacentMineCount(neighbours);
          _field[row, column].SquareHintValue = value;
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
    public void MineHitOnFirstHitReArrange(RowColumn firstHit)
    {
      _field[firstHit.Row, firstHit.Column].SquareType = SquareType.Safe;

      if (_field[0, 0].SquareType == SquareType.Safe)
      {
        _field[0, 0].SquareType = SquareType.Mine;
        SetSquareHintValues();
        return;
      }
      for (int i = 0; i < 1;)
      {
        for (int j = 0; j < 1;)
        {
          if (_field[i, j].SquareType == SquareType.Safe)
          {
            _field[i, j].SquareType = SquareType.Mine;
            SetSquareHintValues();
            i++;
            j++;
          }
        }
      }
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

    public IEnumerator<Square> GetEnumerator() => (IEnumerator<Square>)_field.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}