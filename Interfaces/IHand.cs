interface IHand
{
    Card[] Cards { get; set; }
    void AddCard(Card card);
    Card RemoveCard(int index);
}