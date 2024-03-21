class CardDeck : ICardDeck
{
    public Card[] Cards { get; set; }
    public CardDeck()
    {
        Cards = new Card[] { };

        int index = 0;
        int colorIndex = 0;
        int nameIndex = 0;
        foreach (string color in CardColor.colors)
        {
            foreach (string name in Card.names)
            {
                Cards[index] = new Card(colorIndex, nameIndex);
                index++;
                nameIndex++;
            }
            colorIndex++;
        }
    }

    public Card PickCard()
    {
        if (Cards.Length == 0)
        {
            throw new InvalidOperationException("No cards left in the deck");
        }

        int rand = new Random().Next(0, Cards.Length - 1);

        Card card = Cards[rand];
        // remove card from deck
        Cards = Cards.Where((source, index) => index != rand).ToArray();

        return card;
    }

    public void PutCard(Card card)
    {
        Cards.Append(card);
    }
}