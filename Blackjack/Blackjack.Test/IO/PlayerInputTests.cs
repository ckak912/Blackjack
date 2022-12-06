using Blackjack.IO;
using Blackjack.Test.TestingData;
using Xunit;

namespace Blackjack.Test.IO;

public class PlayerInputTests
{
    [Theory]
    [MemberData(nameof(PlayerInputTestData.GoodPlayerInputData), MemberType = typeof(PlayerInputTestData))]
    public void GetPlayerMove_WhenPlayerChooseToHitOrStay_ReturnsValidMove(List<string> input, string expected)
    {
        var fakeConsoleOutput = new FakeConsoleOutput();
        var fakeConsoleInput = new FakeConsoleInput(input);
        var testUserInput = new FakePlayerInput(fakeConsoleOutput, fakeConsoleInput);

        var actual = testUserInput.GetPlayerMove();
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(PlayerInputTestData.PlayerInputData), MemberType = typeof(PlayerInputTestData))]
    public void GetPlayerMove_WhenPlayerDoesntEnterZeroOrOne_AsksPlayerToEnterZerOrOneUntilPlayerEntersZeroOrOne(
        List<string> input, string expectedValidPlayerMove)
    {
        var fakeConsoleOutput = new FakeConsoleOutput();
        var fakeConsoleInput = new FakeConsoleInput(input);
        var testUserInput = new FakePlayerInput(fakeConsoleOutput, fakeConsoleInput);

        var actualValidPlayerMove = testUserInput.GetPlayerMove();
        
        Assert.Equal(expectedValidPlayerMove, actualValidPlayerMove);
    }

    [Theory]
    [MemberData(nameof(PlayerInputTestData.CallingData), MemberType = typeof(PlayerInputTestData))]
    public void GetPlayerMove_WhenPlayerDoesntEnterZeroOrOne_ReturnsInvalidMoveNotificationUntilPlayerEntersValidMove(
        List<string> input, int expectedInvalidMoveCallCount)
    {
        var fakeConsoleOutput = new FakeConsoleOutput();
        var fakeConsoleInput = new FakeConsoleInput(input);
        var testUserInput = new FakePlayerInput(fakeConsoleOutput, fakeConsoleInput);

        var goodPlayerMove = testUserInput.GetPlayerMove();
        var actualInvalidMoveCallCount = testUserInput.HowManyCallsCount();
        
        Assert.Equal(expectedInvalidMoveCallCount, actualInvalidMoveCallCount);
    }
}