using Blackjack.GameServices;
using Blackjack;
using Xunit;

namespace Blackjack.Test;

public class RulesTest
{
    [Fact]
    public void IsBust_WhenTotalPointsIsAboveTwentyOne_ReturnsTrue()
    {
        var player = new Player("You")
        {
            Hand = new List<Cards> { new(Suit.Spade, Number.Queen), new(Suit.Diamond, Number.King), new(Suit.Club, Number.Jack)}
        };
        player.Points = ScoreCalcs.ComputeTotalPoints(player);
        const bool expectedPlayerIsBust = true;

        var actual = Rules.IsBust(player);
        
        Assert.Equal(expectedPlayerIsBust, actual);
    }

    [Fact]
    public void IsBust_WhenTotalPointsIsBelowTwentyOne_ReturnsFalse()
    {
        var player = new Player("You")
        {
            Hand = new List<Cards> { new(Suit.Spade, Number.Queen), new(Suit.Diamond, Number.King)}
        };
        player.Points = ScoreCalcs.ComputeTotalPoints(player);
        const bool expectedPlayerIsNotBust = false;

        var actual = Rules.IsBust(player);
        
        Assert.Equal(expectedPlayerIsNotBust, actual);
    }
}