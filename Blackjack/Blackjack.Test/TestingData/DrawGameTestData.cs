using System.Collections;

namespace Blackjack.Test.TestingData;

public class DrawGameTestData : IEnumerable<object[]>
{
    private static readonly List<string> MockGameOnePlayerChooseToStay = new() { "0" };
    private static readonly List<string> MockGameTwoPlayerChooseToStay = new() { "0" };
    private static readonly List<string> MockGameThreePlayerChooseToHitTwiceThenStay = new() { "1", "1", "0" };

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new List<Cards>
            {
                new(Suit.Club, Number.King), new(Suit.Diamond, Number.Seven),
                new(Suit.Spade, Number.Nine), new(Suit.Heart, Number.Eight)
            },
            MockGameOnePlayerChooseToStay
        };
        yield return new object[]
        {
            new List<Cards>
            {
                new(Suit.Club, Number.King), new(Suit.Diamond, Number.Eight),
                new(Suit.Spade, Number.Ace), new(Suit.Heart, Number.Four),
                new(Suit.Diamond, Number.King), new(Suit.Diamond, Number.Three)
            },
            MockGameTwoPlayerChooseToStay
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}