using System.Collections.Generic;
using MineSweeper.ConsoleImplementation;
using Xunit;

namespace MineSweeper.Tests
{
  public class ConsoleOutPutTests
  {
    [Fact]
    public void CanVisualizeField()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(2, 2), new RowColumn(4, 4) });
      var consoleVisuzlier = new ConsoleOutput();
      var mineField = new MineField(5, 5, 5, minePositioning);

      var expectedField = "*1   \n"
                        + "1211 \n"
                        + " 1*1 \n"
                        + " 1121\n"
                        + "   1*\n";

      Assert.Equal(expectedField, consoleVisuzlier.FieldAsString(mineField));





    }
  }
}