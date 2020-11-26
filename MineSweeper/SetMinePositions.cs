using System.Collections.Generic;

namespace MineSweeper
{
  public class SetMinePositions : IMinePositions
  {
    public IEnumerable<RowColumn> setListOfMines;
    public SetMinePositions(HashSet<RowColumn> hashSetOfMines)
    {
      setListOfMines = hashSetOfMines;
    }
    public IEnumerable<RowColumn> GetMinePositions() => setListOfMines;
  }
}