using Xunit;

using Blackjack.GameServices;
//This testing class checks to see if the methods involved in PlayerValidation.cs works as intended
namespace Blackjack.Test;

public class PlayerValidationTests
{
    //arrange, act and assert
    //new test to see if cards are being dealt correctly in Hand class
    //MemberData
    [Theory] //Fact & Theory tests, fact takes no arguments, just works
    [InlineData("1")]
    [InlineData("0")]
    [InlineData("   0")]
    [InlineData("   1")]
    [InlineData("  1\n\t")]
    public void GivenCorrectInput_CheckIfPlayerHitOrStay_ReturnsTrue(string userInput)
    {
        var result = PlayerValidation.CheckIfPlayerHitOrStay(userInput);
        
        Assert.True(result);
    }
    
    [InlineData("abc")]
    [InlineData("")]
    [InlineData(null)]
    [Theory]
    public void GivenIncorrectInput_CheckIfPlayerHitOrStay_ReturnsFalse(string? userInput)
    {
        var result = PlayerValidation.CheckIfPlayerHitOrStay(userInput);
        
        Assert.False(result);
    }
    
}