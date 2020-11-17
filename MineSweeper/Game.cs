using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
  public class Game
  {
    private Square[,] _field;
    private int _numberOfMines;
    private IMinePlacementGeneration _minePlacementGeneration;

    public Game(int rowDimension, int columnDimension, int numberOfMines, IMinePlacementGeneration minePlacementGeneration)
    {
      _field = new Square[rowDimension, columnDimension];
      _numberOfMines = numberOfMines;
      _minePlacementGeneration = minePlacementGeneration;
      InitializeField();
    }

    public Square[,] GetField()
    {
      return _field;
    }

    private void InitializeField()
    {
      HashSet<RowColumn> mines = _minePlacementGeneration.GetMinePositions(_field.GetLength(0), _field.GetLength(1), _numberOfMines);
      PlaceMines(mines);
      SetClues();

    }
    private void PlaceMines(HashSet<RowColumn> mines)
    {
      foreach (RowColumn index in mines)
      {
        _field[index.Row, index.Column].SquareType = SquareType.Mine;
      }
    }

    public bool IsMine(RowColumn index)
    {
      return SquareType.Mine == _field[index.Row, index.Column].SquareType;
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
        if (IsMine(index))
        {
          count++;
        }
      }
      return count;
    }
    private void SetClues()
    {
      for (int row = 0; row < _field.GetLength(0); row++)
      {
        for (int column = 0; column < _field.GetLength(1); column++)
        {
          HashSet<RowColumn> neighbours = GetNeighboursOfSquare(row, column);
          int value = AdjacentMineCount(neighbours);
          _field[row, column].SquareValue = value;
        }
      }
    }

  }
}