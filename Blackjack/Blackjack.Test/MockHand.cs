using Blackjack;
using Blackjack.Interfaces;

namespace Blackjack.Test;

public class MockHand : IHand
{
    private Queue<Cards> Cards { get; set; }
    private List<Cards> InitialCards;
    
    public MockHand(List<Cards> cards)
    {
        InitialCards = cards;
        Cards = new Queue<Cards>(cards);
    }

    public void Shuffle()
    {
        if (Cards.Count >= 13)
        {
            var random = new Random();
            var newCards = InitialCards.OrderBy(x => random.Next()).ToList();
            Cards = new Queue<Cards>(newCards);
        }
    }

    public List<Cards> DealHand()
    {
        return new List<Cards>
        {
            Cards.Dequeue(),
            Cards.Dequeue()
        };
    }

    public Cards DealOneCard()
    {
        return Cards.Dequeue();
    }
}