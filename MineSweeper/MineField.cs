using System.Collections.Generic;

namespace MineSweeper
{
  public class MineField
  {
    public Square[,] Field;
    public int RowDimension;
    public int ColumnDimension;
    private int _numberOfMines;
    private IMinePlacementGeneration _minePlacementGeneration;
    public MineField(int rowDimension, int columnDimension, int numberOfMines, IMinePlacementGeneration minePlacementGeneration)
    {
      Field = new Square[rowDimension, columnDimension];
      _numberOfMines = numberOfMines;
      _minePlacementGeneration = minePlacementGeneration;
      InitializeField();
    }
    private void InitializeField()
    {
      HashSet<RowColumn> mines = _minePlacementGeneration.GetMinePositions(RowDimension, ColumnDimension, _numberOfMines);
      PlaceMines(mines);
      SetClues();

    }
    private void PlaceMines(HashSet<RowColumn> mines)
    {
      foreach (RowColumn index in mines)
      {
        Field[index.Row, index.Column].SquareType = SquareType.Mine;
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
      return rowColumn.Row < 0 || rowColumn.Row >= Field.GetLength(0) || rowColumn.Column < 0 || rowColumn.Column >= Field.GetLength(1);
    }
    public int AdjacentMineCount(HashSet<RowColumn> neighbourList)
    {
      int count = 0;

      foreach (RowColumn index in neighbourList)
      {
        if (Field[index.Row, index.Column].SquareType == SquareType.Mine)
        {
          count++;
        }
      }
      return count;
    }
    private void SetClues()
    {
      for (int row = 0; row < RowDimension; row++)
      {
        for (int column = 0; column < ColumnDimension; column++)
        {
          HashSet<RowColumn> neighbours = GetNeighboursOfSquare(row, column);
          int value = AdjacentMineCount(neighbours);
          Field[row, column].SquareValue = value;
        }
      }
    }

    
    

  }
}