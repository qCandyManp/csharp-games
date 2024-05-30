public class Hand(params Card[] cards) : IHand
{
    public List<Card> Cards { get; set; } = new List<Card>(cards);

    public void AddCard(Card card)
    {
        Cards.Add(card);
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

        foreach (Card card in Cards)
        {
            value += card.Value();
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