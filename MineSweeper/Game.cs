using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
  public class Game
  {
    private SquareType[,] _field;
    private int _numberOfMines;
    private IMinePlacementGeneration _minePlacementGeneration;

    public Game(int rowDimension, int columnDimension, int numberOfMines, IMinePlacementGeneration minePlacementGeneration)
    {
      _field = new SquareType[rowDimension, columnDimension];
      _numberOfMines = numberOfMines;
      _minePlacementGeneration = minePlacementGeneration;
      InitializeField();
    }

    public SquareType[,] GetField()
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
        _field[index.Row, index.Column] = SquareType.Mine;
      }
    }
    public HashSet<RowColumn> GetClues(RowColumn userSquareSelection)
    {
    


      HashSet<RowColumn> clues;
      return clues;
    }

    public bool IsMine(RowColumn index)
    {
      return Equals(SquareType.Mine, _field[index.Row, index.Column]);
    }
  }
}
