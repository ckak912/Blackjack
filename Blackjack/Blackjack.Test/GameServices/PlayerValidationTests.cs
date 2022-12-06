using Blackjack.GameServices;
using Xunit;

namespace Blackjack.Test.GameServices;

public class PlayerValidationTests
{
    [Theory]
    [InlineData("1", true)]
    [InlineData("0", true)]
    [InlineData("", false)]
    [InlineData("01", false)]
    [InlineData("11", false)]
    [InlineData("101", false)]
    [InlineData("abc", false)]
    [InlineData("&&", false)]
    public void CheckIfPlayerHitOrStay_WhenConfirmingPlayerInput_ReturnsTrueOnlyIfPlayerEntersOneOrZero(
        string userInput, bool expected)
    {
        var actual = PlayerValidation.CheckIfPlayerHitOrStay(userInput);
        
        Assert.Equal(expected, actual);
    }
}