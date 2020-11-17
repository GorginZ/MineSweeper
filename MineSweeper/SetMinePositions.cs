using System.Collections.Generic;

namespace MineSweeper
{
  public class SetMinePositions : IMinePositions
  {
  public HashSet<RowColumn> setListOfMines;
    
    public SetMinePositions(HashSet<RowColumn> hashSetOfMines)
    {
      setListOfMines = hashSetOfMines;
    }
    public HashSet<RowColumn> GetMinePositions(int rowDimension, int columnDimension, int numberOfMines)
    {
      return setListOfMines;
    }
  }
}