using System;
using Blackjack;
using Blackjack.Interfaces;

namespace Blackjack.Test.IO;

public class FakeConsoleInput : IReadLine
{
    private List<string> FakePlayerInput { get; }

    public FakeConsoleInput(List<string> input)
    {
        FakePlayerInput = input;
    }
    
    public string? ReadLine()
    {
        var firstInput = FakePlayerInput[0];

        if (FakePlayerInput.Count > 1)
            FakePlayerInput.RemoveAt(0);
        return firstInput;
    }

    public List<string> ReadFakeInput()
    {
        return FakePlayerInput;
    }
}