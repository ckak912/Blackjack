using System.Collections;

namespace Blackjack.Test.TestingData;

public class DealerWinsTestData : IEnumerable<object[]>
{
    private static readonly List<string> MockGameOnePlayerChooseToHitThenStay = new(){"1","0"};
    private static readonly List<string> MockGameTwoPlayerChooseToStay = new(){"0"};

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new List<Cards>
            {
                new(Suit.Heart, Number.King), new(Suit.Diamond, Number.Three),
                new(Suit.Spade, Number.Nine), new(Suit.Heart, Number.Jack),
                new(Suit.Spade, Number.Four)
            },
            MockGameOnePlayerChooseToHitThenStay
        };

        yield return new object[]
        {
            new List<Cards>
            {
                new(Suit.Club, Number.King), new(Suit.Diamond, Number.Eight),
                new(Suit.Spade, Number.Two), new(Suit.Heart, Number.Four),
                new(Suit.Diamond, Number.King), new(Suit.Diamond, Number.Five)
            },
            MockGameTwoPlayerChooseToStay
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}