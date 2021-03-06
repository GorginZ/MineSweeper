using System;
using System.Collections.Generic;

namespace MineSweeper
{
  public class RandomMinePositions : IMinePositions
  {
    private readonly int _rowDimension;
    private readonly int _columnDimension;
    private readonly int _numberOfMines;

    public RandomMinePositions(int rowDimension, int columnDimension, int numberOfMines)
    {
      _rowDimension = rowDimension;
      _columnDimension = columnDimension;
      _numberOfMines = numberOfMines;
    }
    public IEnumerable<RowColumn> GetMinePositions()
    {
      if (_numberOfMines > (_rowDimension * _columnDimension))
      {
        throw new ArgumentException("numberOfMines exceeds array capacity", $"{_numberOfMines}");
      }
      var rnd = new Random();
      HashSet<RowColumn> minesPositions = new HashSet<RowColumn>();

      for (int i = 0; i < _numberOfMines;)
      {
        int rndRow = rnd.Next(0, _rowDimension);
        int rndCol = rnd.Next(0, _columnDimension);
        var mineLocation = new RowColumn(rndRow, rndCol);
        if (!minesPositions.Contains(mineLocation))
        {
          minesPositions.Add(mineLocation);
          i++;
        }
      }
      return minesPositions;
    }
  }
}