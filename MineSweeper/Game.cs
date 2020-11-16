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

    }
    private void PlaceMines(HashSet<RowColumn> mines)
    {
      foreach (RowColumn index in mines)
      {
        _field[index.Row, index.Column].SquareType = SquareType.Mine;
        _field[index.Row, index.Column].SquareValue = SquareValue.Mine;
      }
    }
    private void SetClues()
    {
      for (int row = 0; row < _field.GetLength(0); row++)
      {
        for (int column = 0; column < _field.GetLength(1); column++)
        {
          _field[row,column].CalculateNeighbours
          CalculateNeighbouringValues.
        }
      }
    }


    public bool IsMine(RowColumn index)
    {
      return Equals(SquareType.Mine, _field[index.Row, index.Column]);
    }
  }
}
