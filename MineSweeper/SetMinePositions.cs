using System.Collections.Generic;

namespace MineSweeper
{
  //this class isn't clear and has confused behaviour. arbitrary arguments for its implementation of getminepositions member
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