class Hand : IHand
{
    public List<Card> Cards { get; set; }

    public Hand(Card card)
    {
        Cards = new List<Card> { card };
    }

    public void AddCard(Card card)
    {
        Cards.Append(card);
    }

    public Card RemoveCard(int index)
    {
        if (index < 0 || index >= Cards.Count)
        {
            throw new ArgumentOutOfRangeException("Index out of range");
        }

        Card card = Cards[index];
        Cards.RemoveAt(index);

        return card;
    }

    public int GetValue()
    {
        int value = 0;
        int aces = 0;

        foreach (Card card in Cards)
        {
            value += card.Value();

            if (card.Name() == "Ace")
            {
                aces++;
            }
        }

        if (value > 21)
        {
            while (aces > 0 && value > 21)
            {
                value -= 10;
                aces--;
            }
        }

        return value;
    }

    public void Print()
    {
        foreach (Card card in Cards)
        {
            Console.WriteLine(card.Icon());
        }
    }
}