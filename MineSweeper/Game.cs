using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
  public class Game
  {
    private CellContents[,] _field;
    private int _numberOfMines;

    public Game(int rowDimension, int columnDimension, int numberOfMines)
    {
      _field = new CellContents[rowDimension, columnDimension];
      _numberOfMines = numberOfMines;
      InitializeField();
    }

    public CellContents[,] GetField()
    {
      return _field;
    }

    private void InitializeField()
    {
      HashSet<RowColumn> mines = GetRandomIndexesForMines();
      PlaceMines(mines);
    }
    private void PlaceMines(HashSet<RowColumn> mines)
    {
      foreach (RowColumn index in mines)
      {
        _field[index.Row, index.Column] = CellContents.Mine;
      }
    }
    private HashSet<RowColumn> GetRandomIndexesForMines()
    {
      HashSet<RowColumn> mines = new HashSet<RowColumn>();
      for (int i = 0; i < _numberOfMines; i++)
      {
        var rnd = new Random();
        int rndRow = rnd.Next(0, _field.GetLength(0) + 1);
        int rndCol = rnd.Next(0, _field.GetLength(1) + 1);
//duplicates
//bc a set, it will not add a duplicate. so could come short one or two mines
        mines.Add(new RowColumn(rndRow, rndCol));
      }
      return mines;
    }

  }
}
