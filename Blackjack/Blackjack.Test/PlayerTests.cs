using Xunit;

namespace Blackjack.Test;
//This testing class checks to see if the methods in Player.cs work as intended
//Unit testing
public class PlayerTests
{
    [Fact]
    public void AddCardToHand_WhenCalled_AddsOneCardToPlayerHand()
    {
        var player = new Player("You");
        { 
            player.Hand = new List<Cards> { new(Suit.Spade, Number.Ace), new(Suit.Diamond, Number.Two)};
        }
        var card = new Cards(Suit.Diamond, Number.Eight);
        const int expectedNumberOfCards = 3;
        
        player.AddCardToHand(card);
        var actualNumberOfCards = player.Hand.Count;
        
        Assert.Equal(expectedNumberOfCards, actualNumberOfCards);
    }

    [Fact]
    public void ChooseToStay_ReturnsTrue_WhenPlayerEntersZero()
    {
        const string? playerMove = "0";
        const bool expected = true;

        var actual = Player.ChooseToStay(playerMove);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ChooseToStay_ReturnsFalse_WhenPlayerEntersOne()
    {
        const string? playerMove = "1";
        const bool expected = false;

        var actual = Player.ChooseToStay(playerMove);
        
        Assert.Equal(expected, actual);
    }
    
    
}