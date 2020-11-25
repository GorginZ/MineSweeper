using System;
using System.Collections.Generic;
using MineSweeper.ConsoleImplementation;

namespace MineSweeper
{
  class Program
  {
    static void Main(string[] args)
    {
      var userInput = new ConsoleInput();
      var outPut = new ConsoleOutput();
      // userInput.PromptDimensions();
      // var minePositioning = new RandomMinePositions(userInput.SquareDimensions, userInput.SquareDimensions, userInput.SquareDimensions);
      // var mineField = new MineField(userInput.SquareDimensions, userInput.SquareDimensions, minePositioning);
      var minePositions = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0) });
      var mineField = new MineField(4, 4, minePositions);
      GamePlay.Run(outPut, userInput, mineField);
    }
  }
}

