using Blackjack.GameServices;
using Xunit;

namespace Blackjack.Test.GameServices;

public class ScoreCalcsTests
{
    [Fact]
    public void ComputeTotalPoints_WhenCalled_ReturnsSumOfPointsInPlayerHand()
    {
        var player = new Player("You")
        {
            Hand = new List<Cards>() { new(Suit.Spade, Number.Two), new(Suit.Diamond, Number.Eight) }
        };
        const int expected = 10;

        var actual = player.Points;
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ComputeTotalPoints_WhenOneCardIsQueen_ReturnsSumOfPointsWithTenPointsAllocatedToQueenCard()
    {
        var player = new Player("You")
        {
            Hand = new List<Cards>() { new(Suit.Spade, Number.Queen), new(Suit.Diamond, Number.Eight) }
        };
        const int expected = 18;

        var actual = player.Points;
        
        Assert.Equal(expected, actual);
    }
}