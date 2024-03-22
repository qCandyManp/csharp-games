class CardDeck : ICardDeck
{
    public List<Card> Cards { get; set; }
    public CardDeck()
    {
        Cards = new List<Card>();

        int index = 0;
        int colorIndex = 0;
        foreach (string color in CardColor.names)
        {
            int nameIndex = 0;
            foreach (string name in Card.names)
            {
                Cards.Add(new Card(colorIndex, nameIndex));
                index++;
                nameIndex++;
            }
            colorIndex++;
        }
    }

    public Card PickCard()
    {
        if (Cards.Count == 0)
        {
            throw new InvalidOperationException("No cards left in the deck");
        }

        int rand = new Random().Next(0, Cards.Count - 1);

        Card card = Cards[rand];
        // remove card from deck
        Cards.RemoveAt(rand);

        return card;
    }

    public void PutCard(Card card)
    {
        Cards.Append(card);
    }
}