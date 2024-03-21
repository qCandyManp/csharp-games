class Hand : IHand
{
    public Card[] Cards { get; set; }

    public Hand(Card card)
    {
        Cards = new Card[] { card };
    }

    public void AddCard(Card card)
    {
        Cards.Append(card);
    }

    public Card RemoveCard(int index)
    {
        if (index < 0 || index >= Cards.Length)
        {
            throw new ArgumentOutOfRangeException("Index out of range");
        }

        Card card = Cards[index];
        Cards = Cards.Where((source, i) => i != index).ToArray();

        return card;
    }

    public void Print()
    {
        foreach (Card card in Cards)
        {
            Console.WriteLine(card);
        }
    }
}