namespace Blackjack;

public class ConsoleOutput
{
    private const string WelcomeMessage = "Welcome to BlackJack!";
    private const string DealerDealsMessage = "Please wait while the dealer deals the cards ...";
    private const string AskPlayerHitOrStay = "\n Hit or stay? "; //TODO: implement Hit = 1 , Stay = 0 or text input
    private const string InvalidMoveMessage = "Invalid move.";
    private const string PlayerWinsMessage = "\n You beat the dealer! Congrats!";
    private const string DealerWinsMessage = "\n Unlucky. The dealer beat you!";
    private const string DrawGameMessage = "\n Draw game. Thanks for playing.";
    
    //TODO: 
    //  1) method to print total points of player hand and the subsequent message
    //  2) method to print the card that is drawn from dealer

    public void PrintStartGameMessage()
    {
        Console.WriteLine(WelcomeMessage);
        Console.WriteLine(DealerDealsMessage);
    }

    public void PrintAskPlayerHitOrStay()
    {
        Console.WriteLine(AskPlayerHitOrStay);
    }

    public void PrintEnterValidMove()
    {
        Console.WriteLine(InvalidMoveMessage);
        PrintAskPlayerHitOrStay();  //if invalid, console should print again to hit or stay
    }

    public void PrintPlayerWinsMessage()
    {
        Console.WriteLine(PlayerWinsMessage);
    }

    public void PrintDealerWinsMessage()
    {
        Console.WriteLine(DealerWinsMessage);
    }

    public void PrintDrawGameMessage()
    {
        Console.WriteLine(DrawGameMessage);
    }
    
}