namespace Blackjack.Interfaces;
//This class is a child of ConsoleInput.cs
public interface IOutput
{
    public void PrintStartGameMessage();
    public void PrintTotalPointsAndHand(Player player);
    public void PrintCardDrawnMessage(Player player, Cards cards);
    public void PrintPlayerWinsMessage();
    public void PrintDealerWinsMessage();
    public void PrintDrawGameMessage();
}