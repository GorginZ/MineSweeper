using System.Collections.Generic;

namespace MineSweeper
{
  public class SetMinePlacement : IMinePlacementGeneration
  {
  public HashSet<RowColumn> setListOfMines;
    
    public SetMinePlacement(HashSet<RowColumn> hashSetOfMines)
    {
      setListOfMines = hashSetOfMines;
    }
    public HashSet<RowColumn> GetMinePositions(int rowDimension, int columnDimension, int numberOfMines)
    {
      return setListOfMines;
    }
  }
}