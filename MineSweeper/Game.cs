using System;
using System.Collections.Generic;

namespace MineSweeper
{
  public class Game
  {
    private Grid<CellContents> _field;

    public Game(int rowDimension, int columnDimension)
    {
      _field = new Grid<CellContents>(rowDimension, columnDimension);
    }

    public Grid<CellContents> GetField()
    {
      return _field;
    }


    public void InitializeField(List<RowColumn> CoordinatesList)
    {
      this._field.SetMany(CoordinatesList, CellContents.Safe);
      this._field.SetMany(CoordinatesList, CellContents.Mine);
    }


  }
}
