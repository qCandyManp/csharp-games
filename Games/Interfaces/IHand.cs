public interface IHand
{
    List<Card> Cards { get; set; }
    void AddCard(Card card);
    Card RemoveCard(int index);
}