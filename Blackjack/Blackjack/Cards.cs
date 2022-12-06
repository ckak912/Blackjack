using System.Runtime.InteropServices.JavaScript;

namespace Blackjack;

public class Cards
{
    public Suit Suit { get; }
    public Number Number { get; }

    public Cards(Suit suit, Number number)
    {
        Suit = suit;
        Number = number;
    }
}

public enum Suit
{
    Spade,
    Heart,
    Club,
    Diamond
};

public enum Number
{
    Ace = 1,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
}
