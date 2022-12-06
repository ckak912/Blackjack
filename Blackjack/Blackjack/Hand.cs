using Blackjack.Interfaces;

namespace Blackjack;

public class Hand : IHand
{
    public List<Cards> Cards { get; private set; }
    private const int IndexOfFirstCard = 0;
    private const int IndexOfSecondCard = 1;
    private const int TwoCards = 2;
    private const int OneCard = 1;

    public Hand()
    {
        Cards = new List<Cards>();
        var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>().ToList();
        var faces = Enum.GetValues(typeof(Number)).Cast<Number>().ToList();

        foreach (var card in from suit in suits from face in faces select new Cards(suit, face))
        {
            Cards.Add(card);
        }
    }

    public void Shuffle()
    {
        var random = new Random();
        Cards = Cards.OrderBy(x => random.Next()).ToList();
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
    }

    
}