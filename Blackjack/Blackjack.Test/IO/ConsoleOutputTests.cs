using System;
using System.Collections.Generic;
using System.IO;
using Blackjack;
using Blackjack.IO;
using Xunit;

namespace Blackjack.Test.IO;

public class ConsoleOutputTests
{
    [Fact]
    public void PrintStartGameMessages_WhenGameRan()
    {
        var consoleOutput = new ConsoleOutput();
        var expected = "Welcome to BlackJack!\nPlease wait while the dealer deals the cards ...\n";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        consoleOutput.PrintStartGameMessage();
        
        Assert.Equal(expected.ToString(), stringWriter.ToString());
    }

    [Fact]
    public void PrintTotalPointsAndHand_DisplaysTotalPointsAndHand()
    {
        var consoleOutput = new ConsoleOutput();
        var player = new Player("You")
        {
            Hand = new List<Cards> { new(Suit.Diamond, Number.Eight), new(Suit.Spade, Number.Queen) },
            Points = 18
        };
        const string expected = "\nYou are currently at 18" + 
                                "\nwith the hand [[8, 'Diamond'] , ['Queen', 'Spade']]\n";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        consoleOutput.PrintTotalPointsAndHand(player);

        Assert.Contains(expected, stringWriter.ToString());
    }

    [Fact] 
    public void AskPlayerHitOrStay_DisplaysChoiceToHitOrStay()
    {
        var consoleOutput = new ConsoleOutput();
        var expected = "\n Hit or stay? (Hit = 1, Stay = 0) \n";

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        consoleOutput.PrintAskPlayerHitOrStay();
        
        Assert.Equal(expected, stringWriter.ToString());
    }

    [Fact]
    public void PrintCardDrawnMessage_DisplaysCardDrawn()
    {
        var consoleOutput = new ConsoleOutput();
        var player = new Player("You");
        var card = new Cards(Suit.Diamond, Number.Eight);
        const string expected = "You draw [8, 'Diamond']\n";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        consoleOutput.PrintCardDrawnMessage(player, card);
        
        Assert.Equal(expected, stringWriter.ToString());
    }

    [Theory]
    [InlineData("1", "1\n")]
    [InlineData("0", "0\n")]
    public void PrintPlayerChoseHitOrStay_WhenPlayerEntersOneOrZero_PrintPlayersChoice(string playerMove, string expected)
    {
        var consoleOutput = new ConsoleOutput();

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        consoleOutput.PrintPlayerChoseHitOrStay(playerMove);
        
        Assert.Equal(expected, stringWriter.ToString());
    }

    [Fact]
    public void TestPrintPlayerWinsMessage_WhenPlayerWins()
    {
        var consoleOutput = new ConsoleOutput();
        const string expected = "\n You beat the dealer! Congrats!\n";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        consoleOutput.PrintPlayerWinsMessage();
        
        Assert.Equal(expected, stringWriter.ToString());
    }

    [Fact]
    public void TestPrintDealerWinsMessage_WhenDealerWins()
    {
        var consoleOutput = new ConsoleOutput();
        const string expected = "\n Unlucky. The dealer beat you!\n";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        consoleOutput.PrintDealerWinsMessage();
        
        Assert.Equal(expected, stringWriter.ToString());
    }
}