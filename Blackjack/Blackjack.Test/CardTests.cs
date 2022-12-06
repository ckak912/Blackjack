using Blackjack.Test.TestInputs;
using Xunit;
namespace Blackjack.Test;

public class CardTests
{
    [Theory]
    [MemberData(nameof(CardsTestData.SuitsData), MemberType = typeof(CardsTestData))]
    public void CardPropertySuit_StoresCorrectSuitProperty(Cards cards, string expectedSuit)
    {
        var actualCardSuit = cards.Suit.ToString();

        Assert.Equal(expectedSuit, actualCardSuit);
    }
        
    [Theory]
    [MemberData(nameof(CardsTestData.NumbersData), MemberType = typeof(CardsTestData))]
    public void CardPropertyNumber_StoresCorrectNumberProperty(Cards cards, string expectedNumber) //this is failing right now. Expected is spade but actual is ace
    {
        var actualCardNumber = cards.Number.ToString();
            
        Assert.Equal(expectedNumber, actualCardNumber);
    }
}