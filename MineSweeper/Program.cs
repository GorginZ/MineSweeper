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
      var gamePlay = new GamePlay(outPut, userInput);
      gamePlay.Run();
    }
  }
}

