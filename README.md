# MineSweeper

## Planning and Design (WIP) :)
#### DataFlow Diagram(WIP)

Really this is just for planning the game flow which is low on my priority list but worth running through because I never played mine sweeper when i was younger so I needed to clarify what my game progression might look like.

<img src="docs/DFD.png">

#### Class Diagram (WIP)

I began a class diagram before I started work on MineSweeper but kept it very basic, restricted to what I knew I would implement first off.

 I have added to it and changed it each day as I make decisions as particular problems and solutions present themselves. 

For instance today (17/11/20) I pulled off my minefield into a seperate class while working on my 'HintCalculation' card. 



<img src="docs/ClassDiagram.png">





#### TDD

I rely heavily on my unit tests to know that something I'm implementing or changing is working. 

I won't be running my program until I need to implement console gameplay - that is, I aim to be particularly strict and confident I can depend upon my unit tests. Long live hello world.

```C#
using System;

namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

```

#### Dependency Injection

I have strived to implement dependency injection design patterns in my class structure for this kata. There are a few sites I hope to adhere to this pattern but one instance early on in building MineSweeper is my MineField class. The minefield and its associated initilization do not relate to the game play or rules itself, so today, after writing initial logic for my game-ready field initilization I pulled off everything into a seperate MineField class. 

This has a few benefits I can see

- It's open to modification: I am free to change around the MineField class it as I please without interupting anything I may work on in the Game class or elsewhere.
- everything is more testable: my game class's tests aren't bogged down by field initilization tests, and furthermore everythin else in my game class I may want to test isn't dependent on too many other functions in my game class, I just need to pass in a field. It's easier to pinpoint any problems when things are split up this way.

#### YAGNI

This will continue to be a theme and one I struggle most being strict with. As someone who is learning and has a powerful imagination and therefore often pretty excited when I'm working. Sometimes when the ball is rolling I can end up adding in lots of extra details. My mentors Frank and Bianca have, when we dicsussed this, given me good alternatives - for instance adding a trello card or plopping it down somewhere else. 

I knew when I showed some changes that I would be pulled up on the below bool properties on this newly added struct.
I needed my new Square struct, but I didn't need those bools, but they belongd there so I put them in because I couldn't help it. But I removed them straight away when I started showing my work and it came up in conversation - I appreciate why this rule exists. These bools look innocent enough but sometimes (and more usually for me) it's something bigger that runs away with you. That's why I'm being more stringent on this one this time round and have asked my mentors to keep a tight rein here.

```C#
namespace MineSweeper
{
    public struct Square
    {
      public SquareType SquareType;
      public int SquareHintValue;
      public bool Flagged; // <=== offending property
      public bool Revealed;// <=== offending property
        
    }
}
```

