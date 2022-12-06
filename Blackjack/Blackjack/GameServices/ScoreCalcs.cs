using System.Linq;

namespace Blackjack.GameServices;

public class ScoreCalcs
{
    private const int AceCardValue = 11;
    private const int AceCardAsOnePoint = (int)Number.Ace; //ace can be considered 11 unless it brings the player over 21, in which case it counts as 1 

    public static int ComputeTotalPoints(Player player)
    {
        var numberOfAces = player.Hand.Count(x => x.Number == Number.Ace);
        var nonAceCardPoints = GetNonAceCardValue(player);
        var totalPoints = AddAceCardValueToTotalPlayerPoints(nonAceCardPoints, numberOfAces);
        return totalPoints;
    }

    private static int GetNonAceCardValue(Player player)
    {
        var points = 0;
        foreach (var card in player.Hand)
        {
            if (IsAce(card)) continue;
            var cardIsJackKingOrQueen = card.Number > Number.Ten;
            var nonFaceCardValue = (int)card.Number;
            points += cardIsJackKingOrQueen ? Rules.FaceCardValue : nonFaceCardValue;
        }
        return points;
    }

    private static bool IsAce(Cards cards)
    {
        return cards.Number == Number.Ace;
    }

    private static int AddAceCardValueToTotalPlayerPoints(int points, int numberOfAces)
    {
        for (var i = 0; i < numberOfAces; i++)
        {
            var isLessThanTwentyOne =
                points + AceCardValue <= Rules.BlackJack;

            if (isLessThanTwentyOne)
                points += AceCardValue;
            else
                points += AceCardAsOnePoint;
        }

        return points;
    }
}