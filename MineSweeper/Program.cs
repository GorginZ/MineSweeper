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
      var dimensions = userInput.GetValidDimensions();
      var minePositioning = new RandomMinePositions(dimensions, dimensions, dimensions);
      var mineField = new MineField(dimensions, dimensions, minePositioning);
      GamePlay.Run(outPut, userInput, mineField);
    }
  }
}

