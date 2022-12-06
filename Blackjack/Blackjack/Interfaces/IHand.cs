namespace Blackjack.Interfaces;

public interface IHand
{
    public void Shuffle();
    public List<Cards> DealHand();
    public Cards DealOneCard();
}