using Blackjack.Interfaces;
using Blackjack.GameServices;

namespace Blackjack.Test.IO;

public class FakePlayerInput : IUserInput
{
    private readonly FakeConsoleOutput _fakeConsoleOutput;
    private readonly FakeConsoleInput _fakeConsoleInput;
    private int _counter;

    public FakePlayerInput(FakeConsoleOutput fakeConsoleOutput, FakeConsoleInput fakeConsoleInput)
    {
        _fakeConsoleOutput = fakeConsoleOutput;
        _fakeConsoleInput = fakeConsoleInput;
    }
    public string? GetPlayerMove()
    {
        var fakePlayerInputs = _fakeConsoleInput.ReadFakeInput(); //fake inputs are inserted into a list of strings
        
        _fakeConsoleOutput.PrintAskPlayerHitOrStay();
        var playerMove = fakePlayerInputs[0]; //get the first index of the list
        fakePlayerInputs.RemoveAt(0);
        var playerMoveIsValid = PlayerValidation.CheckIfPlayerHitOrStay(playerMove);

        while (!playerMoveIsValid)
        {
            _fakeConsoleOutput.PrintEnterValidMove();
            _counter++;
            playerMove = fakePlayerInputs[0];
            fakePlayerInputs.RemoveAt(0);
            playerMoveIsValid = PlayerValidation.CheckIfPlayerHitOrStay(playerMove);
        }

        return playerMove;
    }

    public int HowManyCallsCount()
    {
        return _counter;
    }
}