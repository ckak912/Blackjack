namespace Blackjack.Services;

public static class CheckIfWon
{
    public static Player DecideWinner(Player dealer, Player player)
    {
        var dealerWins = player.Points > Rules.BlackJack ||
                         dealer.Points <= Rules.BlackJack && dealer.Points > player.Points;
        return dealerWins ? dealer : player;
    }
    
    public static bool CheckIfDraw(Player dealer, Player player)
    {
        return player.Points == dealer.Points;
    }
    
}