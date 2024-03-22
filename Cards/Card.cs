class Card : ICard
{
    public static readonly string[] names = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

    public CardColor Color { get; set; }
    public int Index { get; set; }
    public string Name()
    {
        return names[Index];
    }

    public Card(int colorIndex, int nameIndex)
    {
        Color = new CardColor(colorIndex);
        Index = nameIndex;
    }

    public string FullName()
    {
        return $"{Name} of {Color.Name()}";
    }

    public string Icon()
    {
        if (Index > 0 && Index < 10)
        {
            return $"{Index}{Color.Icon()}";
        }
        else
        {
            return $"{Name()[0]}{Color.Icon()}";
        }
    }

    public int Value()
    {
        if (Index == 0)
        {
            return 11;
        }

        if (Index >= 9)
        {
            return 10;
        }

        return Index + 1;
    }
}