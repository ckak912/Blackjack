using Blackjack.GameServices;

namespace Blackjack;

public class Player
{
    public string Name {get;}
    public string Verb { get;}
    public List<Cards> Hand { get; set; }

    public int Points
    {
        get => ScoreCalcs.ComputeTotalPoints(Hand);
        set => ScoreCalcs.ComputeTotalPoints(Hand);
    }

    public bool IsBust => Points >= Rules.BlackJack;

    public Player(string name)
    {
        Name = name;
        Verb = Name.Equals("You") ? "are" : "is";
        Hand = new List<Cards>();
    }

    public void AddCardToHand(Cards cards)
    {
        Hand.Add(cards);
    }

    public static bool ChooseToStay(string? playerMove)
    {
        return playerMove == Rules.Stay;
    }
    
    
}