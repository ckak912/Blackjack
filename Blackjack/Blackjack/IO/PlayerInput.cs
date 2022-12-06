using Blackjack.GameServices;
using Blackjack.Interfaces;

namespace Blackjack.IO;

public class PlayerInput : IUserInput
{
    private readonly ConsoleOutput _consoleOutput;
    private readonly ConsoleInput  _consoleInput;

    public PlayerInput(ConsoleOutput consoleOutput, ConsoleInput consoleInput)
    {
        _consoleOutput = consoleOutput;
        _consoleInput = consoleInput;
    }

    public string? GetPlayerMove()
    {
        _consoleOutput.PrintAskPlayerHitOrStay();
        var playerMove = _consoleInput.ReadLine();
        var playerMoveIsValid = PlayerValidation.CheckIfPlayerHitOrStay(playerMove);

        while (!playerMoveIsValid)
        {
            _consoleOutput.PrintEnterValidMove();
            playerMove = _consoleInput.ReadLine();
            playerMoveIsValid = PlayerValidation.CheckIfPlayerHitOrStay(playerMove);
        }
        return playerMove;
    }
}