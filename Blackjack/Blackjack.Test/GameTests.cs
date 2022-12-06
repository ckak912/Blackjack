using Blackjack;
using Blackjack.Test.TestingData;
using Blackjack.IO;
using Blackjack.Test.IO;
using Xunit;

namespace Blackjack.Test;
//end to end testing of game
//TODO: Implement IO testing interfaces so that I can instantiate input/output classes 
public class GameTests
{
    private readonly Player _player = new("You");
    private readonly Player _dealer = new("dealer");
    private const string ExpectedPlayerWinsMessage = "\n You beat the dealer! Congrats!";
    private const string ExpectedDealerWinsMessage = "\n Unlucky. The dealer beat you!";
    private const string ExpectedDrawGameMessage = "\n Draw game. Thanks for playing.";

    [Theory]
    [ClassData(typeof(PlayerWinsTestData))]
    public void Run_WhenPlayerHasHigherPointsOrDealerBusts_PrintPlayerWinsMessage(List<Cards> hand, List<string> fakeInput)
    {
        var mockHand = new MockHand(hand);
        var fakeConsoleOutput = new FakeConsoleOutput();
        var fakeConsoleInput = new FakeConsoleInput(fakeInput);
        var fakePlayerInput = new FakePlayerInput(fakeConsoleOutput, fakeConsoleInput);
        var game = new Game(_dealer, _player, mockHand, fakeConsoleOutput, fakePlayerInput);
        
        game.RunGame();
        var actualOutput = fakeConsoleOutput.TestOutput;

        Assert.Contains(ExpectedPlayerWinsMessage, actualOutput);
    }

    [Theory]
    [ClassData(typeof(DealerWinsTestData))]
    public void Run_WhenDealerHasHigherPointsOrPlayerBusts_PrintDealerWinsMessage(List<Cards> hand, List<string> fakeInput)
    {
        var mockHand = new MockHand(hand);
        var fakeConsoleOutput = new FakeConsoleOutput();
        var fakeConsoleInput = new FakeConsoleInput(fakeInput);
        var fakePlayerInput = new FakePlayerInput(fakeConsoleOutput, fakeConsoleInput);
        var game = new Game(_dealer, _player, mockHand, fakeConsoleOutput, fakePlayerInput);
        
        game.RunGame();
        var actualOutput = fakeConsoleOutput.TestOutput;

        Assert.Contains(ExpectedDealerWinsMessage, actualOutput);
    }

    [Theory]
    [ClassData(typeof(DrawGameTestData))]
    public void Run_WhenDealerAndPlayerHasSameAmountOfPoints_PrintDrawGameMessage(List<Cards> hand,
        List<string> fakeInput)
    {
        var mockHand = new MockHand(hand);
        var fakeConsoleOutput = new FakeConsoleOutput();
        var fakeConsoleInput = new FakeConsoleInput(fakeInput);
        var fakePlayerInput = new FakePlayerInput(fakeConsoleOutput, fakeConsoleInput);
        
        var game = new Game(_dealer, _player, mockHand, fakeConsoleOutput, fakePlayerInput);
        
        game.RunGame();
        var actualOutput = fakeConsoleOutput.TestOutput;

        Assert.Contains(ExpectedDrawGameMessage, actualOutput);
    }
    


}