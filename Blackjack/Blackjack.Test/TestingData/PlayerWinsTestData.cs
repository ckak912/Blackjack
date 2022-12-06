using System.Collections;

namespace Blackjack.Test.TestingData;

public class PlayerWinsTestData : IEnumerable<object[]>
{
    private static readonly List<string> MockGameOnePlayerChooseToStay = new(){"0"};
    private static readonly List<string> MockGameTwoPlayerChooseToStay = new(){"0"};
    private static readonly List<string> MockGameThreePlayerChooseToHitThenStay = new(){"1","0"};

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new List<Cards>
            {
                new(Suit.Club, Number.King), new(Suit.Diamond, Number.King),
                new(Suit.Spade, Number.Jack), new(Suit.Heart, Number.Eight)
            },
            MockGameOnePlayerChooseToStay
        };

        yield return new object[]
        {
            new List<Cards>
            {
                new(Suit.Club, Number.Ace), new(Suit.Diamond, Number.King),
                new(Suit.Spade, Number.Two), new(Suit.Heart, Number.Queen),
                new(Suit.Diamond, Number.King)
            },
            MockGameTwoPlayerChooseToStay
        };

        yield return new object[]
        {
            new List<Cards>
            {
                new(Suit.Heart, Number.Ace), new(Suit.Diamond, Number.King),
                new(Suit.Spade, Number.King), new(Suit.Heart, Number.Queen),
                new(Suit.Club, Number.Jack)
            },
            MockGameThreePlayerChooseToHitThenStay
        };


    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}