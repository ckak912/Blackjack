namespace Blackjack.Test.TestInputs;

public class CardsTestData
{
    public static IEnumerable<object[]> SuitsData() => new List<object[]>
    {
        new object[] { new Cards(Suit.Spade, Number.Ace), "Spade" },
        new object[] { new Cards(Suit.Heart, Number.Two), "Heart" },
        new object[] { new Cards(Suit.Club, Number.Three), "Club" },
        new object[] { new Cards(Suit.Diamond, Number.Four), "Diamond" },
    };
    public static IEnumerable<object[]> NumbersData => new List<object[]>
    {
        new object[] { new Cards(Suit.Spade, Number.Ace), "Ace" },
        new object[] { new Cards(Suit.Heart, Number.Two), "Two" },
        new object[] { new Cards(Suit.Club, Number.Three), "Three" },
        new object[] { new Cards(Suit.Diamond, Number.Four), "Four" },
        new object[] { new Cards(Suit.Spade, Number.Five), "Five" },
        new object[] { new Cards(Suit.Heart, Number.Six), "Six" },
        new object[] { new Cards(Suit.Club, Number.Seven), "Seven" },
        new object[] { new Cards(Suit.Diamond, Number.Eight), "Eight" },
        new object[] { new Cards(Suit.Spade, Number.Nine), "Nine" },
        new object[] { new Cards(Suit.Heart, Number.Ten), "Ten" },
        new object[] { new Cards(Suit.Club, Number.Jack), "Jack" },
        new object[] { new Cards(Suit.Diamond, Number.Queen), "Queen" },
        new object[] { new Cards(Suit.Spade, Number.King), "King" },
    };
}