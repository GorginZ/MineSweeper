using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
  public class Game
  {
    private Grid<CellContents> _field;
    private int _numberOfMines;

    public Game(int rowDimension, int columnDimension, int numberOfMines)
    {
      _field = new Grid<CellContents>(rowDimension, columnDimension);
      _numberOfMines = numberOfMines;

      InitializeField(rowDimension, columnDimension);
    }

    public Grid<CellContents> GetField()
    {
      return _field;
    }

    private void InitializeField(int rowDimension, int columnDimension)
    {
      HashSet<RowColumn> mines = new HashSet<RowColumn>();
      this._field.SetAllCells(CellContents.Safe);

      for (int i = _numberOfMines; i != 0; i--)
      {
        var rnd = new Random();
        int rndRow = rnd.Next(rowDimension, columnDimension);
        int rndCol = rnd.Next(rowDimension, columnDimension);
        mines.Add(new RowColumn(rndRow, rndCol));
      }
      this._field.SetMany(mines, CellContents.Mine);
    }


  }
}
