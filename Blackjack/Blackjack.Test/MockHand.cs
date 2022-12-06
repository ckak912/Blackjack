using Blackjack;
using Blackjack.Interfaces;

namespace Blackjack.Test;

public class MockHand : IHand
{
    public List<Cards> Cards { get; set; }
    private const int IndexOfFirstCard = 0;
    private const int IndexOfSecondCard = 1;
    private const int TwoCards = 2;
    private const int OneCard = 1;

    
    public MockHand(List<Cards> cards)
    {
        Cards = cards;
    }

    public void Shuffle()
    {
        if (Cards.Count >= 13)
        {
            var random = new Random();
            Cards = Cards.OrderBy(x => random.Next()).ToList();
        }
    }

    public List<Cards> DealHand()
    {
        var hand = new List<Cards>
        {
            Cards[IndexOfFirstCard],
            Cards[IndexOfSecondCard]
        };
        RemoveFromDeck(TwoCards);
        return hand;
    }

    public Cards DealOneCard()
    {
        var card = Cards[IndexOfFirstCard];
        RemoveFromDeck(OneCard);
        return card;
    }

    private void RemoveFromDeck(int numberOfCards)
    {
        Cards.RemoveRange(IndexOfFirstCard, numberOfCards);
    }}