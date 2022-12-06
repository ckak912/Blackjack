using Blackjack;
using Blackjack.Interfaces;

namespace Blackjack.Test.IO;

public class FakeConsoleOutput : IOutput
{
    private const string WelcomeMessage = "Welcome to BlackJack!";
    private const string DealerDealsMessage = "Please wait while the dealer deals the cards ...";
    private const string AskPlayerHitOrStay = "\n Hit or stay? (Hit = 1, Stay = 0) "; 
    private const string InvalidMoveMessage = "Invalid move.";
    private const string PlayerWinsMessage = "\n You beat the dealer! Congrats!";
    private const string DealerWinsMessage = "\n Unlucky. The dealer beat you!";
    private const string DrawGameMessage = "\n Draw game. Thanks for playing.";
    
    public List<string> TestOutput { get;  }

    public FakeConsoleOutput()
    {
        TestOutput = new List<string>();
    }
    public void PrintStartGameMessage()
    {
        TestOutput.Add(WelcomeMessage);
        TestOutput.Add(DealerDealsMessage);
    }

    public void PrintTotalPointsAndHand(Player player)
    {
        TestOutput.Add("\n" + GenerateTotalPointsAndCurrentHandMessage(player));
    }

    public void PrintAskPlayerHitOrStay()
    {
        TestOutput.Add(AskPlayerHitOrStay);
    }

    public void PrintCardDrawnMessage(Player player, Cards cards)
    {
        TestOutput.Add(GenerateCardDrawnMessage(player, cards));
    }

    public void PrintPlayerChoseHitOrStay(string playerMove)
    {
        TestOutput.Add(playerMove);
    }

    public void PrintEnterValidMove()
    {
        TestOutput.Add(InvalidMoveMessage);
        PrintAskPlayerHitOrStay();
    }

    public void PrintPlayerWinsMessage()
    {
        TestOutput.Add(PlayerWinsMessage);
    }

    public void PrintDealerWinsMessage()
    {
        TestOutput.Add(DealerWinsMessage);
    }

    public void PrintDrawGameMessage()
    {
        TestOutput.Add(DrawGameMessage);
    }

    private string GenerateTotalPointsAndCurrentHandMessage(Player player)
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

    private string GenerateCardDrawnMessage(Player player, Cards cards)
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