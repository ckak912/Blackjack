using Blackjack.Interfaces; //Implement

namespace Blackjack.IO;
//These IO classes will be called by the Interfaces folder to bring forward their functionality into the game 
public class ConsoleInput : IReadLine
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }

}