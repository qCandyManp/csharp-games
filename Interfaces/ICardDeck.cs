interface ICardDeck
{
    List<Card> Cards { get; set; }

    Card PickCard();
    void PutCard(Card card);
}