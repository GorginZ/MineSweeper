using System;
using System.Collections.Generic;

namespace MineSweeper
{
  public class RandomMinePositions : IMinePositions
  {
    public HashSet<RowColumn> GetMinePositions(int rowDimension, int columnDimension, int numberOfMines)
    {
      var rnd = new Random();
      HashSet<RowColumn> minesPositions = new HashSet<RowColumn>();

      for (int i = 0; i < numberOfMines;)
      {
        int rndRow = rnd.Next(0, rowDimension);
        int rndCol = rnd.Next(0, columnDimension);
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