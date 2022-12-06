namespace Blackjack.GameServices;

public abstract class PlayerValidation
{
    public static bool CheckIfPlayerHitOrStay(string? userInput)
    {
        return userInput?.Trim() is "0" or "1";
    }
}