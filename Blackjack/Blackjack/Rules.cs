namespace Blackjack;

public static class Rules
{
    public const int BlackJack = 21;
    public const int FaceCardValue = 10;
    public const string Stay = "0";
    public const string Hit = "1";
    public const int DealerStandOn = 17;

    public static bool IsBust(Player player)
    {
        var isBust = player.Points > BlackJack;
        return isBust;
    }
}