interface ICardDeck
{
    Card[] Cards { get; set; }

    Card PickCard();
    void PutCard(Card card);
}