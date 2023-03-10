using Blackjack;
using Blackjack.GameServices;
using Xunit;

namespace Blackjack.Test.GameServices;

public class CheckIfWonTests
{
    [Theory]
    [InlineData(18, 20)]
    [InlineData(25, 20)]
    public void DecideWinner_WhenPlayerPointsIsMoreThanDealerPointsOrDealerIsBust_ReturnsPlayerWins(int dealerPoints, int playerPoints)
    {
        var dealer = new Player("Dealer") { Points = dealerPoints };
        var player = new Player("You") { Points = playerPoints };

        var actual = CheckIfWon.DecideWinner(dealer, player);
        
        Assert.Equal(player, actual);
    }

    [Fact]
    public void DecideWinner_WhenDealerPointsIsMoreThanPlayerPoints_ReturnsDealerWins()
    {
        var dealer = new Player("Dealer") { Points = 18 };
        var player = new Player("You") { Points = 20};
        

        var actual = CheckIfWon.DecideWinner(dealer, player);
        
        Assert.Equal(player, actual);
    }

    [Fact]
    public void CheckIfDraw_WhenPlayerAndDealerHasSamePoints_ReturnsTrue()
    {
        var dealer = new Player("Dealer") { Points = 20 };
        var player = new Player("You") { Points = 20 };
        const bool expected = true;

        var actual = CheckIfWon.CheckIfDraw(dealer, player);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CheckIfDraw_WhenPlayerAndDealerHasDifferentPoints_ReturnFalse()
    {
        var dealer = new Player("Dealer") { Hand = new List<Cards> {new(Suit.Club, Number.Ten), new(Suit.Club, Number.Eight)} };
        var player = new Player("You") { Points = 20 };
        const bool expected = false;

        var actual = CheckIfWon.CheckIfDraw(dealer, player);
        
        Assert.Equal(expected, actual);
    }
}