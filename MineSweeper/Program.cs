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
      userInput.GetValidDimensions();
      // userInput.SquareDimensions = 0;
      var minePositioning = new RandomMinePositions(userInput.SquareDimensions, userInput.SquareDimensions, userInput.SquareDimensions);
      // var minePositioning = new SetMinePositions(new HashSet<RowColumn>{});
      var mineField = new MineField(userInput.SquareDimensions, userInput.SquareDimensions, minePositioning);
      GamePlay.Run(outPut, userInput, mineField);
    }
  }
}

