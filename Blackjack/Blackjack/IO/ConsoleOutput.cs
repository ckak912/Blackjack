using Blackjack.Interfaces;

namespace Blackjack.IO;

public class ConsoleOutput : IOutput //IOutput implemented halfway 
{
    private const string WelcomeMessage = "Welcome to BlackJack!";
    private const string DealerDealsMessage = "Please wait while the dealer deals the cards ...";
    private const string AskPlayerHitOrStay = "\n Hit or stay? (Hit = 1, Stay = 0) "; 
    private const string InvalidMoveMessage = "Invalid move.";
    private const string PlayerWinsMessage = "\n You beat the dealer! Congrats!";
    private const string DealerWinsMessage = "\n Unlucky. The dealer beat you!";
    private const string DrawGameMessage = "\n Draw game. Thanks for playing.";
    
    //TODO: 
    //  1) method to print total points of player hand and the subsequent message
    //  2) method to print the card that is drawn from dealer
    // both methods should be reflected in IOutput file i.e new methods should be called

    public void PrintStartGameMessage()
    {
        Console.WriteLine(WelcomeMessage);
        Console.WriteLine(DealerDealsMessage);
    }

    public void PrintTotalPointsAndHand(Player player)
    {
        Console.WriteLine("\n" + GenerateTotalPointsAndCurrentHandMessage(player));
    }

    public void PrintCardDrawnMessage(Player player, Cards cards)
    {
        Console.WriteLine(GenerateCardDrawnMessage(player, cards));
    }

    public void PrintAskPlayerHitOrStay()
    {
        Console.WriteLine(AskPlayerHitOrStay);
    }

    public void PrintPlayerChoseHitOrStay(string playerMove)
    {
        Console.WriteLine(playerMove);
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

    public static string GenerateTotalPointsAndCurrentHandMessage(Player player)
    {
        var totalPointsAndHandMessage = player.Name + " " + player.Verb + " currently at ";
        totalPointsAndHandMessage += player.IsBust ? "Bust!" : player.Points;
        totalPointsAndHandMessage += "\nwith the hand [";
        if (player.Hand == null) return totalPointsAndHandMessage + "]";
        foreach (var card in player.Hand)
        {
            if (card.Number is > Number.Ten or Number.Ace)
                totalPointsAndHandMessage += "['" + card.Number + "', '";
            else
                totalPointsAndHandMessage += "[" + (int)card.Number + ", '";
            totalPointsAndHandMessage += card.Suit + "']";
            var lastCard = card == player.Hand?[^1]; //last index
            if (!lastCard)
                totalPointsAndHandMessage += " , ";
        }

        return totalPointsAndHandMessage + "]";

    }

    private static string GenerateCardDrawnMessage(Player player, Cards cards)
    {
        var cardDrawnMessage = player.Name;
        if (player.Name == "You")
            cardDrawnMessage += " draw [";
        else
            cardDrawnMessage += " draw [";
        if (cards.Number is > Number.Ten or Number.Ace)
            cardDrawnMessage += " ' " + cards.Number + "', '" + cards.Suit + "']";
        else
            cardDrawnMessage += (int)cards.Number + ", '" + cards.Suit + "']";
        return cardDrawnMessage;
    }
    
}