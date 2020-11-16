using System;
using System.Collections.Generic;

namespace MineSweeper
{
    public class RandomMinePlacement :IMinePlacementGeneration
    {
    public HashSet<RowColumn> GetMinePositions(int rowDimension, int columnDimension, int _numberOfMines)
    {
      var rnd = new Random();
      HashSet<RowColumn> mines = new HashSet<RowColumn>();

      for (int i = 0; i < _numberOfMines;)
      {
        int rndRow = rnd.Next(0, rowDimension);
        int rndCol = rnd.Next(0, columnDimension);
        if (!mines.Contains(new RowColumn(rndRow, rndCol)))
        {
          mines.Add(new RowColumn(rndRow, rndCol));
          i++;
        }
      }
      return mines;
    }
        
    }
}