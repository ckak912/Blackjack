using System.Text.RegularExpressions;

namespace Blackjack.Services;

public class PlayerValidation
{
    public static bool CheckIfPlayerHitOrStay(string? userInput)
    {
        // this function compares the string userInput with the parsed values of Hit and Stay (parsed from int to string), 
        // if they are the same then it returns the boolean. Regex.IsMatch is what checks if same, while IsNullOrEmpty checks
        // if it is non-null
        var checkValue = "^([" + int.Parse(Rules.Hit) + "] | [" + int.Parse(Rules.Stay) + "]){1}$";  
        return !string.IsNullOrEmpty(userInput) && Regex.IsMatch(userInput, checkValue);            

    }
}